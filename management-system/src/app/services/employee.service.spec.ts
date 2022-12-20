import { Employee } from "../model/employee.model";
import { EmployeeService } from "./employee.service";
import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";
import { TestBed } from "@angular/core/testing";

describe('EmployeeService', () => {
    let empService: EmployeeService;
    let httpTestingController: HttpTestingController;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
                HttpClientTestingModule
            ]
        });
        httpTestingController = TestBed.get(HttpTestingController);
        empService = TestBed.inject(EmployeeService);
    });

    it('EmployeeService: should create employee service', () => {
        expect(empService).toBeTruthy();
    });

    it('getEmployeeList(): should return data from employee list', () => {
        const employee = [{
            id: 1,
            firstName: "Janaki",
            lastName: "Chaniyara",
            email: "chaniyarajay@gmail.com",
            dateOfBirth: "2000-06-09T00:00:00",
            age: 22,
            joinedDate: new Date(),
            isActive: true,
            departmentId: 1
        }] as Employee[];
        empService.getEmployeeList().subscribe((res) => {
            expect(res).toBe(employee);
        });
        const req = httpTestingController.expectOne('https://localhost:7096/api/Employee');
        expect(req.request.method).toBe('GET');
        req.flush(employee);
    });

    it('deleteEmployee(id): should return delete employee by id', () => {
        empService.deleteEmployee(1).subscribe((data: any) => {
            expect(data.id).toBe(1);
        });
        const req = httpTestingController.expectOne(`https://localhost:7096/api/Employee/1`);
        expect(req.request.method).toBe('DELETE');
        req.flush({
            id: 1
        });
        httpTestingController.verify();
    });

    it('addEmployee(): should create new employee', () => {
        const employee = {
            id: 1,
            firstName: "Janaki",
            lastName: "Chaniyara",
            email: "chaniyarajay@gmail.com",
            dateOfBirth: "2000-06-09T00:00:00",
            age: 22,
            isActive: true,
            departmentId: 1
        }as Employee;

        empService.addEmployee(employee).subscribe((data: any) => {
            expect(data.id).toBe(1);
        });
        const req = httpTestingController.expectOne(`https://localhost:7096/api/Employee`);
        expect(req.request.method).toBe('POST');
        req.flush({
            id: 1
        });
        httpTestingController.verify();
    });

    it('updateEmployee(): should update employee', () => {
        const employee = {
            id: 1,
            firstName: "Janaki",
            lastName: "Chaniyara",
            email: "chaniyarajay@gmail.com",
            dateOfBirth: "2000-06-09T00:00:00",
            age: 22,
            isActive: true,
            departmentId: 1
        } as Employee;

        empService.updateEmployee(employee).subscribe((data: any) => {
            expect(data.id).toBe(1);
        });
        const req = httpTestingController.expectOne(`https://localhost:7096/api/Employee`);
        expect(req.request.method).toBe('PUT');
        req.flush({
            id: 1
        });
        httpTestingController.verify();
    });
});