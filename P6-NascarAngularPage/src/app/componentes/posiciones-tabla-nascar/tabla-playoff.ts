import { MarcaRegularTablaDTO, PilotoRegularTablaDTO } from "./tabla-regular";

export interface LecturaPlayoffDTO {
    id: number;
    puntosPlayoff: number;
    behindPlayoff: number;
    piloto: PilotoRegularTablaDTO;
    marca: MarcaRegularTablaDTO;
    clasificado16avos: boolean;
    clasificado12avos: boolean;
    clasificado8avos: boolean;
    clasificadoFinal4: boolean;
}