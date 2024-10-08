import { Component, inject, OnInit } from '@angular/core';
import { ArticlesLandingComponent } from "../../articles-landing/articles-landing.component";
import { ArticlesHalfComponent } from "../../articles-half/articles-half.component";
import { FormAccessComponent } from "../../compartidos/form-access/form-access.component";
import { LecturaNoticiaDTO } from '../../NoticiaDTO';
import { NoticiasService } from '../../../Services/noticias.service';
import { LoadingComponent } from "../../compartidos/loading/loading.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [ArticlesLandingComponent, ArticlesHalfComponent, FormAccessComponent, LoadingComponent, CommonModule],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent implements OnInit{
  ngOnInit(): void {
    this.noticiaService.cargarRegistrosBig().subscribe((res: LecturaNoticiaDTO[])=> {
      this.listaBig = res;
    })
    this.noticiaService.cargarRegistrosHalf().subscribe((res: LecturaNoticiaDTO[])=> {
      this.listaHalfCompleta = res;
      this.cargaListaHalf();
    })
  }
  private noticiaService = inject(NoticiasService)
  listaBig!: LecturaNoticiaDTO[];
  listaHalfCompleta!: LecturaNoticiaDTO[];
  halfCarga: LecturaNoticiaDTO[] = [];

  RemoverHalfList(){
    this.listaHalfCompleta.splice(0,2);
  }

  cargaListaHalf(){
    let index = 0;
    for (const element of this.listaHalfCompleta) {
      console.log(element)
      index++;
      this.halfCarga.push(element);
      if(index >=2) break;
    }
  }
}
