import { inject, Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpInterceptorFn, HttpHandlerFn } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsersService } from '../Service/users.service';

export const authInterceptor: HttpInterceptorFn = (
    req: HttpRequest<any>,
    next: HttpHandlerFn
  ) =>{
    const userService = inject(UsersService);
    const token = userService.obtenerToken();
    if(token){
      req = req.clone({
        setHeaders: {
          'Authorization': `Bearer ${token}`
        }
      })
    }
    return next(req);
  }
