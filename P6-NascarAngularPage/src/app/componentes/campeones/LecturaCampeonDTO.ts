import { LecturaPilotoDTO } from "../pilotos/LecturaPilotoDTO";

export interface LecturaCampeonDTO {
    id: number;
    year: number;
    autoCampeon: string;
    piloto: LecturaPilotoDTO;
}
export interface PatchCampeonDTO {
    year: number;
    pilotoId: number;
}

export interface CrearCampeonDTO extends PatchCampeonDTO {
    autoCampeon: File | null | undefined;
}