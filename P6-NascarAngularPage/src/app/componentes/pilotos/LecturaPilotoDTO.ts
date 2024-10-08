import { LecturaMarcaNombreDTO } from "../LecturaMarcaDTO";

export interface LecturaPilotoDTO {
    id: number;
    nombre: string;
    numero: string | null;
    fotoPiloto: string;
    carrerasGanadas: number;
    poles: number;
    top5s: number;
    top10s: number;
    edad: number;
    campeonatos: number;
    enActivo: boolean;
    auto: LecturaAutoDTO;
    nacionalidad: LecturaNacionalidadDTO;
}

export interface PatchPilotoDTO {
    nombre: string;
    numero: string | null;
    carrerasGanadas: number;
    poles: number;
    top5s: number;
    top10s: number;
    campeonatos: number;
    enActivo: boolean;
    nacionalidadId: number;
    edad: number;
}

export interface CrearPilotoDTO extends PatchPilotoDTO {
    fotoPiloto: File | null | undefined;
}

export interface LecturaAutoDTO {
    id: number;
    piloto: LecturaNombrePilotoDTO;
    foto: string;
    marca: LecturaMarcaNombreDTO;
}

export interface LecturaNacionalidadDTO {
    id: number;
    nombre: string;
    bandera: string;
}

export interface LecturaNombrePilotoDTO {
    id: number;
    nombre: string;
    numero: string | null;
}
