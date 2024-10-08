import { Component, inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { MenuComponentComponent } from "./componentes/compartidos/menu-component/menu-component.component";
import { LandingPageComponent } from "./componentes/landing-page/landing-page/landing-page.component";
import { FooterComponent } from "./componentes/compartidos/footer/footer.component";
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MenuComponentComponent, LandingPageComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'NascarPage';
  private scrollListener!: () => void;
  private router = inject(Router);
  showFooter = true;
  
  constructor(private renderer: Renderer2) {}
  ngOnInit() {
    this.router.events.pipe(filter(event => event instanceof NavigationEnd))
    .subscribe((event: NavigationEnd)=>{
      this.showFooter = !event.urlAfterRedirects.startsWith('/formularios');
    })
    this.checkScroll();
  }
  ngOnDestroy() {
    if (this.scrollListener) {
      this.scrollListener();
    }
  }
  checkScroll(): void {
    this.scrollListener = this.renderer.listen('window', 'scroll', () => {
      const footer = document.querySelector('app-footer')?.children[0];
      if(footer !== null && footer !== undefined){
        const scrollPosition = window.scrollY + window.innerHeight;
        const maxScroll = document.documentElement.scrollHeight;
        if (maxScroll - scrollPosition > 15) {
          this.renderer.addClass(footer, 'hidden'); // Añade la clase 'hidden' para ocultar el footer
        } else {
          this.renderer.removeClass(footer, 'hidden'); // Remueve la clase 'hidden' para mostrar el footer
        }
      }
    });
  }
}
