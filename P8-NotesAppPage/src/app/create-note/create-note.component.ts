import { Component } from '@angular/core';
import { NoteFormsComponent } from "../note-forms/note-forms.component";

@Component({
  selector: 'app-create-note',
  standalone: true,
  imports: [NoteFormsComponent],
  templateUrl: './create-note.component.html',
  styleUrl: './create-note.component.css'
})
export class CreateNoteComponent {

}
