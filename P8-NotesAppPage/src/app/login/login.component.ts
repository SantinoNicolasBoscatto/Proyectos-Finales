import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from '../Service/users.service';
import { CredencialesUsuario } from '../_interfaces/Users/CredencialesUsuario';
import { RespuestaAutenticacion } from '../_interfaces/Users/RespuestaAutenticacion';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, FormsModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  private router = inject(Router);
  private userService = inject(UsersService);
  private userCredentials!: CredencialesUsuario;
  loginError = false; 
  loginErrorMessage = 'Error al iniciar sesión. Por favor, verifica tus credenciales.';

  Loguearse(){
    let email = document.getElementById("loginEmail") as HTMLInputElement;
    let pass = document.getElementById("loginPass") as HTMLInputElement;
    this.userCredentials = {email: email.value, password: pass.value};
    this.userService.login(this.userCredentials)
    .subscribe({ 
      next: (respuesta: RespuestaAutenticacion) => { 
        this.router.navigate(['menu']);
      }, 
      error: () => { 
        this.loginError = true; 
      } });
  }
  Registrarse(){
    let email = document.getElementById("registerEmail") as HTMLInputElement;
    let pass = document.getElementById("registerPass") as HTMLInputElement;
    this.userCredentials = {email: email.value, password: pass.value};
    this.userService.registrar(this.userCredentials)
    .subscribe({ 
      next: (respuesta: RespuestaAutenticacion) => { 
        this.router.navigate(['menu']); 
      }, 
      error: () => { 
        this.loginError = true; 
      } });
    
  }
}
