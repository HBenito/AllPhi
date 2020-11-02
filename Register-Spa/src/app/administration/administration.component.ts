import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-administration',
  templateUrl: './administration.component.html',
  styleUrls: ['./administration.component.css']
})
export class AdministrationComponent implements OnInit {

  showTabNr: any;

  constructor() { }

  ngOnInit() {
    this.showTabNr = 1;
  }

  showTab(number){
    this.showTabNr = number;
  }

}
