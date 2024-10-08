import { Component, EventEmitter, inject, Output } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { MarcaService } from '../../../Services/marca.service';
import { CrearEntidadComponent } from "../../compartidos/crear-entidad/crear-entidad.component";
import { MarcasFormsComponent } from '../marcas-forms/marcas-forms.component';

@Component({
  selector: 'app-crear-marca',
  standalone: true,
  imports: [CrearEntidadComponent],
  templateUrl: './crear-marca.component.html',
  styleUrl: './crear-marca.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: MarcaService}]
})
export class CrearMarcaComponent {
  marcaForm = MarcasFormsComponent;
}
