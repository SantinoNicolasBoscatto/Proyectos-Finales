import { Component, EventEmitter, Input, Output } from '@angular/core';
import { toBase64 } from '../../../functions/toBase64';
import { MatButtonModule } from '@angular/material/button';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-selector-fotos',
  standalone: true,
  imports: [MatButtonModule, NgClass],
  templateUrl: './selector-fotos.component.html',
  styleUrl: './selector-fotos.component.css'
})
export class SelectorFotosComponent {
  @Input()
  urlImagen?: string;
  @Input()
  fondo: boolean = false;
  @Output()
  archivoSeleccionado = new EventEmitter<File>();
  imagenBase64?: string;
  
  CambioInputTypeFile(event: Event){
    const input = event.target as HTMLInputElement;
    if(input.files && input.files.length>0){
      const file: File = input.files[0];
      toBase64(file)
      .then((valor: string) => this.imagenBase64 = valor)
      .catch((err) => console.log(err))
      this.archivoSeleccionado.emit(file!);
      this.urlImagen = undefined;
    }
  }
}
