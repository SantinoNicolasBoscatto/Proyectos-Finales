import { Component } from '@angular/core';
import { PistaService } from '../../../Services/pista.service';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { TablaIndexComponent } from "../../compartidos/tabla-index/tabla-index.component";

@Component({
  selector: 'app-pistas-index',
  standalone: true,
  imports: [TablaIndexComponent],
  templateUrl: './pistas-index.component.html',
  styleUrl: './pistas-index.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: PistaService}]

})
export class PistasIndexComponent {
  cols: string[] = ["nombre", "distancia", "vueltas", "disputada", "enElCalendario","id"]
}
