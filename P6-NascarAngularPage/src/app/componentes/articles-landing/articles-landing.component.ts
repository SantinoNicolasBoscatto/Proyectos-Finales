import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-articles-landing',
  standalone: true,
  imports: [],
  templateUrl: './articles-landing.component.html',
  styleUrl: './articles-landing.component.css'
})
export class ArticlesLandingComponent {
  @Input({required: true})
  Detalles!: string;
  @Input({required: true})
  Titulo!: string;
  @Input({required: true})
  Imagen!: string;
  private intervalo: any;
  deslizarTexto(event: Event) {
    let scroller = event.target as HTMLElement;
      this.intervalo = setInterval(() => {
        if (scroller) {
          scroller.scrollTop = scroller.scrollTop+1;
        }
      }, 50);
  }
  detenerDeslizamiento() {
    if (this.intervalo) {
      clearInterval(this.intervalo);
    }
  }
}
