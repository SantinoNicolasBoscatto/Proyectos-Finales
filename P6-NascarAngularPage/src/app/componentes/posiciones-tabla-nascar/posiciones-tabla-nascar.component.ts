import { Component, inject, OnInit } from '@angular/core';
import { LecturaRegularDTO } from './tabla-regular';
import { TablaNascarComponent } from "../tabla-nascar/tabla-nascar.component";
import { LecturaManofacturaDTO } from './tabla-manofactura';
import { LecturaPlayoffDTO } from './tabla-playoff';
import { ActivatedRoute } from '@angular/router';
import { Location, NgClass } from '@angular/common';
import { TablaPilotoService } from '../../Services/tabla-piloto-service.service';
import { PistaService } from '../../Services/pista.service';
import { CalendarioDTO } from '../calendario/calendario';
import { LoadingComponent } from "../compartidos/loading/loading.component";

@Component({
  selector: 'app-posiciones-tabla-nascar',
  standalone: true,
  imports: [NgClass, TablaNascarComponent, LoadingComponent],
  templateUrl: './posiciones-tabla-nascar.component.html',
  styleUrl: './posiciones-tabla-nascar.component.css'
})
export class PosicionesTablaNascarComponent implements OnInit{
  private route = inject(ActivatedRoute);
  ngOnInit(): void {
    this.leerValoresURL();
  }
  private location = inject(Location);
  private activatedRoute = inject(ActivatedRoute);
  tablaRegularService = inject(TablaPilotoService)
  pistaService = inject(PistaService)
  tablaValueManager: number = 1;
  tablaRegular!: LecturaRegularDTO[];
  tablaPlayoff!: LecturaPlayoffDTO[];
  tablaMFR!: LecturaManofacturaDTO[];
  dispCol!: string[];
  fechaActual!: number;

  constructor(){
    this.tablaRegularService.cargarRegistros<LecturaRegularDTO>("TablaPosicionesRegular")
    .subscribe((respuesta: LecturaRegularDTO[])=> {
      this.tablaRegular = respuesta;
    });
    this.tablaRegularService.cargarRegistros<LecturaPlayoffDTO>("TablaPosicionesPlayoffReducida")
    .subscribe((respuesta: LecturaPlayoffDTO[])=> {
      this.tablaPlayoff = respuesta;
    });
    this.tablaRegularService.cargarRegistros<LecturaManofacturaDTO>("TablaPosicionesManofactura")
    .subscribe((respuesta: LecturaManofacturaDTO[])=> {
      this.tablaMFR = respuesta;
    });
    this.pistaService.traerCalendario().subscribe((respuesta: CalendarioDTO) => {
      this.fechaActual = respuesta.eventoActual;
      console.log(this.fechaActual)
    })
  }


  escribirParametrosBusquedaEnURL(page: number){
    let queryString = `tabla=${page}`;
    this.location.replaceState(`posiciones?${queryString}`)
  }
  leerValoresURL(){
    this.activatedRoute.queryParams.subscribe((params: any) => {
      if(params.tabla){
        this.tablaValueManager = Number.parseInt(params.tabla);
      }
      else{
        this.route.queryParams.subscribe(params => {
        this.tablaValueManager = +params['tabla'] || 1;
      });
      }
    });
  }
  displayTablasActualizar(e: Event){
    let anchor = e.target as HTMLAnchorElement;
    let value = anchor.getAttribute('data-value');
    this.tablaValueManager = Number.parseInt(value!);
    this.escribirParametrosBusquedaEnURL(Number.parseInt(value!))
  }
  isActiveTab(tab: number): boolean {
    return this.tablaValueManager === tab;
  }
  devolverColumnas(tab: number) : string[]{
      if(tab === 1){
        return['position', 'number','driver', 'manofactura', 'points', 'behind','wins', 'poles', 'top5s', 'top10s','dnf','lapsLead']
      }
      else if(tab === 2)return ['position', 'number','driver', 'manofactura', 'behindPlayoff']
      return ['position', 'manofactura', 'points']
  }
}
