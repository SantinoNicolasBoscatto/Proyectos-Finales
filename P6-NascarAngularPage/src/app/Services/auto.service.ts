import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { LecturaAutoDTO } from '../componentes/pilotos/LecturaPilotoDTO';
import { CrearAutoDTO } from '../componentes/autos/CrearAutoDTO';
import { IServicioCRUD } from '../componentes/compartidos/interface/IServicioCRUD';

@Injectable({
  providedIn: 'root'
})
export class AutoService implements IServicioCRUD<LecturaAutoDTO, CrearAutoDTO>{
  httpClient = inject(HttpClient);
  urlBase = environment.Url + 'autos';

  public cargarRegistros() : Observable<LecturaAutoDTO[]>{
    return this.httpClient.get<LecturaAutoDTO[]>(this.urlBase);
  }

  public obtenerRegistroPorId(id: number) : Observable<LecturaAutoDTO>{
    return this.httpClient.get<LecturaAutoDTO>(`${this.urlBase}/${id}`);
  }

  public crearRegistro(autoDTO: CrearAutoDTO) : Observable<any>{
    const formData = this.construirFormData(autoDTO);
    return this.httpClient.post(this.urlBase, formData);
  }

  public editarRegistro(id: number,autoDTO: CrearAutoDTO) : Observable<any>{
    const formData = this.construirFormData(autoDTO);
    return this.httpClient.put(`${this.urlBase}/${id}`, formData);
  }

  public borrarRegistro(id: number) : Observable<any>{
    return this.httpClient.delete(`${this.urlBase}/${id}`);
  }

  private construirFormData(autoDTO: CrearAutoDTO): FormData{
    const formData = new FormData();
    formData.append('pilotoId', autoDTO.pilotoId!.toString());
    formData.append('marcaId', autoDTO.marcaId!.toString());
    if(autoDTO.foto){
      formData.append('foto', autoDTO.foto);
    }
    return formData;
  }
}
