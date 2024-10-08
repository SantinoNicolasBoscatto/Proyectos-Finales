export interface PatchAutoDTO {
    pilotoId: number | null;
    marcaId: number;
}

export interface CrearAutoDTO extends PatchAutoDTO {
    foto: File | null | undefined;
}