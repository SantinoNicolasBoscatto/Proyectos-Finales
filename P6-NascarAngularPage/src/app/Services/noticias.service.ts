import { inject, Injectable } from '@angular/core';
import { IServicioCRUD } from '../componentes/compartidos/interface/IServicioCRUD';
import { CrearNoticiaDTO, LecturaNoticiaDTO } from '../componentes/NoticiaDTO';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NoticiasService implements IServicioCRUD<LecturaNoticiaDTO, CrearNoticiaDTO> {
  urlBase: string = environment.Url+"noticias";
  httpClient = inject(HttpClient);

  cargarRegistros(): Observable<LecturaNoticiaDTO[]> {
    return this.httpClient.get<LecturaNoticiaDTO[]>(this.urlBase);
  }
  cargarRegistrosBig(): Observable<LecturaNoticiaDTO[]> {
    return this.httpClient.get<LecturaNoticiaDTO[]>(this.urlBase+"/big");
  }
  cargarRegistrosHalf(): Observable<LecturaNoticiaDTO[]> {
    return this.httpClient.get<LecturaNoticiaDTO[]>(this.urlBase+"/half");
  }
  obtenerRegistroPorId(id: number): Observable<LecturaNoticiaDTO> {
    return this.httpClient.get<LecturaNoticiaDTO>(`${this.urlBase}/${id}`);
  }
  crearRegistro(entidad: CrearNoticiaDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.post(this.urlBase, formData);
  }
  editarRegistro(id: number, entidad: CrearNoticiaDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.put(`${this.urlBase}/${id}`, formData);
  }
  borrarRegistro(id: number): Observable<any> {
    return this.httpClient.delete(`${this.urlBase}/${id}`);
  }

  private construirFormData(noticiaDTO: CrearNoticiaDTO): FormData{
    const formData = new FormData();
    noticiaDTO.detalles = noticiaDTO.detalles? noticiaDTO.detalles : "";
    formData.append('titulo', noticiaDTO.titulo!);
    formData.append('detalles', noticiaDTO.detalles);
    if(noticiaDTO.foto){
      formData.append('foto', noticiaDTO.foto);
    }
    return formData;
  }
}
