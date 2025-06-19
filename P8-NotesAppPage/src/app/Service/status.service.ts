import { inject, Injectable } from '@angular/core';
import { Status } from '../_interfaces/Status/Status';
import { CreateStatusCommand } from '../_interfaces/Status/CreateStatusCommand';
import { UpdateNoteCommand } from '../_interfaces/Note/UpdateNoteCommand';
import { IServicioCrud } from '../_interfaces/IServiceCRUD';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StatusService implements IServicioCrud<Status, CreateStatusCommand, UpdateNoteCommand> {

  urlBase = environment.endPoint + '/status';
  httpClient = inject(HttpClient);
  constructor() { }
  get(): Observable<Status[]> {
    return this.httpClient.get<Status[]>(this.urlBase);
  }
  create(status: CreateStatusCommand): Observable<any> {
    return this.httpClient.post(this.urlBase, status);
  }
  update(id: number, status: UpdateNoteCommand): Observable<any> {
    return this.httpClient.put(`${this.urlBase}/${id}`, status);
  }
  delete(id: number): Observable<any> {
    return this.httpClient.delete(`${this.urlBase}/${id}`);
  }
}
