import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { of } from 'rxjs';
import { Employee } from 'src/app/model/employee.model';
import { EmployeeService } from 'src/app/services/employee.service';
import { EditEmployeeComponent } from './edit-employee.component';

describe('EditEmployeeComponent', () => {
  let component: EditEmployeeComponent;
  let fixture: ComponentFixture<EditEmployeeComponent>;
  let mockEmployeeService: EmployeeService;
  let expectedResult: Employee[];
  let existingDetails: Employee[];

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, FormsModule, HttpClientTestingModule],
      declarations: [EditEmployeeComponent],
      providers: [EmployeeService]

    })
      .compileComponents();

    fixture = TestBed.createComponent(EditEmployeeComponent);
    component = fixture.componentInstance;
    mockEmployeeService = TestBed.inject(EmployeeService);
    fixture.detectChanges();

    expectedResult = [{
      id: 1,
      firstName: "Janaki",
      lastName: "Chaniyara",
      email: "chaniyarajay@gmail.com",
      dateOfBirth: "2000-06-09T00:00:00",
      age: 22,
      isActive: true,
      departmentId: 1
    }];

    existingDetails = [
      {
        id: 4,
        firstName: "Jay",
        lastName: "Chaniyara",
        email: "chaniyarajay@gmail.com",
        dateOfBirth: "2000-07-18T00:00:00",
        age: 23,
        isActive: true,
        departmentId: 1
      }];
  });

  it('EditEmployeeComponent: should create edit employee', () => {
    expect(component).toBeTruthy();
  });

  it('onSave(): should edit existing employee with proper validations', () => {
    component.employee = expectedResult[0];
    component.onSave();
    component.isInputValid();
    spyOn(mockEmployeeService, 'updateEmployee').and.returnValue(of(expectedResult[0]));
    expect(component.employee).toEqual(expectedResult[0]);
  });

  it('onCancel(): should return existing employee details', () => {
    component.employee = expectedResult[0];
    component.onCancel();
    expect(component.employee).not.toEqual(existingDetails[0]);
  });

  it('onDateOfBirthChange(): should return employee age from date of birth of employee', () => {
    var xx = "Tue Dec 20 2022 00:12:10 GMT+0530 (India Standard Time)";
    component.employee = expectedResult[0];
    component.onDateOfBirthChange(xx);
    expect(component.employee.dateOfBirth).toEqual(expectedResult[0].dateOfBirth);
  });
});
