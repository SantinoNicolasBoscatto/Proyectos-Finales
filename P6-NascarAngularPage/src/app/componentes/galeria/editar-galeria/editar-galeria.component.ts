import { Component, Input, numberAttribute } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { GaleriaService } from '../../../Services/galeria.service';
import { GaleriaFormsComponent } from '../galeria-forms/galeria-forms.component';
import { EditarEntidadComponent } from "../../compartidos/editar-entidad/editar-entidad.component";

@Component({
  selector: 'app-editar-galeria',
  standalone: true,
  imports: [EditarEntidadComponent],
  templateUrl: './editar-galeria.component.html',
  styleUrl: './editar-galeria.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: GaleriaService}]
})
export class EditarGaleriaComponent {
  @Input({transform: numberAttribute})
  id!: number;
  galeriaForms = GaleriaFormsComponent;
}
