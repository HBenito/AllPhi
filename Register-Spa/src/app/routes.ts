import { Routes } from '@angular/router';
import { AdministrationComponent } from './administration/administration.component';
import { RegisterComponent } from './register/register.component';

export const appRoutes: Routes = [
    { path: 'register', component: RegisterComponent},
    { path: 'administration', component: AdministrationComponent},
    { path: '**', redirectTo: 'register', pathMatch: 'full'}
]