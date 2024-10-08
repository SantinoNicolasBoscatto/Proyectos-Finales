import { AfterViewInit, Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { CrearPistaDTO, LecturaPistaDTO } from '../../calendario/LecturaPistaDTO';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { RouterLink } from '@angular/router';
import { SelectorFotosComponent } from '../../compartidos/selector-fotos/selector-fotos.component';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-pista-forms',
  standalone: true,
  imports: [MatButtonModule, MatFormFieldModule, ReactiveFormsModule, MatInputModule, RouterLink, MatSelectModule, SelectorFotosComponent, MatCheckboxModule,
    NgClass
  ],
  templateUrl: './pista-forms.component.html',
  styleUrl: './pista-forms.component.css'
})
export class PistaFormsComponent implements OnInit {
  ngOnInit(): void {
    if (this.modelo !== undefined){
      const modeloConvertido = {
        ...this.modelo,
        orden: this.modelo.orden!.toString(),
        vueltas: this.modelo.vueltas.toString(),
        fotoPrimaria: null,
        fotoSecundaria: null,
        fotoTerciaria: null,
    };
      this.form.patchValue(modeloConvertido);
    }
  }
  private formBuilder = inject(FormBuilder);
  form = this.formBuilder.group({
    nombre: ['', {validators: [Validators.required, Validators.maxLength(75)]}],
    distancia: ['', {validators: [Validators.required, Validators.max(10)]}],
    orden: ['', {validators: [Validators.min(1), Validators.max(36)]}],
    vueltas: ['', {validators: [Validators.min(1), Validators.max(999)]}],
    disputada: new FormControl<true | false>(false),
    enElCalendario: new FormControl<true | false>(false),
    fotoPrimaria: new FormControl<File | null>(null),
    fotoSecundaria: new FormControl<File | null>(null),
    fotoTerciaria: new FormControl<File | null>(null)
  });

  @Input()
  modelo?: LecturaPistaDTO;
  @Input()
  routeBack: string = "/formularios";
  @Output()
  posteoFormulario = new EventEmitter<CrearPistaDTO>();

  guardarCambios(){
    const formValues = this.form.value;
    const pistaDTO: CrearPistaDTO = {
      nombre: formValues.nombre!,
      distancia: formValues.distancia!,
      orden: formValues.orden === null || formValues.orden === undefined? 0 : parseInt(formValues.orden),
      disputada: formValues.disputada!,
      enElCalendario: formValues.enElCalendario!,
      fotoPrimaria: formValues.fotoPrimaria,
      fotoSecundaria: formValues.fotoSecundaria,
      fotoTerciaria: formValues.fotoTerciaria,
      vueltas: formValues.vueltas === null || formValues.vueltas === undefined? 0 : parseInt(formValues.vueltas)
    }
    this.posteoFormulario.emit(pistaDTO);
  }

  ErrorCampoGenerico(control: FormControl) : string{
    if(control.hasError('required'))
    {return "Porfavor complete este campo";}
    if(control.hasError('maxlength'))
    {return "El texto ingresado es demasiado largo, el maximo de caracteres son "+ control.getError('maxlength')?.requiredLength;}
    if(control.hasError('min'))
    {return "El valor esta por debajo del minimo de "+ control.getError('min')?.min;}
    if(control.hasError('max'))
    {return "El valor excede el maximo de "+ control.getError('max')?.max;}
    return "";
  }


  archivoSelect(file: File, foto: string){
    if(foto === "1") this.form.controls.fotoPrimaria.setValue(file);
    else if(foto === "2") this.form.controls.fotoSecundaria.setValue(file);
    else this.form.controls.fotoTerciaria.setValue(file);
  } 

}
