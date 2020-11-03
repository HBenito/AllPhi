import { Component, OnInit } from '@angular/core';
import { Company } from '../_models/company';
import { Employee } from '../_models/employee';
import { CompanyService } from '../_services/company.service';
import { EmployeeService } from '../_services/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  new: boolean;
  employees: Employee[];
  employee: Employee;
  
    constructor(private employeeService: EmployeeService) { }
  
    ngOnInit() {
      this.getEmployees();
    }
  
    fillCompany(employee: Employee){
      this.employee = employee;
      this.new = true;
    }
  
    searchEmployees(search){
      this.new = false;
      this.employeeService.searchemployees(search).subscribe((employees: Employee[]) => {
        this.employees = employees;
      }, error => {
        console.log(error);
      });
    }
  
    getEmployees(){
      this.employeeService.getEmployees().subscribe((employees: Employee[]) => {
        this.employees = employees;
      }, error => {
        console.log(error);
      });
    }
  
    cancelEdit(state: boolean){
      this.getEmployees();
      this.new = state;
    }
  
    addCompany(){
      this.employee = null;
      this.new = true;
    }
}
