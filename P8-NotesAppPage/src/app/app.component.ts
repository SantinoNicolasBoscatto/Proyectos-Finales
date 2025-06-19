import { Component, inject, OnInit } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { UsersService } from './Service/users.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Notes-App';
  ngOnInit(): void {
    const exp = this.token.obtenerExpToken();
    if(exp) console.log(new Date(exp).getTime() - new Date().getTime())
    this.router.events.subscribe(event => {
      if(event instanceof NavigationEnd){
        this.token.renovarToken();
      }
    })
  }
  private router = inject(Router);
  private token = inject(UsersService);
}
