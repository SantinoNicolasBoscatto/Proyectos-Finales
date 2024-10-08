import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FormMenuData } from '../../formularios-menu/form-data';
import { NgOptimizedImage } from '@angular/common';

@Component({
  selector: 'app-carousel-forms',
  standalone: true,
  imports: [RouterLink, NgOptimizedImage],
  templateUrl: './carousel-forms.component.html',
  styleUrl: './carousel-forms.component.css'
})
export class CarouselFormsComponent {
  @Input({required: true})
  Titulo!: string;
  @Input({required:true})
  FormMenuData!: FormMenuData[];

}

