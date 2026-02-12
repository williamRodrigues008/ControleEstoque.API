import { itemMovimentado } from "./itemMovimentado";

export interface movimentacao{
    id?: number;
    local: string;
    dataMovimentacao: Date;
    itensMovimentacao: itemMovimentado[];
    solicitante: string;
    responsavel: string;
}