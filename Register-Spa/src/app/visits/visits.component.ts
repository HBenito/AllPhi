import { Component, OnInit } from '@angular/core';
import { Visit } from '../_models/visit';
import { RegisterService } from '../_services/register.service';

@Component({
  selector: 'app-visits',
  templateUrl: './visits.component.html',
  styleUrls: ['./visits.component.css']
})
export class VisitsComponent implements OnInit {
  visits: Visit[];

    constructor(private registerService: RegisterService) { }
 
    ngOnInit() {
      this.getVisits();
    }

    searchVisits(search){
      this.registerService.searchVisits(search).subscribe((visits: Visit[]) => {
        this.visits = visits;
      }, error => {
        console.log(error);
      });
    }

    getVisits(){
      this.registerService.getVisits().subscribe((visits: Visit[]) => {
        this.visits = visits;
      }, error => {
        console.log(error);
      });
    }
}
