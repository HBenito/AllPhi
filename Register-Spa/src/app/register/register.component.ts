import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Company } from '../_models/company';
import { Employee } from '../_models/employee';
import { Visit } from '../_models/visit';
import { CompanyService } from '../_services/company.service';
import { RegisterService } from '../_services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  visit: Visit;
  state: number;
  company: Company;
  companies: Company[];
  employee: Employee;
  employees: Employee[];

  constructor(private fb: FormBuilder, private companyService: CompanyService, private registerService: RegisterService) { }

  ngOnInit() {
    this.createRegisterForm();
    this.state = 0;
  }

  createRegisterForm(){
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      date: [null, Validators.required]
    });
  }

  next(){
    if (this.registerForm.valid){
      this.visit = Object.assign({}, this.registerForm.value);
    }
    this.state = 1;
    console.log(this.visit);
  }

  searchCompanies(search){
    this.companyService.searchCompanies(search).subscribe((companies: Company[]) => {
      this.companies = companies;
    }, error => {
      console.log(error);
    });
  }

  addCompany(company: Company){
    this.company = company;
    this.visit.companyId = company.id;
    this.companyService.getCompanyEmployees(company.id).subscribe((employees: Employee[]) => {
      this.employees = employees;
      console.log(this.employees);
    }, error => {
      console.log(error);
    });
    this.state = 2;
  }

  addEmployee(employee: Employee){
    this.employee = employee;
    this.visit.employeeId = employee.id;
    this.state = 3;
    console.log(this.visit);
  }

  save(){
    this.registerService.addVisit(this.visit).subscribe((visit: Visit) => {
      this.visit = visit;
      console.log(this.visit.id)
    }, error => {
      console.log(error);
    });
    this.registerForm = null;
    this.visit =null;
    this.companies = null;
    this.company = null;
    this.employee = null;
    this.employees = null;
    this.state = 0;
  }

}
