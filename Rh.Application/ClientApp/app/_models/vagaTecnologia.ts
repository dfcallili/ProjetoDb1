export interface VagaTecnologia {
    vagaTecnologiaId: number;
    vagaId: number;
    tecnologiaId: number;
    peso?: number;
    selected: boolean;
}

export interface VagaTecnologiaEntrevista {
    vagaTecnologiaId: number;
    tecnologiaNome: string;
}