import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Visit } from '../_models/visit';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  addVisit(visit: Visit){
    return this.http.post(this.baseUrl + 'register/addvisit', visit);
  }

  getVisits(): Observable<Visit[]> {
    return this.http.get<Visit[]>(this.baseUrl + 'register/getvisits');
  }

  searchVisits(search): Observable<Visit[]> {
    return this.http.get<Visit[]>(this.baseUrl + 'register/getvisits/' + search);
  }

  logOut(id: number){
    return this.http.post(this.baseUrl + 'register/logout/' + id, {});
  }
}
