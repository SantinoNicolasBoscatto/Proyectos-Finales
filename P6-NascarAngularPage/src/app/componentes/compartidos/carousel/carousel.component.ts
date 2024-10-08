import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-carousel',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './carousel.component.html',
  styleUrl: './carousel.component.css'
})
export class CarouselComponent {
  @Input({required: true})
  IdComponent!: string;

  @Input({required:true})
  Img1!: string;
  @Input({required:true})
  Img2!: string;
  @Input({required:true})
  Img3!: string;
  @Input({required:true})
  NombrePista!: string;
  @Input({required:true})
  Distancia!: string;
  @Input({required:true})
  Vueltas!: number;
  @Input({required:true})
  Disputada!: boolean;
}
