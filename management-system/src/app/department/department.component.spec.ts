import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DepartmentService } from '../services/department.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { DepartmentComponent } from './department.component';
import { of } from 'rxjs';
import { Department } from '../model/department.model';

describe('DepartmentComponent', () => {
  let component: DepartmentComponent;
  let fixture: ComponentFixture<DepartmentComponent>;
  let mockDepartmentService: DepartmentService;
  let expectedResult: Department[];

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DepartmentComponent],
      imports: [ReactiveFormsModule, FormsModule, HttpClientTestingModule],
      providers: [DepartmentService]
    })
      .compileComponents();

    fixture = TestBed.createComponent(DepartmentComponent);
    component = fixture.componentInstance;
    mockDepartmentService = TestBed.inject(DepartmentService);
    fixture.detectChanges();
    component.departmentList = expectedResult;

    expectedResult = [{
      id: 1,
      name: "IT Dept",
      isActive: true,
    },
    {
      id: 2,
      name: "CSE",
      isActive: true,
    }];

  });

  it('DepartmentComponent: should create department component', () => {
    expect(component).toBeTruthy();
  });

  it('refreshDepartmentList() : should display department list', () => {

    spyOn(mockDepartmentService, 'getDepartmentList').and.returnValue(of(expectedResult));
    component.refreshDepartmentList();
    expect(component.departmentList[0].id).toEqual(expectedResult[0].id);

  });

  it('onShowActiveOnly() : should display only active department data', () => {

    spyOn(mockDepartmentService, 'getActiveDepartmentList').and.returnValue(of(expectedResult));
    component.onShowActiveOnly();
    expect(component.departmentList[0].isActive).toEqual(expectedResult[0].isActive);

  });

  it('deleteDepartment(): should delete department data by id', () => {

    spyOn(mockDepartmentService, 'deleteDepartment').and.returnValue(of(true));
    component.deleteDepartment(expectedResult[1].id);
    expect(component.departmentList.length).toBe(1);

  });

});
