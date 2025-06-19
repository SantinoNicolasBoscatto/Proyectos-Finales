import { inject, Injectable } from '@angular/core';
import { IServicioCrud } from '../_interfaces/IServiceCRUD';
import { Category } from '../_interfaces/Category/Category';
import { CreateCategoryCommand } from '../_interfaces/Category/CreateCategoryCommand';
import { UpdateCategoryCommand } from '../_interfaces/Category/UpdateCategoryCommand';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService implements IServicioCrud<Category, CreateCategoryCommand, UpdateCategoryCommand> {

  urlBase = environment.endPoint + '/categories';
  httpClient = inject(HttpClient);
  constructor() { }
  get(): Observable<Category[]> {
    return this.httpClient.get<Category[]>(this.urlBase);
  }
  create(category: CreateCategoryCommand): Observable<any> {
    return this.httpClient.post(this.urlBase, category);
  }
  update(id: number, category: UpdateCategoryCommand): Observable<any> {
    return this.httpClient.put(`${this.urlBase}/${id}`, category);
  }
  delete(id: number): Observable<any> {
    return this.httpClient.delete(`${this.urlBase}/${id}`);
  }
}
