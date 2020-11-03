import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from '../_models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  baseUrl = environment.apiUrl;


constructor(private http: HttpClient) { }

getEmployees(): Observable<Employee[]> {
  return this.http.get<Employee[]>(this.baseUrl + 'administration/getemployees');
}

searchemployees(search): Observable<Employee[]> {
  return this.http.get<Employee[]>(this.baseUrl + 'administration/getemployees/' + search);
}

addEmployee(employee: Employee){
  return this.http.post(this.baseUrl + 'administration/addemployee', employee);
}
removeEmployee(companyId: number){
  return this.http.delete(this.baseUrl + 'administration/removeemployee/' + companyId);
}
}
