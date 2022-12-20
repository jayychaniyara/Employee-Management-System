import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Employee } from '../model/employee.model';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  selectedEmployee: Employee | undefined = undefined;
  employeeList: Employee[] = [];
  constructor(private service: EmployeeService) { }

  ngOnInit(): void {
    this.refreshEmployeeList();
  }

  refreshEmployeeList() {
    this.service.getEmployeeList().subscribe(data => {
      this.employeeList = data;
    });
  }

  onEdit(item: Employee) {
    this.selectedEmployee = item;
  }

  onNewEmployee() {
    this.selectedEmployee = new Employee();
  }

  onDelete(item: Employee) {
    const result = confirm(`You are about to delete employee ${item.id}. Are you sure?`);
    if (result == true) {
      this.service.deleteEmployee(item.id).subscribe(
        (response) => {
          const index = this.employeeList.findIndex(x => x.id == item.id);
          this.employeeList.splice(index, 1);
        },
        (error) => {
          alert(error);
        }
      )
    }
  }

  onAction($event: boolean) {
    if ($event) {
      // save changes
      if (this.selectedEmployee != undefined) {
        if (this.selectedEmployee.id == 0) {
          this.service.addEmployee(this.selectedEmployee).subscribe(
            (resposne: Employee) => {
              if (resposne != undefined) {
                this.employeeList.push(resposne);
              }
              this.selectedEmployee = undefined;
            },
            (err: HttpErrorResponse) => {
              alert(err.error);
            });

        } else {
          this.service.updateEmployee(this.selectedEmployee).subscribe(
            (resposne) => {
              this.selectedEmployee = undefined;
            },
            (err: HttpErrorResponse) => {
              alert(err.error);
            });

        }
      }
    } else {
      this.selectedEmployee = undefined;
    }

  }
}
