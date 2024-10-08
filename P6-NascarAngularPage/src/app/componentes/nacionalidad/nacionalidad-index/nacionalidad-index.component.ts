import { Component } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { NacionalidadService } from '../../../Services/nacionalidad.service';
import { TablaIndexComponent } from "../../compartidos/tabla-index/tabla-index.component";

@Component({
  selector: 'app-nacionalidad-index',
  standalone: true,
  imports: [TablaIndexComponent],
  templateUrl: './nacionalidad-index.component.html',
  styleUrl: './nacionalidad-index.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: NacionalidadService}]

})
export class NacionalidadIndexComponent {
  cols: string[] = ["nombre", "id"]
}
