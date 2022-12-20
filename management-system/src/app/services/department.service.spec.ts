import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";
import { TestBed } from "@angular/core/testing";
import { Department } from "../model/department.model";
import { DepartmentService } from "./department.service";

describe('DepartmentService', () => {

    let deptService: DepartmentService;
    let httpTestingController: HttpTestingController;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
                HttpClientTestingModule
            ]
        });
        httpTestingController = TestBed.get(HttpTestingController);
        deptService = TestBed.inject(DepartmentService);
    });

    it('DepartmentService: should create department service', () => {
        expect(deptService).toBeTruthy();
    });

    it('getDepartmentList(): should return data from department list', () => {
        const department = [{
            id: 1,
            name: "IT Dept",    
            isActive: true,
        }] as Department[];
        deptService.getDepartmentList().subscribe((res) => {
            expect(res).toBe(department);
        });
        const req = httpTestingController.expectOne('https://localhost:7096/api/Department');
        expect(req.request.method).toBe('GET');
        req.flush(department);
    });

    it('getActiveDepartmentList(): should return get only active department', () => {
        deptService.getActiveDepartmentList().subscribe((data: any) => {
            expect(data.isActive).toBe(true);
        });
        const req = httpTestingController.expectOne(`https://localhost:7096/api/Department/active`);
        expect(req.request.method).toBe('GET');
        req.flush({
            isActive: true
        });
        httpTestingController.verify();
    });

    it('deleteDepartment(id): should retrun delete department by id', () => {
        deptService.deleteDepartment(1).subscribe((data: any) => {
            expect(data.id).toBe(1);
        });
        const req = httpTestingController.expectOne(`https://localhost:7096/api/Department/1`);
        expect(req.request.method).toBe('DELETE');
        req.flush({
            id: 1
        });
        httpTestingController.verify();
    });
});