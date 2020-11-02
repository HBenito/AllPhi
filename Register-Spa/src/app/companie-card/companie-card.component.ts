import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Company } from '../_models/company';
import { CompanyService } from '../_services/company.service';

@Component({
  selector: 'app-companie-card',
  templateUrl: './companie-card.component.html',
  styleUrls: ['./companie-card.component.css']
})
export class CompanieCardComponent implements OnInit {
  @Input() company: Company;
  @Output() openCompany = new EventEmitter();
  @Output() removeCompany = new EventEmitter();

  constructor(private companyService: CompanyService) { }

  ngOnInit() {
  }

  Open(){
    this.openCompany.emit(this.company);
  }
  Remove(){
    console.log(this.company.id);
    this.companyService.removeCompany(this.company.id).subscribe(data => {
      console.log("company verwijderd");
      this.removeCompany.emit();
    }, error => {
      console.log(error);
    });  }

}
