import { Component, inject } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form-access',
  standalone: true,
  imports: [MatIconModule],
  templateUrl: './form-access.component.html',
  styleUrl: './form-access.component.css'
})
export class FormAccessComponent {
  router = inject(Router);
  llevarForms(){
    this.router.navigate(['/formularios'])
  }
}
