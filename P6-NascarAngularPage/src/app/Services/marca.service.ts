import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CrearMarcaDTO, LecturaMarcaDTO } from '../componentes/LecturaMarcaDTO';
import { IServicioCRUD } from '../componentes/compartidos/interface/IServicioCRUD';

@Injectable({
  providedIn: 'root'
})
export class MarcaService implements IServicioCRUD<LecturaMarcaDTO, CrearMarcaDTO> {
  
  urlBase: string = environment.Url+"marcas";
  httpClient = inject(HttpClient);

  cargarRegistros() : Observable<LecturaMarcaDTO[]>{
    return this.httpClient.get<LecturaMarcaDTO[]>(`${this.urlBase}`);
  }
  obtenerRegistroPorId(id: number): Observable<LecturaMarcaDTO> {
    return this.httpClient.get<LecturaMarcaDTO>(`${this.urlBase}/${id}`);
  }
  crearRegistro(entidad: CrearMarcaDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.post(this.urlBase, formData);
  }
  editarRegistro(id: number, entidad: CrearMarcaDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    console.log(entidad)
    return this.httpClient.put(`${this.urlBase}/${id}`, formData);
  }
  borrarRegistro(id: number): Observable<any> {
    return this.httpClient.delete(`${this.urlBase}/${id}`);
  }

  private construirFormData(marcaDTO: CrearMarcaDTO): FormData{
    const formData = new FormData();
    formData.append('nombre', marcaDTO.nombre!);
    if(marcaDTO.foto){
      formData.append('foto', marcaDTO.foto);
    }
    return formData;
  }
}
