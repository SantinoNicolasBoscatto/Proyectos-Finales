import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ToDoTask } from '../_interfaces/ToDoTask/ToDoTask';
import { Observable } from 'rxjs';
import { CreateToDoTaskCommand } from '../_interfaces/ToDoTask/CreateToDoTaskCommand';
import { UpdateToDoTaskCommand } from '../_interfaces/ToDoTask/UpdateToDoTaskCommand';
import { IServicioCrud } from '../_interfaces/IServiceCRUD';

@Injectable({
  providedIn: 'root'
})
export class ToDoTaskService implements IServicioCrud<ToDoTask, CreateToDoTaskCommand, UpdateToDoTaskCommand> {
  constructor() { }
  urlBase = environment.endPoint + '/notes/todotask';
  httpClient = inject(HttpClient);
  
  public get() : Observable<ToDoTask[]>{
    return this.httpClient.get<ToDoTask[]>(this.urlBase);
  }

  public getById(id:number) : Observable<ToDoTask>{
    return this.httpClient.get<ToDoTask>(`${this.urlBase}/task/${id}`);
  }

  public create(toDo: CreateToDoTaskCommand){
    let noteId = toDo.noteId;
    let formData = this.construirFormDataCreate(toDo);
    return this.httpClient.post(`${this.urlBase}/${noteId}`, formData);
  }
  
  public update(id: number, toDo: UpdateToDoTaskCommand){
    toDo.toDoTaskId = id;
    let formData = this.construirFormDataUpdate(toDo);
    return this.httpClient.put(`${this.urlBase}/${id}`, formData);
  }
  
  public delete(id: number){
    return this.httpClient.delete(`${this.urlBase}/${id}`);
  }

  private construirFormDataCreate(toDo: CreateToDoTaskCommand): FormData{
      const formData = new FormData();
      formData.append('identityUserId', toDo.identityUserId);
      formData.append('noteId', toDo.noteId.toString());
      formData.append('name', toDo.name);
      formData.append('dateLimit', new Date(toDo.dateLimit!).toISOString());
      formData.append('priorityId', toDo.priorityId.toString());
      formData.append('statusId', toDo.statusId.toString());
      return formData;
  }

  private construirFormDataUpdate(toDo: UpdateToDoTaskCommand): FormData{
    const formData = new FormData();
    formData.append('identityUserId', toDo.identityUserId);
    formData.append('noteId', toDo.noteId.toString());
    formData.append('name', toDo.name);
    formData.append('dateLimit', new Date(toDo.dateLimit!).toISOString());
    formData.append('priorityId', toDo.priorityId.toString());
    formData.append('statusId', toDo.statusId.toString());
    formData.append('toDoTaskId', toDo.toDoTaskId.toString());
    return formData;
  }
}
