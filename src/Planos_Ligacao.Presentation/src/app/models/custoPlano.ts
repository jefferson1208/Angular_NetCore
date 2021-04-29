import { Guid } from "guid-typescript";

export interface CustoPlano {
    id: Guid;
    origem: string;
    destino: string;
    custoMinuto: number;
}