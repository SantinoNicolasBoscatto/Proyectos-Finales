export interface LecturaNoticiaDTO {
    id: number;
    titulo: string;
    foto: string;
    detalles: string | null | undefined;
}

export interface CrearNoticiaDTO {
    titulo: string;
    foto: File | null | undefined;
    detalles: string | null | undefined;
}