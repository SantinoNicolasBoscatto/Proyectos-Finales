import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import Swal from 'sweetalert2';
import { CarreraService } from '../../../Services/carrera.service';
import { tableToJson } from '../../../functions/tableToJSON';
import { actualizarPuntos, reemplazarCaracteresEspeciales } from '../../../functions/actualizarPuntos';
import { LoadingComponent } from "../../compartidos/loading/loading.component";
import { ErroresMostrarComponent } from "../../compartidos/errores-mostrar/errores-mostrar.component";
import { extraerErrores } from '../../../functions/extraerErrores';
@Component({
  selector: 'app-carrera-menu',
  standalone: true,
  imports: [SweetAlert2Module, RouterLink, LoadingComponent, ErroresMostrarComponent],
  templateUrl: './carrera-menu.component.html',
  styleUrl: './carrera-menu.component.css'
})
export class CarreraMenuComponent {
  FormMenuData: any[] = [{nombre: "Agregar Carrera", foto: "Auto.png"}, {nombre: "Reiniciar Temporada", foto: "Auto.png"}];
  private predefinedPassword = 'NascarAdmin';
  loader = false;
  private carreraService = inject(CarreraService);
  private router = inject(Router);

  showAlert() {
    Swal.fire({
      title: 'Ingrese la clave para poder reiniciar la temporada',
      input: 'password',
      inputPlaceholder: 'Clave',
      showCancelButton: true,
      confirmButtonText: 'Confirmar',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        const enteredPassword = result.value;
        if (enteredPassword === this.predefinedPassword) {
          this.carreraService.reiniciarTemporada().subscribe({
            next: () =>{
              Swal.fire('Clave correcta', '¡Confirmación exitosa!', 'success');
            },
            error: () =>{
              Swal.fire('Un error inesperado ocurrio', 'Contacte con el administrador', 'error');
            }
          });
        } else {
          Swal.fire('Clave incorrecta', 'Intenta de nuevo', 'error');
        }
      }
    });
  }
  jsonToStringWithCommas(jsonStr: string): string {
    const jsonArray = JSON.parse(jsonStr);
    return jsonArray.map((item: any) =>
      Object.values(item).join(',')
    ).join('\n');
  }  
  fileContent: string | undefined;
  errores: string[] = [];
  msgBase!: string;
  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    const file = input.files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        try {
          this.loader = true;
          const htmlContent = e.target!.result;
          const parser = new DOMParser();
          const doc = parser.parseFromString(htmlContent!.toString(), 'text/html');
          const table = doc.querySelector('table');
          if(table === null) return alert("No existe tabla en el archivo");
          let originalJSON = JSON.stringify(tableToJson(table)).replace(/\\n\\t/g, '').replace(/\\n/g, '');
          const jsonPuntos = JSON.stringify(actualizarPuntos(JSON.parse(originalJSON)), null, 2)
          const jsonLimpio = JSON.stringify(reemplazarCaracteresEspeciales(jsonPuntos), null, 2);  
          const JsonObject = JSON.parse(jsonLimpio);
          this.carreraService.crearCarrera(JsonObject).subscribe({
            next: (res: any) => {
              this.loader = false;
              this.router.navigate(["/carrera/"+res[0].evento]);
            },
            error: (err) => {
              let msgErrores = extraerErrores(err);
              this.errores = msgErrores;
              this.msgBase = err.error.message;
              let timeOut = setTimeout(() => {
                const maxScroll = document.documentElement.scrollHeight - document.documentElement.clientHeight;
                window.scrollTo({
                  top: maxScroll,
                  behavior: 'smooth' // Esto hace que el scroll sea suave
                });
                clearTimeout(timeOut);
              }, 250);
              this.loader = false;
            }
          })
        } catch (error) {
          this.loader = false;
        }
      };
      reader.readAsText(file);
    }
  }
} 
