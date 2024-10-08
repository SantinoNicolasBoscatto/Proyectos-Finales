import { Component, OnInit } from '@angular/core';
import { CarouselFormsComponent } from "../compartidos/carousel-forms/carousel-forms.component";
import { FormMenuData } from './form-data';

@Component({
  selector: 'app-formularios-menu',
  standalone: true,
  imports: [CarouselFormsComponent],
  templateUrl: './formularios-menu.component.html',
  styleUrl: './formularios-menu.component.css'
})
export class FormulariosMenuComponent implements OnInit{
  ngOnInit(): void {
    const storedIndex = localStorage.getItem('carouselIndex');
    if (storedIndex) {
      this.currentIndex = +storedIndex;
    } else{
      this.currentIndex = 1;
    }
    this.updateActiveClass();
  }
  currentIndex!: number;

  next() {
    if(this.currentIndex === 1) this.currentIndex = 2;
    else this.currentIndex = 1;
    localStorage.setItem('carouselIndex', this.currentIndex.toString());
    this.updateActiveClass();
  }

  back() {
    if(this.currentIndex === 2) this.currentIndex = 1;
    else this.currentIndex = 2;
    localStorage.setItem('carouselIndex', this.currentIndex.toString());
    this.updateActiveClass();
  }

  updateActiveClass() {
    const items = document.querySelectorAll('.carousel-item');
    items.forEach((item, index) => {
      if (index+1 === this.currentIndex) {
        item.classList.add('active');
      } else {
        item.classList.remove('active');
      }
    });
  }

  FormData: FormMenuData[] = [{nombre: "Auto", foto: "Auto.png"}, {nombre: "Piloto", foto: "Driver.jpg"}, {nombre: "Pista", foto: "Track.webp"}, 
    {nombre: "Nacionalidad", foto: "Nacionalidad.webp"}, {nombre: "Marca", foto: "Marca.jpg"}, {nombre: "Galeria", foto: "Galeria.jpg"}, 
    {nombre: "Campeon", foto: "Campeon.jpg"}, {nombre: "Noticia", foto: "News.jpg"},{nombre: "Carrera", foto: "Race.jpg"}]
  
  FormDataIndex: FormMenuData[] = [{nombre: "Auto", foto: "Auto-Index.png"}, {nombre: "Piloto", foto: "Driver-Index.jpg"}, {nombre: "Pista", foto: "Track-index.webp"}, 
    {nombre: "Nacionalidad", foto: "Nacionalidad.webp"}, {nombre: "Marca", foto: "Marca-index.jpg"}, {nombre: "Galeria", foto: "Galeria-Index.png"}, 
    {nombre: "Campeon", foto: "Campeon-Index.png"}, {nombre: "Noticia", foto: "News.jpg"}]
}
