import { Component, Input, numberAttribute, OnInit } from '@angular/core';
import { TodotaskFormsComponent } from "../todotask-forms/todotask-forms.component";

@Component({
  selector: 'app-createtodotask',
  standalone: true,
  imports: [TodotaskFormsComponent],
  templateUrl: './createtodotask.component.html',
  styleUrl: './createtodotask.component.css'
})
export class CreatetodotaskComponent {

}
