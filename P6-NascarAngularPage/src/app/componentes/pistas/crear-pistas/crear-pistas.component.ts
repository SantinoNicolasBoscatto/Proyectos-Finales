import { Component } from '@angular/core';
import { CrearEntidadComponent } from "../../compartidos/crear-entidad/crear-entidad.component";
import { PistaFormsComponent } from '../pista-forms/pista-forms.component';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { PistaService } from '../../../Services/pista.service';

@Component({
  selector: 'app-crear-pistas',
  standalone: true,
  imports: [CrearEntidadComponent],
  templateUrl: './crear-pistas.component.html',
  styleUrl: './crear-pistas.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: PistaService}]
})
export class CrearPistasComponent {
  formPista = PistaFormsComponent;
}
