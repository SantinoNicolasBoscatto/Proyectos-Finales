export interface LecturaGaleriaDTO {
    id: number;
    ronda: number;
    fotoUno: string;
    fotoDos: string;
    fotoTres: string;
}

export interface CrearGaleriaDTO {
    ronda: number;
    fotoUno: File | null | undefined;
    fotoDos: File | null | undefined;
    fotoTres: File | null | undefined;
}