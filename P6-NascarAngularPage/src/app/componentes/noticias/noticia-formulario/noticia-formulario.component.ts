import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { CrearNoticiaDTO, LecturaNoticiaDTO } from '../../NoticiaDTO';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';
import { LoadingComponent } from '../../compartidos/loading/loading.component';
import { SelectorFotosComponent } from '../../compartidos/selector-fotos/selector-fotos.component';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-noticia-formulario',
  standalone: true,
  imports: [MatButtonModule, MatFormFieldModule, ReactiveFormsModule, MatInputModule, RouterLink, SelectorFotosComponent, LoadingComponent, NgClass],
  templateUrl: './noticia-formulario.component.html',
  styleUrl: './noticia-formulario.component.css'
})
export class NoticiaFormularioComponent implements OnInit{
  ngOnInit(): void {
    if (this.modelo !== undefined){
      const modeloConvertido = {
        ...this.modelo,
        foto: null
    };
      this.form.patchValue(modeloConvertido);
    }
  }
  private formBuilder = inject(FormBuilder);
  @Input()
  modelo?: LecturaNoticiaDTO;
  @Input()
  routeBack: string = "/formularios";
  @Output()
  posteoFormulario = new EventEmitter<CrearNoticiaDTO>();

  form = this.formBuilder.group({
    titulo: ['', {validators: [Validators.required,  Validators.maxLength(80)]}],
    detalles: ['', {validators: [Validators.maxLength(1000)]}],
    foto: new FormControl<File | null>(null)
  });


  guardarCambios(){
    const formValues = this.form.value;
    const noticiaDTO: CrearNoticiaDTO = {
      titulo: formValues.titulo!,
      detalles: formValues.detalles,
      foto: formValues.foto
    }
    this.posteoFormulario.emit(noticiaDTO);
  }
  ErrorCampoGenerico(control: FormControl) : string{
    if(control.hasError('required'))
    {return "Porfavor complete el campo nombre";}
    if(control.hasError('maxlength'))
    {return "El Nombre ingresado es demasiado largo, el maximo de caracteres son "+ control.getError('maxlength')?.requiredLength;}
    return "";
  }
  archivoSelect(file: File){
    this.form.controls.foto.setValue(file);
  }
}
