import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Company } from '../_models/company';
import { CompanyService } from '../_services/company.service';

@Component({
  selector: 'app-company-edit',
  templateUrl: './company-edit.component.html',
  styleUrls: ['./company-edit.component.css']
})
export class CompanyEditComponent implements OnInit {
  @Output() cancelEdit = new EventEmitter();
  @Input() company: Company;
  saveCompanyForm: FormGroup;


  constructor(private companyService: CompanyService, private fb: FormBuilder) { }

  ngOnInit() {
    if(this.company != null && this.company.id != null){
      console.log(this.company.id);
    }
    else{
      console.log('id not found');
    }
    this.createSaveCompanyForm();
  }

  createSaveCompanyForm(){
    this.saveCompanyForm = this.fb.group({
      name: ['', [Validators.required]],
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

  addEmployee(){

  }

  addNewEmployee(){
    
  }

}
