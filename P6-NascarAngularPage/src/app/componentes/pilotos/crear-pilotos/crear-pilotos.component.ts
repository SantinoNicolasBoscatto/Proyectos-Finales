import { Component } from '@angular/core';
import { PilotosFormComponent } from '../pilotos-form/pilotos-form.component';
import { CrearEntidadComponent } from "../../compartidos/crear-entidad/crear-entidad.component";
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { PilotoService } from '../../../Services/piloto.service';
import { AutosFormComponent } from '../../autos/autos-form/autos-form.component';

@Component({
  selector: 'app-crear-pilotos',
  standalone: true,
  imports: [CrearEntidadComponent],
  templateUrl: './crear-pilotos.component.html',
  styleUrl: './crear-pilotos.component.css',
  providers: [
    {provide: SERVICIO_CRUD_TOKEN, useClass: PilotoService}
  ]
})
export class CrearPilotosComponent {
  formPiloto = PilotosFormComponent;
}
