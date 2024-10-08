import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CrearPilotoDTO, LecturaPilotoDTO } from '../componentes/pilotos/LecturaPilotoDTO';
import { IServicioCRUD } from '../componentes/compartidos/interface/IServicioCRUD';

@Injectable({
  providedIn: 'root'
})
export class PilotoService implements IServicioCRUD<LecturaPilotoDTO, CrearPilotoDTO>{
  
  urlBase: string = environment.Url + "pilotos";
  httpClient = inject(HttpClient);

  public cargarRegistros() : Observable<LecturaPilotoDTO[]> {
    return this.httpClient.get<LecturaPilotoDTO[]>(`${this.urlBase}`);
  }
  public cargarRegistrosCarLess() : Observable<LecturaPilotoDTO[]> {
    return this.httpClient.get<LecturaPilotoDTO[]>(`${this.urlBase}/carless`);
  }
  public cargarRegistrosCampeones() : Observable<LecturaPilotoDTO[]> {
    return this.httpClient.get<LecturaPilotoDTO[]>(`${this.urlBase}/campeones`);
  }
  public obtenerRegistroPorId(id: number) : Observable<LecturaPilotoDTO>{
    return this.httpClient.get<LecturaPilotoDTO>(`${this.urlBase}/${id}`);
  }
  public crearRegistro(entidad: CrearPilotoDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.post(this.urlBase, formData);
  }
  public editarRegistro(id: number, entidad: CrearPilotoDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.put(`${this.urlBase}/${id}`, formData);
  }
  public borrarRegistro(id: number): Observable<any> { 
    return this.httpClient.delete(`${this.urlBase}/${id}`)
  }

  private construirFormData(pilotoDTO: CrearPilotoDTO): FormData{
    const formData = new FormData();
    formData.append('nombre', pilotoDTO.nombre!);
    formData.append('numero', pilotoDTO.numero!);
    formData.append('carrerasGanadas', pilotoDTO.carrerasGanadas!.toString());
    formData.append('poles', pilotoDTO.poles!.toString());
    formData.append('top5s', pilotoDTO.top5s!.toString());
    formData.append('top10s', pilotoDTO.top10s!.toString());
    formData.append('campeonatos', pilotoDTO.campeonatos!.toString());
    formData.append('nacionalidadId', pilotoDTO.nacionalidadId!.toString());
    formData.append('edad', pilotoDTO.edad!.toString());
    formData.append('enActivo', pilotoDTO.enActivo!.toString());

    if(pilotoDTO.fotoPiloto){
      formData.append('fotoPiloto', pilotoDTO.fotoPiloto);
    }
    return formData;
  }
}
