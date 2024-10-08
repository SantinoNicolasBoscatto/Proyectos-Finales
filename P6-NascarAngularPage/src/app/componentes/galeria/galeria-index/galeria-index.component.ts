import { Component } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { GaleriaService } from '../../../Services/galeria.service';
import { TablaIndexComponent } from "../../compartidos/tabla-index/tabla-index.component";

@Component({
  selector: 'app-galeria-index',
  standalone: true,
  imports: [TablaIndexComponent],
  templateUrl: './galeria-index.component.html',
  styleUrl: './galeria-index.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: GaleriaService}]
})
export class GaleriaIndexComponent {
  cols: string[] = ["ronda","id"]
}
