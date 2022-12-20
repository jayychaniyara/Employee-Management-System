import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Employee } from 'src/app/model/employee.model';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.scss']
})
export class EditEmployeeComponent implements OnInit {

  @Input() employee: Employee = new Employee();
  @Output() action: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor() { }

  ngOnInit(): void {
    this.dateConvert();
  }

  onSave() {
    if(this.isInputValid()) {
      this.action.emit(true);
    }
  }
  dateConvert()
  {
    // this.employee.dateOfBirth = new Date(this.employee.dateOfBirth).toISOString().split('T')[0];
    console.log("Date Check below")
    console.log(this.employee.dateOfBirth)
  }
  isInputValid() {
    let err: string = '';
    let num: number = 1;
    if (this.employee.firstName.trim() == '') {
      err += `${num++}. First name can not be blank\n`;
    } else {
      if (this.employee.firstName.length < 3) {
        err += `${num++}. First name length can not be less than 3.\n`;
      }
  
      if (this.employee.firstName.length > 100) {
        err += `${num++}. First name length should not be greater than 100.\n`;
      }
    }

    if (this.employee.lastName.trim() == '') {
      err += `${num++}. Last name can not be blank\n`;
    } else {
      if (this.employee.lastName.length < 3) {
        err += `${num++}. Last name length can not be less than 3.\n`;
      }

      if (this.employee.lastName.length > 100) {
        err += `${num++}. Last name length should not be greater than 100.\n`;
      }
    }

    if (this.employee.age < 18 || this.employee.age > 58) {
      err += `${num++}. Employee age must be between 18 and 58 years.\n`;
    }

    let regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
    if(regexp.test(this.employee.email) == false) {
      err += `${num++}. Enter valid email address.\n`
    }

    if (err.length > 0) {
      alert(`Validation Errors:\n\n${err}`);
    }

    return err.length == 0;
  }

  onCancel() {
    this.action.emit(false);
  }

  onDateOfBirthChange($event: string) {
    var ageDifMs = Date.now() - new Date($event).getTime();
    var ageDate = new Date(ageDifMs);
    this.employee.age = Math.abs(ageDate.getUTCFullYear() - 1970);
    this.employee.dateOfBirth = $event;
  }
}
