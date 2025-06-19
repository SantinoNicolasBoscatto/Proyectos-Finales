import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Note } from '../_interfaces/Note/Note';
import { environment } from '../../environments/environment';
import { CreateNoteCommand } from '../_interfaces/Note/CreateNoteCommand';
import { UpdateNoteCommand } from '../_interfaces/Note/UpdateNoteCommand';
import { IServicioCrud } from '../_interfaces/IServiceCRUD';

@Injectable({
  providedIn: 'root'
})
export class NoteService implements IServicioCrud<Note, CreateNoteCommand, UpdateNoteCommand> {
  constructor() { }
  urlBase = environment.endPoint + '/notes';
  httpClient = inject(HttpClient);
  public get() : Observable<Note[]>{
    return this.httpClient.get<Note[]>(this.urlBase);
  }

  public getById(id:number) : Observable<Note>{
    return this.httpClient.get<Note>(`${this.urlBase}/${id}`);
  }

  public getNotesCategoryName(id: number, name: string): Observable<Note[]> 
  { 
    const params = new HttpParams().set('id', id.toString()) .set('name', name); 
    return this.httpClient.get<Note[]>(`${this.urlBase}/filter`, { params });
  }
  
  public create(note: CreateNoteCommand){
    let form = this.construirFormDataCreate(note);
    return this.httpClient.post(this.urlBase, form);
  }

  public update(id: number, note: UpdateNoteCommand){
    let form = this.construirFormDataUpdate(note);
    return this.httpClient.put(`${this.urlBase}/${id}`, form);
  }

  public delete(id: number){
    return this.httpClient.delete(`${this.urlBase}/${id}`);
  }

  private construirFormDataUpdate(note: UpdateNoteCommand): FormData{
      const formData = new FormData();
      formData.append('identityUserId', note.identityUserId);
      formData.append('name', note.name);
      formData.append('id', note.id.toString());
      formData.append('categoryId', note.categoryId.toString());
      return formData;
  }

  private construirFormDataCreate(note: CreateNoteCommand): FormData{
    const formData = new FormData();
    formData.append('identityUserId', note.identityUserId);
    formData.append('name', note.name);
    formData.append('categoryId', note.categoryId.toString());
    return formData;
  }
}
