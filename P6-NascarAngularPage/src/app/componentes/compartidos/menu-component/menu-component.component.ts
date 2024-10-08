import { Component, HostListener } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-menu-component',
  standalone: true,
  imports: [
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    RouterLink,
    NgClass,
    RouterLinkActive
  ],
  templateUrl: './menu-component.component.html',
  styleUrls: ['./menu-component.component.css']
})
export class MenuComponentComponent {
  isSmall: boolean = false;

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.checkSize(event.target.innerWidth);
  }

  ngOnInit() {
    this.checkSize(window.innerWidth);
  }

  checkSize(width: number) {
    this.isSmall = width < 991;
  }
}
