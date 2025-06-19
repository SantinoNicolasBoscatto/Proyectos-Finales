import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { UsersService } from '../Service/users.service';

export const estaLogueadoGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  const userService = inject(UsersService);
  let results = userService.estaLogueado();
  if(results) return true;
  return router.createUrlTree(['']);
};

export const noEstaLogueadoGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  const userService = inject(UsersService);
  let results = userService.estaLogueado();
  if(!results) return true;
  return router.createUrlTree(['menu']);
};