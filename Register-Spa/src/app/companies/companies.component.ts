import { Component, OnInit } from '@angular/core';
import { Company } from '../_models/company';
import { CompanyService } from '../_services/company.service';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit {
new: boolean;
companies: Company[];
company: Company;

  constructor(private companyService: CompanyService) { }

  ngOnInit() {
    this.getCompanies();
  }

  fillCompany(company: Company){
    this.company = company;
    this.new = true;
  }

  searchCompanies(search){
    this.new = false;
    this.companyService.searchCompanies(search).subscribe((companies: Company[]) => {
      this.companies = companies;
    }, error => {
      console.log(error);
    });
  }

  getCompanies(){
    this.companyService.getCompanies().subscribe((companies: Company[]) => {
      this.companies = companies;
    }, error => {
      console.log(error);
    });
  }

  cancelEdit(state: boolean){
    this.getCompanies();
    this.new = state;
  }

  addCompany(){
    this.company = null;
    this.new = true;
  }
}
