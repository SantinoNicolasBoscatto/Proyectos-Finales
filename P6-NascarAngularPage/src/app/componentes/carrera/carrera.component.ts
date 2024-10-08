import { Component, inject, Input, OnInit } from '@angular/core';
import { LecturaCarreraDTO } from './LecturaCarreraDTO';
import { MatTableModule } from '@angular/material/table';
import { CarreraService } from '../../Services/carrera.service';
import { LoadingComponent } from "../compartidos/loading/loading.component";

@Component({
  selector: 'app-carrera',
  standalone: true,
  imports: [MatTableModule, LoadingComponent],
  templateUrl: './carrera.component.html',
  styleUrl: './carrera.component.css'
})
export class CarreraComponent implements OnInit{
  ngOnInit(): void {
    this.carreraService.cargarRegistros(Number.parseInt(this.id, 10)).subscribe((res: LecturaCarreraDTO[]) => {
      this.listaCarrera = res;
    })
  }
  listaCarrera!: LecturaCarreraDTO[];
  displayedColumns: string[] = ["finish","numero" ,"piloto","puntos","led", "laps", "qual", "status"];
  carreraService = inject(CarreraService);
  @Input({required: true})
  id!: string;

  formatearString(cadena: string) : string{
    if(cadena === "piloto") return "Driver";
    else if(cadena === "puntos") return "Points";
    return cadena;
  }
  PrimeraLetraMayuscula(cadena: string): string {
    if (!cadena) return cadena;
    return cadena.charAt(0).toUpperCase() + cadena.slice(1);
  }
}
