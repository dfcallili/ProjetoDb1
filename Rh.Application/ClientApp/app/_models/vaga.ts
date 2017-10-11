import { VagaTecnologia } from '../_models/index';

export interface Vaga {
    vagaId: number;
    descricao: string;
    listaVagaTecnologia: VagaTecnologia[];
    selectedTecnologia: number[];
    vagaJaEntrevistada: boolean;
}

export interface VagaTecnologiaCriar {
    vagaId: number;
    descricao: string;
    listaVagaTecnologia: VagaTecnologia[];
}