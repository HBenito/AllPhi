import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Employee } from '../_models/employee';
import { EmployeeService } from '../_services/employee.service';

@Component({
  selector: 'app-empolyee-card',
  templateUrl: './empolyee-card.component.html',
  styleUrls: ['./empolyee-card.component.scss']
})
export class EmpolyeeCardComponent implements OnInit {
  @Input() employee: Employee;
  @Output() openEmployee = new EventEmitter();
  @Output() removeEmployee = new EventEmitter();

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
  }

  Open(){
    this.openEmployee.emit(this.employee);
  }
  Remove(){
    console.log(this.employee.id);
    this.employeeService.removeEmployee(this.employee.id).subscribe(data => {
      console.log("employee verwijderd");
      this.removeEmployee.emit();
    }, error => {
      console.log(error);
    });  }

}
