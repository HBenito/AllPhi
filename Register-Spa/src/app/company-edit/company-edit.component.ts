import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Company } from '../_models/company';
import { Employee } from '../_models/employee';
import { CompanyService } from '../_services/company.service';
import { EmployeeService } from '../_services/employee.service';

@Component({
  selector: 'app-company-edit',
  templateUrl: './company-edit.component.html',
  styleUrls: ['./company-edit.component.css']
})
export class CompanyEditComponent implements OnInit {
  @Output() cancelEdit = new EventEmitter();
  @Input() company: Company;
  employees: Employee[];
  companyEmployees: Employee[];
  saveCompanyForm: FormGroup;
  addEmployeeState: number;


  constructor(private companyService: CompanyService, private fb: FormBuilder, private employeeService: EmployeeService) { }

  ngOnInit() {
    if(this.company != null && this.company.id != null){
      console.log(this.company.id);
    }
    else{
      console.log('id not found');
    }
    this.createSaveCompanyForm();
    this.setAddEmployeeState(0);
    this.getCompanyEmployees();
  }

  createSaveCompanyForm(){
    this.saveCompanyForm = this.fb.group({
      name: ['', [Validators.required]],
    });
  }

  getCompanyEmployees(){
    this.companyService.getCompanyEmployees(this.company.id).subscribe((employees: Employee[]) => {
      this.companyEmployees = employees;
      console.log(this.companyEmployees);
    }, error => {
      console.log(error);
    });
  }

  cancel(){
    console.log("cancel card");
    this.cancelEdit.emit(false);
  }

  save(){
    if (this.company != null && this.company.id != null){
    }
    else{
      if (this.saveCompanyForm.valid){
        this.company = Object.assign({}, this.saveCompanyForm.value);
        this.companyService.addCompany(this.company).subscribe((company: Company) => {
          this.company = company;
          console.log(this.company.id)
        }, error => {
          console.log(error);
        });
      }
      console.log(this.saveCompanyForm.value);
    }
  }

  setAddEmployeeState(state: number){
    this.addEmployeeState = state;
    this.employees = null;
  }

  searchEmployees(search){
    this.employeeService.searchemployees(search).subscribe((employees: Employee[]) => {
      this.employees = employees;
    }, error => {
      console.log(error);
    });
  }

  add(employee: Employee){
    this.companyService.addEmployeeToCompany(this.company.id, employee.id).subscribe((employees: Employee[]) => {
      this.employees = employees;
    }, error => {
      console.log(error);
    });
  }

  addEmployee(){

  }

  addNewEmployee(){

  }

}
