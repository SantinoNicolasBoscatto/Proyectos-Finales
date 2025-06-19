import { inject, Injectable } from '@angular/core';
import { Priority } from '../_interfaces/Priority/Priority';
import { CreatePriorityCommand } from '../_interfaces/Priority/CreatePriorityCommand';
import { UpdatePriorityCommand } from '../_interfaces/Priority/UpdatePriorityCommand';
import { IServicioCrud } from '../_interfaces/IServiceCRUD';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PriorityService implements IServicioCrud<Priority, CreatePriorityCommand, UpdatePriorityCommand> {

  urlBase = environment.endPoint + '/priorities';
  httpClient = inject(HttpClient);
  constructor() { }
  get(): Observable<Priority[]> {
    return this.httpClient.get<Priority[]>(this.urlBase);
  }
  create(priority: CreatePriorityCommand): Observable<any> {
    return this.httpClient.post(this.urlBase, priority);
  }
  update(id: number, priority: UpdatePriorityCommand): Observable<any> {
    return this.httpClient.put(`${this.urlBase}/${id}`, priority);
  }
  delete(id: number): Observable<any> {
    return this.httpClient.delete(`${this.urlBase}/${id}`);
  }
}
