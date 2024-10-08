import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { CalendarioDTO } from '../componentes/calendario/calendario';
import { CrearPistaDTO, LecturaPistaDTO } from '../componentes/calendario/LecturaPistaDTO';
import { IServicioCRUD } from '../componentes/compartidos/interface/IServicioCRUD';

@Injectable({
  providedIn: 'root'
})
export class PistaService implements IServicioCRUD<LecturaPistaDTO, CrearPistaDTO>{
  
  urlBase: string = environment.Url + "pistas";
  httpClient = inject(HttpClient);

  cargarRegistros() : Observable<LecturaPistaDTO[]> {
    return this.httpClient.get<LecturaPistaDTO[]>(`${this.urlBase}`);
  }
  obtenerRegistroPorId(id: number): Observable<LecturaPistaDTO> {
    return this.httpClient.get<LecturaPistaDTO>(`${this.urlBase}/${id}`);
  }
  obtenerRegistroPorOrden(Orden: number): Observable<LecturaPistaDTO> {
    return this.httpClient.get<LecturaPistaDTO>(`${this.urlBase}/orden/${Orden}`);
  }
  crearRegistro(entidad: CrearPistaDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.post(this.urlBase, formData);
  }
  editarRegistro(id: number, entidad: CrearPistaDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.put(`${this.urlBase}/${id}`, formData);
  }
  borrarRegistro(id: number): Observable<any> {
    return this.httpClient.delete(`${this.urlBase}/${id}`);
  }

  traerCalendario() : Observable<CalendarioDTO> {
    return this.httpClient.get<CalendarioDTO>(`${this.urlBase}/calendario`);
  }

  private construirFormData(pistaDTO: CrearPistaDTO): FormData{
    const formData = new FormData();
    formData.append('nombre', pistaDTO.nombre!);
    formData.append('distancia', pistaDTO.distancia!);
    formData.append('vueltas', pistaDTO.vueltas!.toString());
    formData.append('orden', pistaDTO.orden!.toString());
    formData.append('disputada', pistaDTO.disputada!.toString());
    formData.append('enElCalendario', pistaDTO.enElCalendario!.toString());

    if(pistaDTO.fotoPrimaria){
      formData.append('fotoPrimaria', pistaDTO.fotoPrimaria);
    }
    if(pistaDTO.fotoSecundaria){
      formData.append('fotoSecundaria', pistaDTO.fotoSecundaria);
    }
    if(pistaDTO.fotoTerciaria){
      formData.append('fotoTerciaria', pistaDTO.fotoTerciaria);
    }
    return formData;
  }
}
