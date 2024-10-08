import { Component, Input, numberAttribute } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { PistaService } from '../../../Services/pista.service';
import { PistaFormsComponent } from '../pista-forms/pista-forms.component';
import { EditarEntidadComponent } from "../../compartidos/editar-entidad/editar-entidad.component";

@Component({
  selector: 'app-editar-pistas',
  standalone: true,
  imports: [EditarEntidadComponent],
  templateUrl: './editar-pistas.component.html',
  styleUrl: './editar-pistas.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: PistaService}]
})
export class EditarPistasComponent {
  @Input({transform: numberAttribute})
  id!: number;
  pistaForms = PistaFormsComponent
}
