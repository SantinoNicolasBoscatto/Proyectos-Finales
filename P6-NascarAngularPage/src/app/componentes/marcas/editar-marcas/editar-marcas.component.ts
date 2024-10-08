import { Component, Input, numberAttribute } from '@angular/core';
import { MarcaService } from '../../../Services/marca.service';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { MarcasFormsComponent } from '../marcas-forms/marcas-forms.component';
import { EditarEntidadComponent } from "../../compartidos/editar-entidad/editar-entidad.component";

@Component({
  selector: 'app-editar-marcas',
  standalone: true,
  imports: [EditarEntidadComponent],
  templateUrl: './editar-marcas.component.html',
  styleUrl: './editar-marcas.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: MarcaService}]
})
export class EditarMarcasComponent {
  @Input({transform: numberAttribute})
  id!: number;
  marcaForms = MarcasFormsComponent
}
