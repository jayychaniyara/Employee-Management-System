import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../model/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  readonly APIUrl = "https://localhost:7096/api";

  constructor(private http : HttpClient) { }

  getEmployeeList() : Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Employee');
  }

  addEmployee(val : Employee){
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.post<Employee>(this.APIUrl+'/Employee', JSON.stringify(val), {headers: headers});
  }

  updateEmployee(val : Employee){
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.put(this.APIUrl+'/Employee', JSON.stringify(val), {headers: headers});
  }

  deleteEmployee(id: number){
    return this.http.delete(this.APIUrl+`/Employee/${id}`);
  }
}
