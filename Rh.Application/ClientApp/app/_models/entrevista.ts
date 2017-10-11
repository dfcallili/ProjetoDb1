import { EntrevistaTecnologia } from '../_models/index';

export interface Entrevista {
    entrevistaId: number;
    vagaId: number;
    vagaDescricao: string;
    candidatoId: number;
    candidatoNome: string;
    dataEntrevista: Date;
    listaEntrevistaTecnologia: EntrevistaTecnologia[];
}

export interface EntrevistaCriar {
    entrevistaId: number;
    vagaId: number;
    candidatoId: number;
    dataEntrevista: Date;
    listaEntrevistaTecnologia: EntrevistaTecnologia[];
}