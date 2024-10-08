export interface LecturaPistaDTO {
    id: number;
    nombre: string;
    distancia: string;
    fotoPrimaria: string;
    fotoSecundaria: string;
    fotoTerciaria: string;
    vueltas: number;
    orden: number | null;
    disputada: boolean;
    enElCalendario: boolean;
}
export interface PatchPistaDTO {
    nombre: string;
    distancia: string;
    vueltas: number | null | undefined;
    orden: number | null | undefined;
    disputada: boolean;
    enElCalendario: boolean;
}

export interface CrearPistaDTO extends PatchPistaDTO {
    fotoPrimaria: File | null | undefined;
    fotoSecundaria: File | null | undefined;
    fotoTerciaria: File | null | undefined;
}