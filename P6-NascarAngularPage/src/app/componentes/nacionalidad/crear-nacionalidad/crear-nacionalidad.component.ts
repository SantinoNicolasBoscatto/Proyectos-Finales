import { Component } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { NacionalidadService } from '../../../Services/nacionalidad.service';
import { NacionalidadFormsComponent } from '../nacionalidad-forms/nacionalidad-forms.component';
import { CrearEntidadComponent } from "../../compartidos/crear-entidad/crear-entidad.component";

@Component({
  selector: 'app-crear-nacionalidad',
  standalone: true,
  imports: [CrearEntidadComponent],
  templateUrl: './crear-nacionalidad.component.html',
  styleUrl: './crear-nacionalidad.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: NacionalidadService}]
})
export class CrearNacionalidadComponent {
  nacionForms = NacionalidadFormsComponent;
}
