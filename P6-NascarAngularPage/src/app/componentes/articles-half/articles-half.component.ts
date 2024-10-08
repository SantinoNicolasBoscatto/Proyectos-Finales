import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-articles-half',
  standalone: true,
  imports: [],
  templateUrl: './articles-half.component.html',
  styleUrl: './articles-half.component.css'
})
export class ArticlesHalfComponent {
  @Input({required: true})
  Titulo!: string;
  @Input({required: true})
  Imagen!: string;
}
