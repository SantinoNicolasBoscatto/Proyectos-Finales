import { AfterViewInit, Component, ComponentRef, inject, Input, ViewChild, ViewContainerRef } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../providers/proveedores';
import { IServicioCRUD } from '../interface/IServicioCRUD';
import { Router } from '@angular/router';
import { extraerErrores } from '../../../functions/extraerErrores';
import { ErroresMostrarComponent } from "../errores-mostrar/errores-mostrar.component";

@Component({
  selector: 'app-crear-entidad',
  standalone: true,
  imports: [ErroresMostrarComponent],
  templateUrl: './crear-entidad.component.html',
  styleUrl: './crear-entidad.component.css'
})
export class CrearEntidadComponent<LecturaDTO, CreacionDTO> implements AfterViewInit{
  ngAfterViewInit(): void {
    this.componentREF = this.contenedorFormulario.createComponent(this.form);
    this.componentREF.instance.posteoFormulario.subscribe((entidad: any)=>{
      this.guardarCambios(entidad);
    })
  }
  @Input({required:true})
  Titulo!: string;
  @Input({required: true})
  form: any;
  @Input()
  rutaEspecial: boolean = false;
  errores: string[] = [];
  msgBase!: string;


  @ViewChild('contenidoForms', {read: ViewContainerRef}) 
  contenedorFormulario!: ViewContainerRef;
  private componentREF!: ComponentRef<any>;


  servicioCRUD = inject(SERVICIO_CRUD_TOKEN) as IServicioCRUD<LecturaDTO, CreacionDTO>;
  private router = inject(Router);

  guardarCambios(entidadDTO: CreacionDTO) {
    this.servicioCRUD.crearRegistro(entidadDTO).subscribe({
      next: (res: any) => {
        if(this.rutaEspecial) {
          this.router.navigate(["/pilotos/"+res.id]);
        }
        else{
          this.router.navigate(["/formularios"]);
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
      }
    })
  }
  archivoSelect(file: File){
    this.form.controls.foto.setValue(file);
  }
}
