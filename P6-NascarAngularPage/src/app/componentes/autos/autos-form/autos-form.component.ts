import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Router, RouterLink } from '@angular/router';
import { MatInputModule} from '@angular/material/input';
import { CrearAutoDTO } from '../CrearAutoDTO';
import { MatSelectModule } from '@angular/material/select';
import { MarcaService } from '../../../Services/marca.service';
import { LecturaMarcaDTO } from '../../LecturaMarcaDTO';
import { LecturaAutoDTO, LecturaPilotoDTO } from '../../pilotos/LecturaPilotoDTO';
import { PilotoService } from '../../../Services/piloto.service';
import { SelectorFotosComponent } from "../../compartidos/selector-fotos/selector-fotos.component";
import { AutoService } from '../../../Services/auto.service';
import { LoadingComponent } from "../../compartidos/loading/loading.component";
import { NgClass } from '@angular/common';



@Component({
  selector: 'app-autos-form',
  standalone: true,
  imports: [MatButtonModule, MatFormFieldModule, ReactiveFormsModule, MatInputModule, RouterLink, MatSelectModule, SelectorFotosComponent, LoadingComponent, NgClass],
  templateUrl: './autos-form.component.html',
  styleUrl: './autos-form.component.css'
})
export class AutosFormComponent implements OnInit{
  ngOnInit(): void {
    this.marcaService.cargarRegistros().subscribe((res: LecturaMarcaDTO[]) => {
      this.listaMarcas = res;
      this.selectedMarca = this.modelo? this.modelo.marca.id : this.listaMarcas[0].id;
    })
    
    if (this.modelo !== undefined){
      this.pilotoService.cargarRegistros().subscribe((res: LecturaPilotoDTO[])=> {
        this.listaPilotos = res;
        this.selectedPiloto = this.modelo!.piloto.id;
      })
      const modeloConvertido = {
        ...this.modelo,
        marca: this.modelo.marca.nombre,
        piloto: this.modelo.piloto.id.toString(),
        foto: null
      }
      this.form.patchValue(modeloConvertido)
    }
    
    else{
      this.pilotoService.cargarRegistrosCarLess().subscribe((res: LecturaPilotoDTO[])=> {
        this.listaPilotos = res;
        this.selectedPiloto = this.listaPilotos[0].id;
      })
    }
  }
  private formBuilder = inject(FormBuilder);
  private marcaService = inject(MarcaService);
  private pilotoService = inject(PilotoService);
  listaMarcas!: LecturaMarcaDTO[];
  listaPilotos!: LecturaPilotoDTO[];
  form = this.formBuilder.group({
    piloto: ['', {validators: [Validators.min(1)]}],
    marca: ['', {validators: [Validators.min(1)]}],
    foto: new FormControl<File | null>(null)
  });
  selectedPiloto!: number;
  selectedMarca!: number;
  
  @Input()
  modelo?: LecturaAutoDTO;
  @Input()
  routeBack: string = "/formularios";
  @Output()
  posteoFormulario = new EventEmitter<CrearAutoDTO>();

  ErrorCampoPiloto() : string{
    let piloto = this.form.controls.piloto;
    if(piloto.hasError('min'))
    {return "Seleccione un piloto"}
    return "";
  }
  ErrorCampoMarca() : string{
    let marca = this.form.controls.marca;
    if(marca.hasError('min'))
    {return "Seleccione una marca"}
    return "";
  }

  guardarCambios() {
    const formValues = this.form.value;
    const autoDTO: CrearAutoDTO = {
      pilotoId: parseInt(formValues.piloto!),
      marcaId: parseInt(formValues.marca!),
      foto: formValues.foto
    };
    this.posteoFormulario.emit(autoDTO)
  }

  archivoSelect(file: File){
    this.form.controls.foto.setValue(file);
  }
}
