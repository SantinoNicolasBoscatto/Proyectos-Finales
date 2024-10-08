import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { LecturaCarreraDTO } from '../componentes/carrera/LecturaCarreraDTO';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarreraService {
  httpClient = inject(HttpClient);
  urlBase: string = environment.Url+"posiciones/"

  cargarRegistros(id: number): Observable<LecturaCarreraDTO[]>{
    return this.httpClient.get<LecturaCarreraDTO[]>(this.urlBase+id.toString());
  }

  crearCarrera(data: any[]):  Observable<any>{
    return this.httpClient.post(`${this.urlBase}`, data);
  }

  reiniciarTemporada(): Observable<any>{
    return this.httpClient.post(`${this.urlBase}ReiniciarTemporada`,{})
  }
}
