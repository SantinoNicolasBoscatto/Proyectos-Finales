import { Component, Input, numberAttribute } from '@angular/core';
import { EditarEntidadComponent } from "../../compartidos/editar-entidad/editar-entidad.component";
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { NacionalidadService } from '../../../Services/nacionalidad.service';
import { NacionalidadFormsComponent } from '../nacionalidad-forms/nacionalidad-forms.component';

@Component({
  selector: 'app-editar-nacionalidad',
  standalone: true,
  imports: [EditarEntidadComponent],
  templateUrl: './editar-nacionalidad.component.html',
  styleUrl: './editar-nacionalidad.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: NacionalidadService}]
})
export class EditarNacionalidadComponent {
  @Input({transform: numberAttribute})
  id!: number;
  nacionForms = NacionalidadFormsComponent
}
