import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { CrearGaleriaDTO, LecturaGaleriaDTO } from '../galeria';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { RouterLink } from '@angular/router';
import { SelectorFotosComponent } from '../../compartidos/selector-fotos/selector-fotos.component';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-galeria-forms',
  standalone: true,
  imports: [MatButtonModule, MatFormFieldModule, ReactiveFormsModule, MatInputModule, RouterLink, MatSelectModule, SelectorFotosComponent, NgClass],
  templateUrl: './galeria-forms.component.html',
  styleUrl: './galeria-forms.component.css'
})
export class GaleriaFormsComponent implements OnInit{
  ngOnInit(): void {
    if (this.modelo !== undefined){
      const modeloConvertido = {
        ...this.modelo,
        ronda: this.modelo.ronda.toString(),
        fotoUno: null,
        fotoDos: null,
        fotoTres: null
    };
      this.form.patchValue(modeloConvertido);
    }
  }
  private formBuilder = inject(FormBuilder);
  form = this.formBuilder.group({
    fotoUno: new FormControl<File | null>(null),
    fotoDos: new FormControl<File | null>(null),
    fotoTres: new FormControl<File | null>(null),
    ronda: ['', {validators: [Validators.min(1), Validators.max(36), Validators.required]}]
  })
  @Input()
  modelo!: LecturaGaleriaDTO;
  @Input()
  routeBack: string = "/formularios";
  @Output()
  posteoFormulario = new EventEmitter<CrearGaleriaDTO>();

  guardarCambios(){
    const formData = this.form.value;
    const galeriaDTO: CrearGaleriaDTO = {
      fotoUno: formData.fotoUno,
      fotoDos: formData.fotoDos,
      fotoTres: formData.fotoTres!,
      ronda: parseInt(formData.ronda!)
    }
    this.posteoFormulario.emit(galeriaDTO);
  }

  ErrorCampoGenerico(control: FormControl) : string{
    if(control.hasError('required'))
    {return "Porfavor complete este campo";}
    if(control.hasError('min'))
    {return "El valor esta por debajo del minimo de "+ control.getError('min')?.min;}
    if(control.hasError('max'))
    {return "El valor excede el maximo de "+ control.getError('max')?.max;}
    return "";
  }

  

  archivoSelect(file: File, foto: string){
    if(foto === "first") {
      this.form.controls.fotoUno.setValue(file);
    }
    else if(foto === "second") {
      this.form.controls.fotoDos.setValue(file);
    }
    else if(foto === "third"){
      this.form.controls.fotoTres.setValue(file); 
    }
  } 
}
