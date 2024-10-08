import { LecturaAutoDTO } from "./pilotos/LecturaPilotoDTO";

export interface LecturaMarcaDTO {
    id: number;
    nombre: string;
    foto: string;
    listaAutos: LecturaAutoDTO[];
}

export interface LecturaMarcaNombreDTO {
    id: number;
    nombre: string;
    foto: string;
}

export interface CrearMarcaDTO{
    nombre: string;
    foto: File | null | undefined;
}