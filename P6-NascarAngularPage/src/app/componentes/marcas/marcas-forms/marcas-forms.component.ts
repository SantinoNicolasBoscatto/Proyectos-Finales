import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { CrearMarcaDTO, LecturaMarcaDTO } from '../../LecturaMarcaDTO';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { RouterLink } from '@angular/router';
import { SelectorFotosComponent } from '../../compartidos/selector-fotos/selector-fotos.component';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-marcas-forms',
  standalone: true,
  imports: [MatButtonModule, MatFormFieldModule, ReactiveFormsModule, MatInputModule, RouterLink, MatSelectModule, SelectorFotosComponent, MatCheckboxModule,
  NgClass],
  templateUrl: './marcas-forms.component.html',
  styleUrl: './marcas-forms.component.css'
})
export class MarcasFormsComponent implements OnInit{
  ngOnInit(): void {
    if (this.modelo !== undefined){
      const modeloConvertido = {
        ...this.modelo,
        nombre: this.modelo.nombre,
        id: this.modelo.id,
        listaAutos: "",
        foto: null
    };
      this.form.patchValue(modeloConvertido);
    }
  }
private formBuilder = inject(FormBuilder);
  form = this.formBuilder.group({
    nombre: ['', {validators: [Validators.required,  Validators.maxLength(30)]}],
    foto: new FormControl<File | null>(null)
  })

  @Input()
  modelo!: LecturaMarcaDTO;
  @Input()
  routeBack: string = "/formularios";
  @Output()
  posteoFormulario = new EventEmitter<CrearMarcaDTO>();

  guardarCambios(){
    const formData = this.form.value;
    const marcaDTO: CrearMarcaDTO = {
      nombre: formData.nombre!,
      foto: formData.foto
    }
    this.posteoFormulario.emit(marcaDTO);
  }
  ErrorCampoGenerico(control: FormControl) : string{
    if(control.hasError('required'))
    {return "Porfavor complete este campo";}
    if(control.hasError('maxlength'))
    {return "El texto ingresado es demasiado largo, el maximo de caracteres son "+ control.getError('maxlength')?.requiredLength;}
    return "";
  }
  archivoSelect(file: File){
    this.form.controls.foto.setValue(file);
  } 
}
