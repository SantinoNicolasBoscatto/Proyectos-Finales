import { Observable } from "rxjs";
import { CrearPilotoDTO, LecturaPilotoDTO } from "../../pilotos/LecturaPilotoDTO";

export interface IServicioCRUD<LecturaDTO, CrearDTO>{
    cargarRegistros() : Observable<LecturaDTO[]>;
    obtenerRegistroPorId(id: number) : Observable<LecturaDTO>;
    crearRegistro(entidad: CrearDTO) : Observable<any>;
    editarRegistro(id: number,entidad: CrearDTO) : Observable<any>;
    borrarRegistro(id: number) : Observable<any>;
}
