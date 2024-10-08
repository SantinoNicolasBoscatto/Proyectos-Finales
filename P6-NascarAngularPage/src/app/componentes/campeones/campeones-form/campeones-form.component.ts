import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, NgModel, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { RouterLink } from '@angular/router';
import { PilotoService } from '../../../Services/piloto.service';
import { LecturaPilotoDTO } from '../../pilotos/LecturaPilotoDTO';
import { CrearCampeonDTO, LecturaCampeonDTO } from '../LecturaCampeonDTO';
import { SelectorFotosComponent } from "../../compartidos/selector-fotos/selector-fotos.component";
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-campeones-form',
  standalone: true,
  imports: [MatButtonModule, MatFormFieldModule, ReactiveFormsModule, MatInputModule, RouterLink, MatSelectModule, SelectorFotosComponent, NgClass],
  templateUrl: './campeones-form.component.html',
  styleUrl: './campeones-form.component.css'
})
export class CampeonesFormComponent implements OnInit{
  ngOnInit(): void {
    this.pilotosService.cargarRegistrosCampeones().subscribe((res: LecturaPilotoDTO[])=>{
      this.pilotosCampeonesList = res;
      this.selectedOptionPilotoId = this.modelo? this.modelo.piloto.id : res[0].id
    });
    if (this.modelo !== undefined){
      const modeloConvertido = {
        ...this.modelo,
        id: this.modelo.id,
        year: this.modelo.year.toString(),
        autoCampeon: null
    };
      this.form.patchValue(modeloConvertido);
    }
  }
  private formBuilder = inject(FormBuilder);
  private pilotosService = inject(PilotoService);
  pilotosCampeonesList!: LecturaPilotoDTO[];
  selectedOptionPilotoId!: number;

  form = this.formBuilder.group({
    year: ['',{validators: [Validators.min(1900), Validators.max(9999), Validators.required]}],
    pilotoId: ['', {validators: [Validators.min(1)]}],
    autoCampeon: new FormControl<File | null>(null)
  });

  @Input()
  modelo?: LecturaCampeonDTO;
  @Input()
  routeBack: string = "/formularios";
  @Output()
  posteoFormulario = new EventEmitter<CrearCampeonDTO>();

  guardarCambios(){
    const formValues = this.form.value;
    const champDTO: CrearCampeonDTO = {
      pilotoId: parseInt(formValues.pilotoId!),
      year: parseInt(formValues.year!),
      autoCampeon: formValues.autoCampeon
    }
    this.posteoFormulario.emit(champDTO);
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

  ErroCampoPiloto(){
    let piloto = this.form.controls.pilotoId;
    if(piloto.hasError('min'))
    {return "Seleccione un piloto"}
    return "";
  }

  archivoSelect(file: File){
    this.form.controls.autoCampeon.setValue(file);
  }
}
