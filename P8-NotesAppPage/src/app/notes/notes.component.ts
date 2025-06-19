import { Component, inject, Input, input } from '@angular/core';
import { Note } from '../_interfaces/Note/Note';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';

@Component({
  selector: 'app-notes',
  standalone: true,
  imports: [MatButtonModule, MatIconModule],
  templateUrl: './notes.component.html',
  styleUrl: './notes.component.css'
})
export class NotesComponent {
  @Input({required: true})
  note!: Note;
  @Input({required: true})
  id!: number;
  countPendientes: number = 0;
  countExpirados: number = 0;
  private router = inject(Router);
  AumentarContador(contador: number){contador++;}

  navigateMenu(){
    this.router.navigate(["notedetail/"+this.id])
  }

  navigateEditNote(){
    this.router.navigate(["updateNote/"+this.id])
  }
  isButtonVisible = false; 
  showButton() { 
      this.isButtonVisible = true;
  } 
  hideButton() { 
      this.isButtonVisible = false; 
  }
}
