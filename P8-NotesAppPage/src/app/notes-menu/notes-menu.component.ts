import {Component, inject, OnInit} from '@angular/core';
import {FormBuilder, FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { NotesComponent } from '../notes/notes.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Router, RouterLink } from '@angular/router';
import { UsersService } from '../Service/users.service';
import { NoteService } from '../Service/note.service';
import { Note } from '../_interfaces/Note/Note';
import { Category } from '../_interfaces/Category/Category';
import { CategoryService } from '../Service/category.service';


@Component({
  selector: 'app-notes-menu',
  standalone: true,
  imports: [NotesComponent, FormsModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule, MatIconModule, 
    RouterLink, ReactiveFormsModule],
  templateUrl: './notes-menu.component.html',
  styleUrl: './notes-menu.component.css'
})
export class NotesMenuComponent implements OnInit {

  ngOnInit(): void {
    this.noteService.get().subscribe((respuesta: Note[]) => {
      this.listaNotes = respuesta;
    })
    this.categoryService.get().subscribe((respuesta: Category[]) =>{
      this.listaCategorias = respuesta;
    })
  }
  private userService = inject(UsersService); 
  private router = inject(Router);
  private noteService = inject(NoteService);
  private categoryService = inject(CategoryService);
  private formBuilder = inject(FormBuilder);
  listaNotes!: Note[];
  listaCategorias!: Category[];
  form = this.formBuilder.group( //=> con Group puedo definir los campos de mi formulario
  {
      buscar: [''],
      categoriaId: ['']
  });

  Buscar(){
    let id = (this.form.controls.categoriaId != null)? Number(this.form.controls.categoriaId.value) : 0;
    let name = (this.form.controls.buscar != null)? this.form.controls.buscar.value : "";
    this.noteService.getNotesCategoryName(id, name!).subscribe({
      next: (respuesta: Note[])=>{
        this.listaNotes = respuesta;
      },
      error:()=>{
        alert("ERROR");
      }
    })
  }

  LogOut(){
    this.userService.logOut();
    this.router.navigate(['']);
  }
}
