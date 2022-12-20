import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { EmployeeComponent } from './employee.component';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../model/employee.model';
import { of } from 'rxjs';

describe('EmployeeComponent', () => {
  let component: EmployeeComponent;
  let fixture: ComponentFixture<EmployeeComponent>;
  let mockEmployeeService: EmployeeService;
  let expectedResult: Employee[];

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [EmployeeComponent],
      imports: [HttpClientTestingModule],
      providers: [EmployeeService]
    })
      .compileComponents();

    fixture = TestBed.createComponent(EmployeeComponent);
    component = fixture.componentInstance;
    mockEmployeeService = TestBed.inject(EmployeeService);
    fixture.detectChanges();
    component.employeeList = expectedResult;

    expectedResult = [{
      id: 1,
      firstName: "Janaki",
      lastName: "Chaniyara",
      email: "chaniyarajay@gmail.com",
      dateOfBirth: "2000-06-09T00:00:00",
      age: 22,
      isActive: true,
      departmentId: 1
    },
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

  it('EmployeeComponent: should create employee component', () => {
    expect(component).toBeTruthy();
  });

  it('refreshEmployeeList() : should display employee list', () => {

    spyOn(mockEmployeeService, 'getEmployeeList').and.returnValue(of(expectedResult));
    component.refreshEmployeeList();
    expect(component.employeeList[0].id).toEqual(expectedResult[0].id);

  });

  it('onDelete(): should delete department data by id', () => {

    spyOn(mockEmployeeService, 'deleteEmployee').and.returnValue(of(true));
    component.onDelete(expectedResult[0]);
    expect(component.employeeList.length).toBe(1);

  });

  it('onNewEmployee(): should create new employee', () => {
    const a = true;
    component.onAction(a);
    component.onNewEmployee();
    component.selectedEmployee = expectedResult[0];

    spyOn(mockEmployeeService, 'addEmployee').and.returnValue(of(expectedResult[0]));
    expect(component.selectedEmployee).toEqual(expectedResult[0]);
  });

  it('onEdit(): should create new employee', () => {
    const a = true;
    component.onAction(a);
    component.selectedEmployee = expectedResult[0];
    component.onEdit(component.selectedEmployee);

    spyOn(mockEmployeeService, 'updateEmployee').and.returnValue(of(expectedResult[0]));
    expect(component.selectedEmployee).toEqual(expectedResult[0]);
  });
});

