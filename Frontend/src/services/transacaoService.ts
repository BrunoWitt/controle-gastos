import api from "../Api.ts";
import type { Transacao } from "../models/Transacao";


export interface CreateTransacao {

    descricao: string;

    valor: number;

    tipo: "Receita" | "Despesa";

    pessoaId: number;

}



export async function listarTransacoes()
{
    const response =
        await api.get<Transacao[]>(
            "/transacao"
        );


    return response.data;
}


export async function criarTransacao(
    transacao: CreateTransacao
)
{

    const response =
        await api.post<Transacao>(
            "/transacao",
            transacao
        );


    return response.data;

}