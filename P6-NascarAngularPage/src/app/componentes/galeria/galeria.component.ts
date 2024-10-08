import { Component, inject, OnInit } from '@angular/core';
import { GaleriaService } from '../../Services/galeria.service';
import { LecturaGaleriaDTO } from './galeria';
import { LecturaPistaDTO } from '../calendario/LecturaPistaDTO';
import { PistaService } from '../../Services/pista.service';
import { LoadingComponent } from "../compartidos/loading/loading.component";

@Component({
  selector: 'app-galeria',
  standalone: true,
  imports: [LoadingComponent],
  templateUrl: './galeria.component.html',
  styleUrl: './galeria.component.css'
})
export class GaleriaComponent implements OnInit{
  ngOnInit(): void {
    this.galeriaService.cargarRegistros().subscribe((res: LecturaGaleriaDTO[]) => {
      this.listaGaleria = res;
      for (const element of this.listaGaleria) {
        this.pistaService.obtenerRegistroPorOrden(element.ronda).subscribe((res: LecturaPistaDTO)=>{
          this.listaNombrePista.push(res.nombre);
        })
      }
    })
  }
  private galeriaService = inject(GaleriaService);
  private pistaService = inject(PistaService);
  listaGaleria!: LecturaGaleriaDTO[];
  listaNombrePista: string[] = [];
}
