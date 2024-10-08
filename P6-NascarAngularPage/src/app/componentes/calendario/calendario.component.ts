import { Component, inject, OnInit } from '@angular/core';
import { CarouselComponent } from "../compartidos/carousel/carousel.component";
import { PistaService } from '../../Services/pista.service';
import { LecturaPistaDTO } from './LecturaPistaDTO';
import { LoadingComponent } from "../compartidos/loading/loading.component";

@Component({
  selector: 'app-calendario',
  standalone: true,
  imports: [CarouselComponent, LoadingComponent],
  templateUrl: './calendario.component.html',
  styleUrl: './calendario.component.css'
})
export class CalendarioComponent implements OnInit{
  ngOnInit(): void {
    this.pistaService.cargarRegistros().subscribe((respuesta: LecturaPistaDTO[]) => {
      this.listaPistas = respuesta;
   });
  }
  pistaService = inject(PistaService);
  listaPistas! : LecturaPistaDTO[];

}
