import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Company } from '../_models/company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

  getCompanies(): Observable<Company[]> {
    return this.http.get<Company[]>(this.baseUrl + 'administration/getcompanies');
  }

  getCompany(id): Observable<Company> {
    return this.http.get<Company>(this.baseUrl + 'administration/getcompany/' + id);
  }

  searchCompanies(search): Observable<Company[]> {
    return this.http.get<Company[]>(this.baseUrl + 'administration/getcompanies/' + search);
  }

  addCompany(company: Company){
    return this.http.post(this.baseUrl + 'administration/addcompany', company);
  }

  updateCompany(company){

  }

  removeCompany(companyId: number){
    return this.http.delete(this.baseUrl + 'administration/removecompany/' + companyId);
  }
}
