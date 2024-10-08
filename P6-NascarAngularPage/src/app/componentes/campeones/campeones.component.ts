import { Component, inject, OnInit } from '@angular/core';
import { CampeonesService } from '../../Services/campeones.service';
import { LecturaCampeonDTO } from './LecturaCampeonDTO';
import { LoadingComponent } from "../compartidos/loading/loading.component";
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-campeones',
  standalone: true,
  imports: [LoadingComponent, MatIconModule],
  templateUrl: './campeones.component.html',
  styleUrl: './campeones.component.css'
})
export class CampeonesComponent implements OnInit {
  ngOnInit(): void {
    this.campeonesService.cargarRegistros().subscribe((respuesta: LecturaCampeonDTO[])=> {
      this.listaCampeones = respuesta;
    })
  }
  campeonesService = inject(CampeonesService);
  listaCampeones!: LecturaCampeonDTO[];
}
