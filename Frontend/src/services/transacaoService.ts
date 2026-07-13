import api from "../Api.ts";
import type { Transacao } from "../models/Transacao";


export interface CreateTransacao {
//Estrutura de dados que representa uma transação a ser criada
    descricao: string;

    valor: number;

    tipo: "Receita" | "Despesa";

    pessoaId: number;

}



export async function listarTransacoes()
//Faz requisição para o Backend para listar todas as transações cadastradas
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
//Faz requisição para o Backend para criar uma nova transação
{
    const response =
        await api.post<Transacao>(
            "/transacao",
            transacao
        );

    return response.data;

}