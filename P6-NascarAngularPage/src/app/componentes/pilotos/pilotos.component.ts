import { Component, inject, OnInit } from '@angular/core';
import { PilotoService } from '../../Services/piloto.service';
import { LecturaPilotoDTO } from './LecturaPilotoDTO';
import { LoadingComponent } from "../compartidos/loading/loading.component";
import { RouterLink } from '@angular/router';
import { NgOptimizedImage } from '@angular/common';

@Component({
  selector: 'app-pilotos',
  standalone: true,
  imports: [LoadingComponent, RouterLink, NgOptimizedImage],
  templateUrl: './pilotos.component.html',
  styleUrl: './pilotos.component.css'
})
export class PilotosComponent implements OnInit {
  ngOnInit(): void {
    this.pilotosService.cargarRegistros().subscribe((respuesta: LecturaPilotoDTO[])=>{
      this.listaPilotos = respuesta;
    })
  }
  pilotosService = inject(PilotoService);
  listaPilotos!: LecturaPilotoDTO[];
}
