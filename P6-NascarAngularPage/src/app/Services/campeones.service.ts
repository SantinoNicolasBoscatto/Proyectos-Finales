import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CrearCampeonDTO, LecturaCampeonDTO } from '../componentes/campeones/LecturaCampeonDTO';
import { IServicioCRUD } from '../componentes/compartidos/interface/IServicioCRUD';

@Injectable({
  providedIn: 'root'
})
export class CampeonesService implements IServicioCRUD<LecturaCampeonDTO, CrearCampeonDTO> {
  
  urlBase: string = environment.Url+"campeones";
  httpClient = inject(HttpClient);

  cargarRegistros() : Observable<LecturaCampeonDTO[]> {
    return this.httpClient.get<LecturaCampeonDTO[]>(`${this.urlBase}`);
  }

  obtenerRegistroPorId(id: number): Observable<LecturaCampeonDTO> {
    return this.httpClient.get<LecturaCampeonDTO>(`${this.urlBase}/${id}`);
  }
  crearRegistro(entidad: CrearCampeonDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.post(`${this.urlBase}`, formData);
  }
  editarRegistro(id: number, entidad: CrearCampeonDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.put(`${this.urlBase}/${id}`, formData);
  }
  borrarRegistro(id: number): Observable<any> {
    return this.httpClient.delete(`${this.urlBase}/${id}`);
  }

  private construirFormData(campeonDTO: CrearCampeonDTO): FormData{
    const formData = new FormData();
    formData.append('year', campeonDTO.year!.toString());
    formData.append('pilotoId', campeonDTO.pilotoId!.toString());
    if(campeonDTO.autoCampeon){
      formData.append('autoCampeon', campeonDTO.autoCampeon);
    }
    return formData;
  }
}
