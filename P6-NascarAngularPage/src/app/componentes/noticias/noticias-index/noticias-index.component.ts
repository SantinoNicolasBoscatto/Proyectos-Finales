import { Component } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { NoticiasService } from '../../../Services/noticias.service';
import { TablaIndexComponent } from "../../compartidos/tabla-index/tabla-index.component";

@Component({
  selector: 'app-noticias-index',
  standalone: true,
  imports: [TablaIndexComponent],
  templateUrl: './noticias-index.component.html',
  styleUrl: './noticias-index.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: NoticiasService}]
})
export class NoticiasIndexComponent {
  cols: string[] = ["titulo","id"]
}
