import { Component } from '@angular/core';
import { TablaIndexComponent } from "../../compartidos/tabla-index/tabla-index.component";
import { CampeonesService } from '../../../Services/campeones.service';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';

@Component({
  selector: 'app-campeones-index',
  standalone: true,
  imports: [TablaIndexComponent],
  templateUrl: './campeones-index.component.html',
  styleUrl: './campeones-index.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: CampeonesService}]
})
export class CampeonesIndexComponent {
  cols: string[] = ["year", "pilotoNombre","id"]
}
