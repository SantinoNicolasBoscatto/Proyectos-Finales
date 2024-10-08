import { inject, Injectable } from '@angular/core';
import { IServicioCRUD } from '../componentes/compartidos/interface/IServicioCRUD';
import { CrearGaleriaDTO, LecturaGaleriaDTO } from '../componentes/galeria/galeria';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GaleriaService implements IServicioCRUD<LecturaGaleriaDTO, CrearGaleriaDTO>{

  urlBase: string = environment.Url+"galeria";
  httpClient = inject(HttpClient);

  cargarRegistros(): Observable<LecturaGaleriaDTO[]> {
    return this.httpClient.get<LecturaGaleriaDTO[]>(this.urlBase);
  }
  obtenerRegistroPorId(id: number): Observable<LecturaGaleriaDTO> {
    return this.httpClient.get<LecturaGaleriaDTO>(`${this.urlBase}/${id}`);
  }
  crearRegistro(entidad: CrearGaleriaDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.post(this.urlBase, formData);
  }
  editarRegistro(id: number, entidad: CrearGaleriaDTO): Observable<any> {
    const formData = this.construirFormData(entidad);
    return this.httpClient.put(`${this.urlBase}/${id}`, formData);
  }
  borrarRegistro(id: number): Observable<any> {
    return this.httpClient.delete(`${this.urlBase}/${id}`);
  }

  private construirFormData(galeriaDTO: CrearGaleriaDTO): FormData{
    const formData = new FormData();
    formData.append('ronda',galeriaDTO.ronda!.toString())
    if(galeriaDTO.fotoUno){
      formData.append('fotoUno', galeriaDTO.fotoUno);
    }
    if(galeriaDTO.fotoDos){
      formData.append('fotoDos', galeriaDTO.fotoDos);
    }
    if(galeriaDTO.fotoTres){
      formData.append('fotoTres', galeriaDTO.fotoTres);
    }
    return formData;
  }
}
