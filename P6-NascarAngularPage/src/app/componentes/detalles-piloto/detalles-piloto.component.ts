import { Component, inject, Input, OnInit } from '@angular/core';
import { PilotoService } from '../../Services/piloto.service';
import { LecturaPilotoDTO } from '../pilotos/LecturaPilotoDTO';
import { Router, RouterLink } from '@angular/router';
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
    this.cargarPiloto();
  }
  @Input({required:true})
  id!: string;
  prev!: number | null;
  next!: number | null;
  pilotoDTO!: LecturaPilotoDTO;
  pilotoService = inject(PilotoService);
  router = inject(Router);

  changeDriver(id: number | null){
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(["pilotos", id]); 
    });
  }
  cargarPiloto(){
    this.pilotoService.obtenerRegistroPorId(parseInt(this.id)).subscribe((res: LecturaPilotoDTO) => {
      this.pilotoDTO = res;
    })
    this.pilotoService.prevNext(parseInt(this.id)).subscribe((res: any)=>{
      this.prev = res["item1"];
      this.next = res["item2"];
    })
  }
}
