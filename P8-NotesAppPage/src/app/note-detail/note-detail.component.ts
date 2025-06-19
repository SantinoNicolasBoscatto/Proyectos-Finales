import { Component, inject, Input, numberAttribute, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button'
import { RouterLink } from '@angular/router';
import { NoteService } from '../Service/note.service';
import { Note } from '../_interfaces/Note/Note';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { ToDoTaskService } from '../Service/to-do-task.service';
import { UpdateToDoTaskCommand } from '../_interfaces/ToDoTask/UpdateToDoTaskCommand';
import { ToDoTask } from '../_interfaces/ToDoTask/ToDoTask';
@Component({
  selector: 'app-note-detail',
  standalone: true,
  imports: [ MatButtonModule, RouterLink, SweetAlert2Module],
  templateUrl: './note-detail.component.html',
  styleUrl: './note-detail.component.css'
})
export class NoteDetailComponent implements OnInit {
    ngOnInit(): void {
      this.getByIdNote();
    }
    @Input({transform: numberAttribute})
    id! : number;
    note!: Note;
    private noteService = inject(NoteService);
    private toDoTaskService = inject(ToDoTaskService);

    borrarTarea(id: number){
      this.toDoTaskService.delete(id).subscribe({
        next:()=>{
          this.getByIdNote();
        },
        error:()=>{
          alert("ERROR NOTE-DETAIL");
        }
      })
    }

    tacharListado(item: MouseEvent, taskId: number){
      const elemento = item.target as HTMLElement; 
      elemento.classList.toggle('tachado');
      let update: UpdateToDoTaskCommand;
      this.toDoTaskService.getById(taskId).subscribe({
        next:(res: ToDoTask)=>{
          let status!: number;
          const dateLimit = new Date(res.dateLimit!); 
          const currentDate = new Date();
          if(res.statusId != 3) status = 3;
          else if(dateLimit<currentDate) status = 2;
          else status = 1;
          update = {toDoTaskId: taskId, name: res.name!, noteId: res.noteId, priorityId: res.priorityId, dateLimit: res.dateLimit,
            statusId: status, identityUserId: ""}
          this.toDoTaskService.update(taskId, update).subscribe({
            next:()=>{
              if(res.statusId != 3){
                setTimeout(() => {
                  this.getByIdNote();
                }, 850);
              }
              else this.getByIdNote();
            },
            error:(err)=>{
              alert("Error Update")
              console.log(err)
            }
          });
        },
        error:()=>{
          alert("Error al GetId")
        }
      });
    }

    ActivarBorrado(){
      let listAction = document.querySelectorAll(".action-container");
      listAction.forEach(item => {
        item.classList.toggle('active');
      });
    }

    getByIdNote(){
      this.noteService.getById(this.id).subscribe({
        next:(respuesta: Note) => {
          this.note = respuesta;
        },
        error:() => {
          alert("ERROR");
        }
      })
    }
}
