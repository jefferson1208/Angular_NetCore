import { Guid } from "guid-typescript";

export interface CalculoPlano {
    custoPlanoId: Guid;
    planoId: Guid;
    tempoCliente: number;
    custoPlano: number;
    custoSemPlano: number;
}