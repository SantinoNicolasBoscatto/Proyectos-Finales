import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { RouterLink } from '@angular/router';
import { SelectorFotosComponent } from '../../compartidos/selector-fotos/selector-fotos.component';
import { CrearNacionalidadDTO, LecturaNacionalidadDTO } from '../../nacionalidad';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-nacionalidad-forms',
  standalone: true,
  imports: [MatButtonModule, MatFormFieldModule, ReactiveFormsModule, MatInputModule, RouterLink, MatSelectModule, SelectorFotosComponent, MatCheckboxModule,
    NgClass],
  templateUrl: './nacionalidad-forms.component.html',
  styleUrl: './nacionalidad-forms.component.css'
})
export class NacionalidadFormsComponent implements OnInit{
  ngOnInit(): void {
    if (this.modelo !== undefined){
      const modeloConvertido = {
        ...this.modelo,
        nombre: this.modelo.nombre,
        id: this.modelo.id,
        bandera: null
    };
      this.form.patchValue(modeloConvertido);
    }
  }

  private formBuilder = inject(FormBuilder);
  form = this.formBuilder.group({
    nombre: ['', {validators: [Validators.required,  Validators.maxLength(50)]}],
    bandera: new FormControl<File | null>(null)
  })

  ErrorCampoGenerico(control: FormControl) : string{
    if(control.hasError('required'))
    {return "Porfavor complete este campo";}
    if(control.hasError('maxlength'))
    {return "El texto ingresado es demasiado largo, el maximo de caracteres son "+ control.getError('maxlength')?.requiredLength;}
    return "";
  }

  @Input()
  modelo!: LecturaNacionalidadDTO;
  @Input()
  routeBack: string = "/formularios";
  @Output()
  posteoFormulario = new EventEmitter<CrearNacionalidadDTO>();

  guardarCambios(){
    const formData = this.form.value;
    const nacionDTO: CrearNacionalidadDTO = {
      nombre: formData.nombre!,
      bandera: formData.bandera
    }
    this.posteoFormulario.emit(nacionDTO);
  }
  archivoSelect(file: File){
    this.form.controls.bandera.setValue(file);
  } 
} 
