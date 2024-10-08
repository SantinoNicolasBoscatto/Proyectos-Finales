import { Component } from '@angular/core';
import { GaleriaFormsComponent } from '../galeria-forms/galeria-forms.component';
import { CrearEntidadComponent } from "../../compartidos/crear-entidad/crear-entidad.component";
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { GaleriaService } from '../../../Services/galeria.service';

@Component({
  selector: 'app-crear-galeria',
  standalone: true,
  imports: [CrearEntidadComponent],
  templateUrl: './crear-galeria.component.html',
  styleUrl: './crear-galeria.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: GaleriaService}]
})
export class CrearGaleriaComponent {
  galeriaForms = GaleriaFormsComponent
}
