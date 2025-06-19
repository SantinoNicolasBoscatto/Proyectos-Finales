import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { CredencialesUsuario } from '../_interfaces/Users/CredencialesUsuario';
import { Observable, tap } from 'rxjs';
import { RespuestaAutenticacion } from '../_interfaces/Users/RespuestaAutenticacion';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  urlBase = environment.endPoint;
  httpClient = inject(HttpClient);
  private readonly llaveToken = 'token';
  private readonly llaveExpiracion = 'token-expiracion';
  constructor() { }

  public registrar(cred: CredencialesUsuario): Observable<RespuestaAutenticacion> {
    let formdata = this.construirFormData(cred);
    return this.httpClient.post<RespuestaAutenticacion>(`${this.urlBase}/registrar`, formdata)
    .pipe(tap(respuestaAutenticacion => this.guardarToken(respuestaAutenticacion)));
  }
  public login(cred: CredencialesUsuario): Observable<RespuestaAutenticacion> {
    let formdata = this.construirFormData(cred);
    return this.httpClient.post<RespuestaAutenticacion>(`${this.urlBase}/login`, formdata)
    .pipe(tap(respuestaAutenticacion => this.guardarToken(respuestaAutenticacion)));
  }
  public obtenerToken() : string | null{
    return localStorage.getItem(this.llaveToken);
  }

  public obtenerExpToken() : string | null{
    return localStorage.getItem(this.llaveExpiracion);
  }
  public logOut(){
    localStorage.removeItem(this.llaveToken);
    localStorage.removeItem(this.llaveExpiracion);
  }
  public estaLogueado() : boolean{
    const token = localStorage.getItem(this.llaveToken);
  
    if(!token){
      return false;
    }
  
    const expiracion = localStorage.getItem(this.llaveExpiracion)!;
    const fechaExpiracion = new Date(expiracion);
  
    if(fechaExpiracion <= new Date()){
      this.logOut();
      return false;
    }
    return true;
  }
  public renovarToken(){
    const token = localStorage.getItem(this.llaveToken); 
    const tokenExpiration = localStorage.getItem(this.llaveExpiracion);
    if (token && tokenExpiration) { 
      const expirationDate = new Date(tokenExpiration); 
      const now = new Date(); 
      const timeDiff = expirationDate.getTime() - now.getTime(); 
      const hoursDiff = timeDiff / (1000 * 60 * 60); 
      if (hoursDiff < 2) {
        this.renovarTokenEndpoint().subscribe();
      }
    }
  }

  private guardarToken(respuestaAutenticacion: RespuestaAutenticacion){
    localStorage.setItem(this.llaveToken, respuestaAutenticacion.token);
    localStorage.setItem(this.llaveExpiracion, respuestaAutenticacion.expiracion.toString());
  }
  private construirFormData(cred: CredencialesUsuario): FormData{
    const formData = new FormData();
    formData.append('email', cred.email);
    formData.append('password', cred.password);
    return formData;
  }
  private renovarTokenEndpoint(): Observable<RespuestaAutenticacion>{
    let token = this.httpClient.get<RespuestaAutenticacion>(`${this.urlBase}/renovartoken`)
    .pipe(tap(respuestaAutenticacion => {
      this.guardarToken(respuestaAutenticacion)
    }));
    return token;
  }
}
