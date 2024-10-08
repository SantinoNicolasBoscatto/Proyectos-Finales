import { Component, Input, numberAttribute } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { AutoService } from '../../../Services/auto.service';
import { AutosFormComponent } from '../autos-form/autos-form.component';
import { EditarEntidadComponent } from "../../compartidos/editar-entidad/editar-entidad.component";

@Component({
  selector: 'app-editar-autos',
  standalone: true,
  imports: [EditarEntidadComponent],
  templateUrl: './editar-autos.component.html',
  styleUrl: './editar-autos.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: AutoService}]
})
export class EditarAutosComponent {
  @Input({transform: numberAttribute})
  id!: number;
  autoForms = AutosFormComponent
}
