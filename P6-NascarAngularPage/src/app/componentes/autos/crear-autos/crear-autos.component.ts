import { Component } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { AutoService } from '../../../Services/auto.service';
import { AutosFormComponent } from '../autos-form/autos-form.component';
import { CrearEntidadComponent } from "../../compartidos/crear-entidad/crear-entidad.component";

@Component({
  selector: 'app-crear-autos',
  standalone: true,
  imports: [CrearEntidadComponent],
  templateUrl: './crear-autos.component.html',
  styleUrl: './crear-autos.component.css',
  providers: [
    {provide: SERVICIO_CRUD_TOKEN, useClass: AutoService}
  ]
})
export class CrearAutosComponent {
  formAutos = AutosFormComponent;
}
