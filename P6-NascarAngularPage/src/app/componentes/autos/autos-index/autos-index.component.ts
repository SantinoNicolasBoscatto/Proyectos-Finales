import { Component } from '@angular/core';
import { TablaIndexComponent } from "../../compartidos/tabla-index/tabla-index.component";
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { AutoService } from '../../../Services/auto.service';

@Component({
  selector: 'app-autos-index',
  standalone: true,
  imports: [TablaIndexComponent],
  templateUrl: './autos-index.component.html',
  styleUrl: './autos-index.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: AutoService}]
})
export class AutosIndexComponent {
  cols: string[] = ["pilotoAuto", "marcaAuto", "id"]
}
