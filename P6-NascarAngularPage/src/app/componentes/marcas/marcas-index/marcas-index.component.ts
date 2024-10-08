import { Component } from '@angular/core';
import { MarcaService } from '../../../Services/marca.service';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { TablaIndexComponent } from "../../compartidos/tabla-index/tabla-index.component";

@Component({
  selector: 'app-marcas-index',
  standalone: true,
  imports: [TablaIndexComponent],
  templateUrl: './marcas-index.component.html',
  styleUrl: './marcas-index.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: MarcaService}]
})
export class MarcasIndexComponent {
  cols: string[] = ["nombre","id"]
}
