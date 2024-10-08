import { Component } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { CampeonesService } from '../../../Services/campeones.service';
import { CampeonesFormComponent } from '../campeones-form/campeones-form.component';
import { CrearEntidadComponent } from "../../compartidos/crear-entidad/crear-entidad.component";

@Component({
  selector: 'app-crear-campeon',
  standalone: true,
  imports: [CrearEntidadComponent],
  templateUrl: './crear-campeon.component.html',
  styleUrl: './crear-campeon.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: CampeonesService}]
})
export class CrearCampeonComponent {
  campeonForms = CampeonesFormComponent;
}
