import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { NotesComponent } from './notes/notes.component';
import { NotesMenuComponent } from './notes-menu/notes-menu.component';
import { NoteDetailComponent } from './note-detail/note-detail.component';
import { CreatetodotaskComponent } from './createtodotask/createtodotask.component';
import { UpdatetodotaskComponent } from './updatetodotask/updatetodotask.component';
import { CreateNoteComponent } from './create-note/create-note.component';
import { UpdateNoteComponent } from './update-note/update-note.component';
import { estaLogueadoGuard, noEstaLogueadoGuard } from './guards/esta-logueado.guard';

export const routes: Routes = [
    {path: '', component: LoginComponent, canActivate: [noEstaLogueadoGuard]},
    {path: 'menu', component: NotesMenuComponent, canActivate: [estaLogueadoGuard]},
    {path: 'notedetail/:id', component: NoteDetailComponent, canActivate: [estaLogueadoGuard]},
    
    {path: 'addNote', component: CreateNoteComponent, canActivate: [estaLogueadoGuard]},
    {path: 'updateNote/:id', component: UpdateNoteComponent, canActivate: [estaLogueadoGuard]},
    {path: 'notedetail/:noteid/addtask', component: CreatetodotaskComponent, canActivate: [estaLogueadoGuard]},
    {path: 'notedetail/:noteid/updatetask/:id', component: UpdatetodotaskComponent, canActivate: [estaLogueadoGuard]},
    {path: '**', component: LoginComponent, canActivate: [noEstaLogueadoGuard]},
];