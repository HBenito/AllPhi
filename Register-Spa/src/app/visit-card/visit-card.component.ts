import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Visit } from '../_models/visit';
import { RegisterService } from '../_services/register.service';

@Component({
  selector: 'app-visit-card',
  templateUrl: './visit-card.component.html',
  styleUrls: ['./visit-card.component.scss']
})
export class VisitCardComponent implements OnInit {
  @Input() visit: Visit;
  @Output() logVisitOut = new EventEmitter();

  constructor(private registerService: RegisterService) { }

  ngOnInit() {
  }

  logOut(){
    console.log(this.visit.id);
    this.registerService.logOut(this.visit.id).subscribe(data => {
      console.log("visit uitgelogd");
      this.logVisitOut.emit();
    }, error => {
      console.log(error);
    });  }

}
