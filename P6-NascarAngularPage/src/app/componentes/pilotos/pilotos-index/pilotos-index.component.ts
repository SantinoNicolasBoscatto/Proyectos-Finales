import { Component } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { PilotoService } from '../../../Services/piloto.service';
import { TablaIndexComponent } from "../../compartidos/tabla-index/tabla-index.component";

@Component({
  selector: 'app-pilotos-index',
  standalone: true,
  imports: [TablaIndexComponent],
  templateUrl: './pilotos-index.component.html',
  styleUrl: './pilotos-index.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: PilotoService}]
})
export class PilotosIndexComponent {
  cols: string[] = ["nombre", "numero", "pilotoNacion", "enActivo","id"]
}