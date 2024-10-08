import { Component, Input, numberAttribute } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { CampeonesService } from '../../../Services/campeones.service';
import { CampeonesFormComponent } from '../campeones-form/campeones-form.component';
import { EditarEntidadComponent } from "../../compartidos/editar-entidad/editar-entidad.component";

@Component({
  selector: 'app-editar-campeones',
  standalone: true,
  imports: [EditarEntidadComponent],
  templateUrl: './editar-campeones.component.html',
  styleUrl: './editar-campeones.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: CampeonesService}]
})
export class EditarCampeonesComponent {
  @Input({transform: numberAttribute})
  id!: number;
  campeonesForms = CampeonesFormComponent
}
