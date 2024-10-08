import { Component, Input, numberAttribute } from '@angular/core';
import { NoticiaFormularioComponent } from '../noticia-formulario/noticia-formulario.component';
import { SERVICIO_CRUD_TOKEN } from '../../compartidos/providers/proveedores';
import { NoticiasService } from '../../../Services/noticias.service';
import { EditarEntidadComponent } from "../../compartidos/editar-entidad/editar-entidad.component";

@Component({
  selector: 'app-editar-noticias',
  standalone: true,
  imports: [EditarEntidadComponent],
  templateUrl: './editar-noticias.component.html',
  styleUrl: './editar-noticias.component.css',
  providers: [{provide: SERVICIO_CRUD_TOKEN, useClass: NoticiasService}]
})
export class EditarNoticiasComponent {
  @Input({transform: numberAttribute})
  id!: number;
  noticiaForms = NoticiaFormularioComponent
}
