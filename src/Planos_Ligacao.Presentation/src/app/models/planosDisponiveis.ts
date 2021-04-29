import { Guid } from "guid-typescript";

export interface PlanosDisponiveis {
    id: Guid;
    nomePlano: string;
    tempoPlano: number;
}