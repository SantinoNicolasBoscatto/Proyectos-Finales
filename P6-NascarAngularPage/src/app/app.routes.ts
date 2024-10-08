import { Routes } from '@angular/router';
import { PosicionesTablaNascarComponent } from './componentes/posiciones-tabla-nascar/posiciones-tabla-nascar.component';
import { LandingPageComponent } from './componentes/landing-page/landing-page/landing-page.component';
import { CalendarioComponent } from './componentes/calendario/calendario.component';
import { PilotosComponent } from './componentes/pilotos/pilotos.component';
import { GaleriaComponent } from './componentes/galeria/galeria.component';
import { CampeonesComponent } from './componentes/campeones/campeones.component';
import { CarreraComponent } from './componentes/carrera/carrera.component';
import { DetallesPilotoComponent } from './componentes/detalles-piloto/detalles-piloto.component';
import { FormulariosMenuComponent } from './componentes/formularios-menu/formularios-menu.component';
import { CrearAutosComponent } from './componentes/autos/crear-autos/crear-autos.component';
import { CrearPilotosComponent } from './componentes/pilotos/crear-pilotos/crear-pilotos.component';
import { CrearPistasComponent } from './componentes/pistas/crear-pistas/crear-pistas.component';
import { CrearNacionalidadComponent } from './componentes/nacionalidad/crear-nacionalidad/crear-nacionalidad.component';
import { CrearMarcaComponent } from './componentes/marcas/crear-marca/crear-marca.component';
import { CrearGaleriaComponent } from './componentes/galeria/crear-galeria/crear-galeria.component';
import { CrearCampeonComponent } from './componentes/campeones/crear-campeon/crear-campeon.component';
import { PilotosIndexComponent } from './componentes/pilotos/pilotos-index/pilotos-index.component';
import { TablaIndexComponent } from './componentes/compartidos/tabla-index/tabla-index.component';
import { PistasIndexComponent } from './componentes/pistas/pistas-index/pistas-index.component';
import { AutosIndexComponent } from './componentes/autos/autos-index/autos-index.component';
import { NacionalidadIndexComponent } from './componentes/nacionalidad/nacionalidad-index/nacionalidad-index.component';
import { MarcasIndexComponent } from './componentes/marcas/marcas-index/marcas-index.component';
import { GaleriaIndexComponent } from './componentes/galeria/galeria-index/galeria-index.component';
import { CampeonesIndexComponent } from './componentes/campeones/campeones-index/campeones-index.component';
import { EditarAutosComponent } from './componentes/autos/editar-autos/editar-autos.component';
import { EditarPilotosComponent } from './componentes/pilotos/editar-pilotos/editar-pilotos.component';
import { EditarNacionalidadComponent } from './componentes/nacionalidad/editar-nacionalidad/editar-nacionalidad.component';
import { EditarMarcasComponent } from './componentes/marcas/editar-marcas/editar-marcas.component';
import { EditarGaleriaComponent } from './componentes/galeria/editar-galeria/editar-galeria.component';
import { EditarCampeonesComponent } from './componentes/campeones/editar-campeones/editar-campeones.component';
import { EditarPistasComponent } from './componentes/pistas/editar-pistas/editar-pistas.component';
import { CarreraMenuComponent } from './componentes/carreras/carrera-menu/carrera-menu.component';
import { CrearNoticiasComponent } from './componentes/noticias/crear-noticias/crear-noticias.component';
import { EditarNoticiasComponent } from './componentes/noticias/editar-noticias/editar-noticias.component';
import { NoticiasIndexComponent } from './componentes/noticias/noticias-index/noticias-index.component';

export const routes: Routes = [
    {path: '', component: LandingPageComponent},
    {path: "posiciones", component: PosicionesTablaNascarComponent},
    {path: "calendario", component: CalendarioComponent},
    {path: "pilotos/:id", component: DetallesPilotoComponent},
    {path: "pilotos", component: PilotosComponent},
    {path: "galeria", component: GaleriaComponent},
    {path: "campeones", component: CampeonesComponent},
    {path: "carrera/:id", component: CarreraComponent},
    {path: "formularios", component: FormulariosMenuComponent},

    //Rutas Forms
    {path: "formularios/agregar/auto", component: CrearAutosComponent},
    {path: "formularios/agregar/piloto", component: CrearPilotosComponent},
    {path: "formularios/agregar/pista", component: CrearPistasComponent},
    {path: "formularios/agregar/nacionalidad", component: CrearNacionalidadComponent},
    {path: "formularios/agregar/marca", component: CrearMarcaComponent},
    {path: "formularios/agregar/galeria", component: CrearGaleriaComponent},
    {path: "formularios/agregar/campeon", component: CrearCampeonComponent},
    {path: "formularios/agregar/noticia", component: CrearNoticiasComponent},
    {path: "formularios/agregar/carrera", component: CarreraMenuComponent},

    {path: "formularios/index/auto", component: AutosIndexComponent},
    {path: "formularios/index/piloto", component: PilotosIndexComponent},
    {path: "formularios/index/pista", component: PistasIndexComponent},
    {path: "formularios/index/nacionalidad", component: NacionalidadIndexComponent},
    {path: "formularios/index/marca", component: MarcasIndexComponent},
    {path: "formularios/index/galeria", component: GaleriaIndexComponent},
    {path: "formularios/index/campeon", component: CampeonesIndexComponent},
    {path: "formularios/index/noticia", component: NoticiasIndexComponent},


    {path: "formularios/index/auto/:id", component: EditarAutosComponent},
    {path: "formularios/index/piloto/:id", component: EditarPilotosComponent},
    {path: "formularios/index/pista/:id", component: EditarPistasComponent},
    {path: "formularios/index/nacionalidad/:id", component: EditarNacionalidadComponent},
    {path: "formularios/index/marca/:id", component: EditarMarcasComponent},
    {path: "formularios/index/galeria/:id", component: EditarGaleriaComponent},
    {path: "formularios/index/campeon/:id", component: EditarCampeonesComponent},
    {path: "formularios/index/noticia/:id", component: EditarNoticiasComponent},


    // Fin Ruta Forms

    {path: "**", redirectTo: ''}
];
