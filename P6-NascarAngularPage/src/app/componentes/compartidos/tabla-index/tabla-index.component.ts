import { Component, inject, Input, OnInit } from '@angular/core';
import { MatCheckbox } from '@angular/material/checkbox';
import { MatTableModule } from '@angular/material/table';
import { Router, RouterLink } from '@angular/router';
import { SERVICIO_CRUD_TOKEN } from '../providers/proveedores';
import { IServicioCRUD } from '../interface/IServicioCRUD';
import { LoadingComponent } from "../loading/loading.component";
import { MatButtonModule } from '@angular/material/button';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { extraerErrores } from '../../../functions/extraerErrores';
import { ErroresMostrarComponent } from "../errores-mostrar/errores-mostrar.component";
export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}
@Component({
  selector: 'app-tabla-index',
  standalone: true,
  imports: [RouterLink, MatTableModule, MatCheckbox, LoadingComponent, MatButtonModule, SweetAlert2Module, ErroresMostrarComponent],
  templateUrl: './tabla-index.component.html',
  styleUrl: './tabla-index.component.css'
})
export class TablaIndexComponent<LecturaDTO, CreacionDTO> implements OnInit{
  ngOnInit(): void {
    this.cargarRegistros();
  }
  private router = inject(Router);
  private servicioCRUD = inject(SERVICIO_CRUD_TOKEN) as IServicioCRUD<LecturaDTO, CreacionDTO>;

  @Input({required: true})
  displayedColumns!: string[];
  tablaLista!: any[];
  errores: string[] = [];
  msgBase!: string;

  PrimeraLetraMayuscula(cadena: string): string {
    if (!cadena) return cadena;
    if(cadena==="enActivo") return cadena.slice(2);
    return cadena.charAt(0).toUpperCase() + cadena.slice(1);
  }

  cargarRegistros(){
    this.servicioCRUD.cargarRegistros().subscribe({
      next: (res: any[])=>{
        this.tablaLista = res;
      },
      error: (err : any)=>{
        let msgErrores = extraerErrores(err);
        this.errores = msgErrores;
        this.msgBase = err.error.message;
        let timeOut = setTimeout(() => {
          const maxScroll = document.documentElement.scrollHeight - document.documentElement.clientHeight;
          window.scrollTo({
            top: maxScroll,
            behavior: 'smooth' // Esto hace que el scroll sea suave
          });
          clearTimeout(timeOut);
        }, 250);
      }
    })
  }
  ConfirmarBorrar(id: number){
    this.servicioCRUD.borrarRegistro(id).subscribe({
      next: ()=>{
        this.cargarRegistros();
      },
      error: (err : any)=>{
        let msgErrores = extraerErrores(err);
        this.errores = msgErrores;
        this.msgBase = err.error.message;
        let timeOut = setTimeout(() => {
          const maxScroll = document.documentElement.scrollHeight - document.documentElement.clientHeight;
          window.scrollTo({
            top: maxScroll,
            behavior: 'smooth' // Esto hace que el scroll sea suave
          });
          clearTimeout(timeOut);
        }, 250);
      }
    })
  }
}
