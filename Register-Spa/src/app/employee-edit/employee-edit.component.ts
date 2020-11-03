import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employee } from '../_models/employee';
import { EmployeeService } from '../_services/employee.service';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.scss']
})
export class EmployeeEditComponent implements OnInit {
  @Output() cancelEdit = new EventEmitter();
  @Input() employee: Employee;
  saveEmployeeForm: FormGroup;


  constructor(private employeeService: EmployeeService, private fb: FormBuilder) { }

  ngOnInit() {
    if(this.employee != null && this.employee.id != null){
      console.log(this.employee.id);
    }
    else{
      console.log('id not found');
    }
    this.createSaveCompanyForm();
  }

  createSaveCompanyForm(){
    this.saveEmployeeForm = this.fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]]
    });
  }

  cancel(){
    console.log("cancel card");
    this.cancelEdit.emit(false);
  }

  save(){
    if (this.employee != null && this.employee.id != null){
    }
    else{
      if (this.saveEmployeeForm.valid){
        this.employee = Object.assign({}, this.saveEmployeeForm.value);
        this.employeeService.addEmployee(this.employee).subscribe((employee: Employee) => {
          this.employee = employee;
          console.log(this.employee.id)
        }, error => {
          console.log(error);
        });
      }
      console.log(this.saveEmployeeForm.value);
    }
  }

  addEmployee(){

  }

  addNewEmployee(){
    
  }

}
