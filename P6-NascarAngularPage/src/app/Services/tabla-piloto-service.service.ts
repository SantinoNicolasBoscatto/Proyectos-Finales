import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { LecturaRegularDTO } from '../componentes/posiciones-tabla-nascar/tabla-regular';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TablaPilotoService {
  urlBase: string = environment.Url + "posiciones/";
  httpClient = inject(HttpClient);

  cargarRegistros<TDTO>(ruta: string) : Observable<TDTO[]> {
    return this.httpClient.get<TDTO[]>(`${this.urlBase}${ruta}`);
  }


}
