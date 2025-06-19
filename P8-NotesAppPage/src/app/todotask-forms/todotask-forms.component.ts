import { AfterViewInit, Component, inject, Input, numberAttribute, OnInit } from '@angular/core'; 
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators, FormControl, NgModel } from '@angular/forms'; 
import { MatFormFieldModule } from '@angular/material/form-field'; 
import { MatInputModule } from '@angular/material/input'; 
import { MatSelectModule } from '@angular/material/select'; 
import { MatDatepickerModule } from '@angular/material/datepicker'; 
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { UpdateToDoTaskCommand } from '../_interfaces/ToDoTask/UpdateToDoTaskCommand';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { StatusService } from '../Service/status.service';
import { PriorityService } from '../Service/priority.service';
import { Priority } from '../_interfaces/Priority/Priority';
import { Status } from '../_interfaces/Status/Status';
import { ToDoTaskService } from '../Service/to-do-task.service';
import { CreateToDoTaskCommand } from '../_interfaces/ToDoTask/CreateToDoTaskCommand';
import { _isNumberValue } from '@angular/cdk/coercion';
import { ToDoTask } from '../_interfaces/ToDoTask/ToDoTask';

@Component({
  selector: 'app-todotask-forms',
  standalone: true,
  imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatDatepickerModule, MatNativeDateModule, 
    MatButtonModule, RouterLink],
  templateUrl: './todotask-forms.component.html',
  styleUrl: './todotask-forms.component.css'
})
export class TodotaskFormsComponent implements OnInit,AfterViewInit {
  ngAfterViewInit(): void {
    this.activatedRoute.params.subscribe(params => { this.id = +params['id'];  });
    if(_isNumberValue(this.id)){
      this.taskService.getById(this.id).subscribe((res: ToDoTask)=>{
          this.model = {name: res.name!, noteId: res.noteId, priorityId: res.priorityId, statusId: res.statusId, toDoTaskId: this.id,
          dateLimit: res.dateLimit, identityUserId: ""}
          this.statusService.get().subscribe((res: Status[])=> {
            this.listStatus = res;
            this.selectedStatus = this.model!.statusId;
          });
          this.priorityService.get().subscribe((res: Priority[])=> {
            this.listPriority = res;
            this.selectedPriority = this.model!.priorityId;
          });
          this.form.patchValue(this.model);
      });
    }
    else{
      this.statusService.get().subscribe((res: Status[])=> {
        this.listStatus = res;
        this.selectedStatus = this.listStatus[0].id;
      });
      this.priorityService.get().subscribe((res: Priority[])=> {
        this.listPriority = res;
        this.selectedPriority = this.listPriority[0].id;
      });
    }
  }
    ngOnInit(): void { 
    this.activatedRoute.params.subscribe(params => { this.noteid = +params['noteid'];  });
  }
  @Input()
  model!: UpdateToDoTaskCommand | undefined;
  @Input({required: true})
  Titulo!: string;
  @Input({required: true})
  ButtonName!: string;
  @Input({transform: numberAttribute})
  noteid! : number;
  @Input({transform: numberAttribute})
  id! : number;
  private formBuilder = inject(FormBuilder);
  private activatedRoute = inject(ActivatedRoute);
  private route = inject(Router);
  private statusService = inject(StatusService);
  private priorityService = inject(PriorityService);
  private taskService = inject(ToDoTaskService);
  selectedStatus!: number;
  selectedPriority!: number;
  listStatus!: Status[];
  listPriority!: Priority[];

  form = this.formBuilder.group({
    name: ['', {validators: [Validators.required, Validators.maxLength(50)]}], 
    dateLimit: ['', {validators: [Validators.required]}], 
    priority: ['', {validators: [Validators.required]}], 
    status: ['', {validators: [Validators.required]}]
  });

  guardarCambios(){
    if(_isNumberValue(this.id)){
      let toDo: UpdateToDoTaskCommand = {noteId: this.noteid, name: this.form.controls.name.value!, 
        priorityId: Number(this.form.controls.priority.value), statusId: Number(this.form.controls.status.value), 
        dateLimit: this.form.controls.dateLimit.value, identityUserId: "", toDoTaskId: this.id }
        this.taskService.update(this.id,toDo).subscribe({
          next:()=>{
            this.route.navigate([`notedetail/${this.noteid}`])
          },
          error:()=>{
            alert("Error al updatear ToDo");
          }
        });
    }
    else{
      let toDo: CreateToDoTaskCommand = {noteId: this.noteid, name: this.form.controls.name.value!, 
        priorityId: Number(this.form.controls.priority.value), statusId: Number(this.form.controls.status.value), 
        dateLimit: this.form.controls.dateLimit.value, identityUserId: "" }
        this.taskService.create(toDo).subscribe({
          next:()=>{
            this.route.navigate([`notedetail/${this.noteid}`])
          },
          error:()=>{
            alert("Error al crear ToDo");
          }
        });
    }
  }

  ErrorCampoGenerico(control: FormControl): string {
    if (control.hasError('required')) {
      return "Por favor complete este campo";
    }
    if (control.hasError('maxlength')) {
      return `El texto excede el límite de longitud permitido (${control.getError('maxlength').requiredLength} caracteres)`;
    }
    return "";
  }
  
  
}
