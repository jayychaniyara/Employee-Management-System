import { Component, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { Department } from '../model/department.model';
import { DepartmentService } from '../services/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.scss']
})
export class DepartmentComponent implements OnInit {

  showActiveOnly: boolean = false;
  public departmentList: Department[] = [];

  item: any = '';

  constructor(private service: DepartmentService) { }
  ngOnInit(): void {
    this.refreshDepartmentList();
  }

  refreshDepartmentList(): any {
    this.service.getDepartmentList().subscribe(data => {
      this.departmentList = data;
    });
  }

  onShowActiveOnly() {
    if (!this.showActiveOnly) {
      this.service.getActiveDepartmentList().subscribe(data => {
        this.departmentList = data;
      });
    } else {
      this.refreshDepartmentList();
    }
  }

  deleteDepartment(id: number) {
    const result = confirm(`You are about to delete employee ${id}. Are you sure?`);
    if (result == true) {
      this.service.deleteDepartment(id).subscribe(
        (response: boolean) => {
          if (response == true) {
            const index = this.departmentList.findIndex(x => x.id == id);
            this.departmentList.splice(index, 1);
          } else {
            alert('You can not delete active department with employees.');
          }
        },
        (error) => {
          alert(error);
        }
      )
    }
  }

}
