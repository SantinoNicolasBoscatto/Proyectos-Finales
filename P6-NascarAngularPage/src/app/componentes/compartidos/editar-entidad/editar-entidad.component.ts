import {Component, ComponentRef, inject, Input, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../providers/proveedores';
import { IServicioCRUD } from '../interface/IServicioCRUD';
import { Router } from '@angular/router';
import { extraerErrores } from '../../../functions/extraerErrores';
import { ErroresMostrarComponent } from "../errores-mostrar/errores-mostrar.component";
import { LoadingComponent } from "../loading/loading.component";

@Component({
  selector: 'app-editar-entidad',
  standalone: true,
  imports: [ErroresMostrarComponent, LoadingComponent],
  templateUrl: './editar-entidad.component.html',
  styleUrl: './editar-entidad.component.css'
})
export class EditarEntidadComponent<LecturaDTO, CreacionDTO> implements OnInit {
  ngOnInit(): void {
    this.servicioCRUD.obtenerRegistroPorId(this.id).subscribe(entidad => {
      this.cargarComponente(entidad);
    })
  }
  cargarComponente(entidad: any){
    if(this.contenedorFormulario){
      this.componentREF = this.contenedorFormulario.createComponent(this.form);
      this.componentREF.instance.modelo = entidad;
      this.componentREF.instance.routeBack = this.rutaBack;
      this.componentREF.instance.posteoFormulario.subscribe((entidad: any)=>{
        this.guardarCambios(entidad);
        this.lodiang = false;
      })
    }
  }

  @Input({required:true})
  Titulo!: string;
  @Input({required:true})
  rutaBack!: string;
  @Input({required: true})
  form: any;
  @Input()
  rutaEspecial: boolean = false;
  errores: string[] = [];
  msgBase!: string;
  @Input()
  id!:number;
  lodiang = true;


  @ViewChild('contenidoForms', {read: ViewContainerRef}) 
  contenedorFormulario!: ViewContainerRef;
  private componentREF!: ComponentRef<any>;


  servicioCRUD = inject(SERVICIO_CRUD_TOKEN) as IServicioCRUD<LecturaDTO, CreacionDTO>;
  private router = inject(Router);

  guardarCambios(entidadDTO: CreacionDTO) {
    this.servicioCRUD.editarRegistro(this.id,entidadDTO).subscribe({
      next: (res: any) => {
        if(this.rutaEspecial) {
          this.router.navigate(["/pilotos/"+res.id]);
        }
        else{
          this.router.navigate([this.rutaBack]);
        }
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
        this.lodiang = true;
      }
    })
  }
  archivoSelect(file: File){
    this.form.controls.foto.setValue(file);
  }
}
