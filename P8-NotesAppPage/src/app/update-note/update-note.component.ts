import { Component, inject, Input, numberAttribute, OnInit } from '@angular/core';
import { NoteFormsComponent } from "../note-forms/note-forms.component";
import { UpdateNoteCommand } from '../_interfaces/Note/UpdateNoteCommand';


@Component({
  selector: 'app-update-note',
  standalone: true,
  imports: [NoteFormsComponent],
  templateUrl: './update-note.component.html',
  styleUrl: './update-note.component.css'
})
export class UpdateNoteComponent  {
  model!: UpdateNoteCommand;
}
