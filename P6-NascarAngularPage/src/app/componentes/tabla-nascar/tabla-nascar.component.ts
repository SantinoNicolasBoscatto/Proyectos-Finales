import { Component, inject, Input, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { LecturaPlayoffDTO } from '../posiciones-tabla-nascar/tabla-playoff';
import { NgOptimizedImage } from '@angular/common'

@Component({
  selector: 'app-tabla-nascar',
  standalone: true,
  imports: [RouterLink, MatTableModule, NgOptimizedImage],
  templateUrl: './tabla-nascar.component.html',
  styleUrl: '../posiciones-tabla-nascar/posiciones-tabla-nascar.component.css'
})
export class TablaNascarComponent {

  @Input({required: true})
  tablaLista!: any[];
  @Input({required: true})
  displayedColumns!: string[];
  @Input({required: true})
  calendario!: number;

  PrimeraLetraMayuscula(cadena: string): string {
    if (!cadena) return cadena;
    return cadena.charAt(0).toUpperCase() + cadena.slice(1);
  }
  verificarClasificado(position: LecturaPlayoffDTO, fecha: number){
    if(fecha < 28){
      if(position.clasificado16avos) return "Win";
      return position.behindPlayoff;
    }
    else if(fecha < 31){
      if(position.clasificado12avos) return "Win";
      return position.behindPlayoff;
    }
    else if(fecha < 34){
      if(position.clasificado8avos) return "Win";
      return position.behindPlayoff;
    }
    else if(fecha < 37){
      if(position.clasificadoFinal4) return "Win";
      return position.behindPlayoff;
    }
    else{
      return position.behindPlayoff;
    }
  }
}
