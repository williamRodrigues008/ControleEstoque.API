import { itemMovimentado } from "./itemMovimentado";

export interface movimentacao{
    id?: number;
    local: string;
    dataMovimentacao: Date;
    itensMovimentados: itemMovimentado[];
    solicitante: string;
    responsavel: string;
}