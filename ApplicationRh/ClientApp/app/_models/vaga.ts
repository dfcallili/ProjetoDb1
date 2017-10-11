import { VagaTecnologia } from '../_models/index';

export interface Vaga {
    vagaId: number;
    descricao: string;
    listaVagaTecnologia: VagaTecnologia[];
    selectedTecnologia: number[];
}

export interface VagaTecnologiaCriar {
    vagaId: number;
    descricao: string;
    listaVagaTecnologia: VagaTecnologia[];
}