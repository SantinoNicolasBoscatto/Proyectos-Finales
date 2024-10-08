import { Component, inject, Input, OnInit } from '@angular/core';
import { PilotoService } from '../../Services/piloto.service';
import { LecturaPilotoDTO } from '../pilotos/LecturaPilotoDTO';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-detalles-piloto',
  standalone: true,
  imports: [RouterLink, MatButtonModule],
  templateUrl: './detalles-piloto.component.html',
  styleUrl: './detalles-piloto.component.css'
})
export class DetallesPilotoComponent implements OnInit{
  ngOnInit(): void {
    this.pilotoService.obtenerRegistroPorId(parseInt(this.id)).subscribe((res: LecturaPilotoDTO) => {
      this.pilotoDTO = res;
    })
  }
  @Input({required:true})
  id!: string;
  pilotoDTO!: LecturaPilotoDTO;
  pilotoService = inject(PilotoService);
}
