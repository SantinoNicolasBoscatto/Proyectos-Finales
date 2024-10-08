export interface LecturaNacionalidadDTO {
    id: number;
    nombre: string;
    bandera: string;
}

export interface CrearNacionalidadDTO {
    nombre: string;
    bandera: File | null | undefined;
}