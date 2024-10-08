import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS, MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { RouterLink } from '@angular/router';
import { SelectorFotosComponent } from '../../compartidos/selector-fotos/selector-fotos.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { NacionalidadService } from '../../../Services/nacionalidad.service';
import { CrearPilotoDTO, LecturaAutoDTO, LecturaNacionalidadDTO, LecturaPilotoDTO } from '../LecturaPilotoDTO';
import { LoadingComponent } from "../../compartidos/loading/loading.component";
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-pilotos-form',
  standalone: true,
  imports: [MatButtonModule, MatFormFieldModule, ReactiveFormsModule, MatInputModule, RouterLink, MatSelectModule, SelectorFotosComponent, MatCheckboxModule, 
    LoadingComponent, NgClass],
  templateUrl: './pilotos-form.component.html',
  styleUrl: './pilotos-form.component.css',
  providers: [
    { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill', hideRequiredMarker: true } }
  ]
})
export class PilotosFormComponent implements OnInit{
  ngOnInit(): void {
    this.nacionService.cargarRegistros().subscribe((res: LecturaNacionalidadDTO[]) => {
      this.listaNacion = res;
      this.selectedNation = this.modelo?  this.modelo.nacionalidad.id : res[0].id;
    });
    if (this.modelo !== undefined){
      const modeloConvertido = {
        ...this.modelo,
        edad: this.modelo.edad.toString(),
        carrerasGanadas: this.modelo.carrerasGanadas.toString(),
        poles: this.modelo.poles.toString(),
        top5s: this.modelo.top5s.toString(),
        top10s: this.modelo.top10s.toString(),
        campeonatos: this.modelo.campeonatos.toString(),
        nacionalidad: this.modelo.nacionalidad.id.toString(),
        fotoPiloto: null
    };
      this.form.patchValue(modeloConvertido);
    }
  }
  private formBuilder = inject(FormBuilder);
  private nacionService = inject(NacionalidadService);
  form = this.formBuilder.group({
    nombre: ['', {validators: [Validators.required,  Validators.maxLength(50)]}],
    numero: ['', {validators: [Validators.required, Validators.maxLength(3), Validators.pattern('^[0-9]*$')]}],
    edad: ['', {validators: [Validators.required, Validators.pattern('^[0-9]*$'), Validators.min(0), Validators.max(100)]}],
    carrerasGanadas: ['', {validators: [Validators.required, Validators.pattern('^[0-9]*$'), Validators.min(0), Validators.max(9999)]}],
    poles: ['', {validators: [Validators.required, Validators.pattern('^[0-9]*$'), Validators.min(0), Validators.max(9999)]}],
    top5s: ['', {validators: [Validators.required, Validators.pattern('^[0-9]*$'),Validators.min(0), Validators.max(9999)]}],
    top10s: ['', {validators: [Validators.required, Validators.pattern('^[0-9]*$'), Validators.min(0), Validators.max(9999)]}],
    campeonatos: ['', {validators: [Validators.required, Validators.pattern('^[0-9]*$'), Validators.min(0), Validators.max(100)]}],
    enActivo: new FormControl<true | false>(false),
    nacionalidad: [''],
    fotoPiloto: new FormControl<File | null>(null)
  })
  listaNacion!: LecturaNacionalidadDTO[];
  selectedNation: number = 1;
  @Output()
  posteoFormulario = new EventEmitter<CrearPilotoDTO>();
  @Input()
  modelo!: LecturaPilotoDTO;
  @Input()
  routeBack: string = "/formularios";
  guardarCambios(){
    const formValues = this.form.value;
    const pilotoDTO: CrearPilotoDTO = {
      nombre: formValues.nombre!,
      numero: formValues.numero!,
      carrerasGanadas: parseInt(formValues.carrerasGanadas!),
      poles: parseInt(formValues.poles!),
      top5s: parseInt(formValues.top5s!),
      top10s: parseInt(formValues.top10s!),
      campeonatos: parseInt(formValues.campeonatos!),
      edad: parseInt(formValues.edad!),
      nacionalidadId: parseInt(formValues.nacionalidad!),
      enActivo: formValues.enActivo!,
      fotoPiloto: formValues.fotoPiloto
    }
    this.posteoFormulario.emit(pilotoDTO);
  }

  ErrorCampoNombre() : string{
    let nombre = this.form.controls.nombre;
    if(nombre.hasError('required'))
    {return "Porfavor complete el campo nombre";}
    if(nombre.hasError('maxlength'))
    {return "El Nombre ingresado es demasiado largo, el maximo de caracteres son "+ nombre.getError('maxlength')?.requiredLength;}
    return "";
  }
  ErrorCampoNumero() : string{
    let numero = this.form.controls.numero;
    if(numero.hasError('required'))
    {return "Porfavor complete el campo numero";}
    if(numero.hasError('maxlength'))
    {return "El Nombre ingresado es demasiado largo, el maximo de caracteres son "+ numero.getError('maxlength')?.requiredLength;}
    return "";
  }
  ErrorCampoGenerico(FormControl: FormControl) : string{
    if(FormControl.hasError('required'))
    {return "Porfavor complete este campo";}
    if(FormControl.hasError('min'))
    {return "El valor minimo es "+ FormControl.getError('min')?.min;}
    if(FormControl.hasError('max'))
    {return "El valor maximo es "+ FormControl.getError('max')?.max;}
    return "";
  }

  archivoSelect(file: File){
    this.form.controls.fotoPiloto.setValue(file);
  } 
}
