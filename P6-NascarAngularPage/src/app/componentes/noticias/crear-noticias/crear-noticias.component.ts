import { Component } from '@angular/core';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { NoticiasService } from '../../../Services/noticias.service';
import { NoticiaFormularioComponent } from '../noticia-formulario/noticia-formulario.component';
import { CrearEntidadComponent } from "../../compartidos/crear-entidad/crear-entidad.component";

@Component({
  selector: 'app-crear-noticias',
  standalone: true,
  imports: [CrearEntidadComponent],
  templateUrl: './crear-noticias.component.html',
  styleUrl: './crear-noticias.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: NoticiasService}]
})
export class CrearNoticiasComponent {
  noticiaForms = NoticiaFormularioComponent;
}
