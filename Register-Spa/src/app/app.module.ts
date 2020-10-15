import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AdministrationComponent } from './administration/administration.component';
import { RegisterComponent } from './register/register.component';
import { appRoutes } from './routes';

@NgModule({
  declarations: [		
    AppComponent,
      NavComponent,
      AdministrationComponent,
      RegisterComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
