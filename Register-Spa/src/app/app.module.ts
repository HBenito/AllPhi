import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AdministrationComponent } from './administration/administration.component';
import { RegisterComponent } from './register/register.component';
import { appRoutes } from './routes';
import { CompaniesComponent } from './companies/companies.component';
import { CompanieCardComponent } from './companie-card/companie-card.component';
import { CompanyEditComponent } from './company-edit/company-edit.component';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeeEditComponent } from './employee-edit/employee-edit.component';
import { EmpolyeeCardComponent } from './empolyee-card/empolyee-card.component';
import { VisitsComponent } from './visits/visits.component';
import { VisitCardComponent } from './visit-card/visit-card.component';

@NgModule({
  declarations: [										
    AppComponent,
      NavComponent,
      AdministrationComponent,
      RegisterComponent,
      CompaniesComponent,
      CompanieCardComponent,
      CompanyEditComponent,
      EmployeesComponent,
      EmployeeEditComponent,
      EmpolyeeCardComponent,
      VisitsComponent,
      VisitCardComponent
   ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
