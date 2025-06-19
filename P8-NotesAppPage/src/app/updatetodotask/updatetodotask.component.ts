import { Component, inject, Input, numberAttribute, OnInit } from '@angular/core';
import { TodotaskFormsComponent } from "../todotask-forms/todotask-forms.component";
import { UpdateToDoTaskCommand } from '../_interfaces/ToDoTask/UpdateToDoTaskCommand';
import { ToDoTaskService } from '../Service/to-do-task.service';
import { ActivatedRoute } from '@angular/router';
import { ToDoTask } from '../_interfaces/ToDoTask/ToDoTask';

@Component({
  selector: 'app-updatetodotask',
  standalone: true,
  imports: [TodotaskFormsComponent],
  templateUrl: './updatetodotask.component.html',
  styleUrl: './updatetodotask.component.css'
})
export class UpdatetodotaskComponent {
  model!: UpdateToDoTaskCommand;
}
