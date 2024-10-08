import { Component, Input, numberAttribute } from '@angular/core';
import { EditarEntidadComponent } from "../../compartidos/editar-entidad/editar-entidad.component";
import { PilotosFormComponent } from '../pilotos-form/pilotos-form.component';
import { PilotoService } from '../../../Services/piloto.service';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';

@Component({
  selector: 'app-editar-pilotos',
  standalone: true,
  imports: [EditarEntidadComponent],
  templateUrl: './editar-pilotos.component.html',
  styleUrl: './editar-pilotos.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: PilotoService}]

})
export class EditarPilotosComponent {
  @Input({transform: numberAttribute})
  id!: number;
  pilotoForms = PilotosFormComponent
}
