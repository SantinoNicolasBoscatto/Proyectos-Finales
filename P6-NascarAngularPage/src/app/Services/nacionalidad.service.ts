import { inject, Injectable } from '@angular/core';
import { CrearNacionalidadDTO, LecturaNacionalidadDTO } from '../componentes/nacionalidad';
import { IServicioCRUD } from '../componentes/compartidos/interface/IServicioCRUD';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class NacionalidadService implements IServicioCRUD<LecturaNacionalidadDTO, CrearNacionalidadDTO>{
  httpClient = inject(HttpClient);
  urlBase: string = environment.Url+"nacionalidad";
  cargarRegistros(): Observable<LecturaNacionalidadDTO[]> {
    return this.httpClient.get<LecturaNacionalidadDTO[]>(this.urlBase);
  }
  obtenerRegistroPorId(id: number): Observable<LecturaNacionalidadDTO> {
    return this.httpClient.get<LecturaNacionalidadDTO>(`${this.urlBase}/${id}`);
  }
  crearRegistro(entidad: CrearNacionalidadDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.post(this.urlBase, formData);
  }
  editarRegistro(id: number, entidad: CrearNacionalidadDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.put(`${this.urlBase}/${id}`, formData);
  }
  borrarRegistro(id: number): Observable<any> {
    return this.httpClient.delete(`${this.urlBase}/${id}`);
  }

  private construirFormData(nacionDTO: CrearNacionalidadDTO): FormData{
    const formData = new FormData();
    formData.append('nombre', nacionDTO.nombre!);
    if(nacionDTO.bandera){
      formData.append('bandera', nacionDTO.bandera);
    }
    return formData;
  }
}
