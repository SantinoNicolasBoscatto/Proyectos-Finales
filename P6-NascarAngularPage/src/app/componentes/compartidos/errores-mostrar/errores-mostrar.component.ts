import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-errores-mostrar',
  standalone: true,
  imports: [],
  templateUrl: './errores-mostrar.component.html',
  styleUrl: './errores-mostrar.component.css'
})
export class ErroresMostrarComponent {
  @Input({required: true})
  listaErrores!: string[]
  @Input({required: true})
  MensajeError!: string;
}
