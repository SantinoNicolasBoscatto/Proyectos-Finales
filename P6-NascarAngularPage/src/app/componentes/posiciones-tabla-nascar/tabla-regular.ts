export interface LecturaRegularDTO{
    id: number;
    piloto: PilotoRegularTablaDTO;
    marca: MarcaRegularTablaDTO;
    wins: number;
    poles: number;
    top5s: number;
    top10s: number;
    dnf: number;
    lapsLead: number;
    puntos: number;
    behind: number;
    
}
export interface MarcaRegularTablaDTO{
    id: number;
    nombre: string;
    foto: string;
}
export interface PilotoRegularTablaDTO{
    id: number;
    nombre: string;
    numero?: string;
}

