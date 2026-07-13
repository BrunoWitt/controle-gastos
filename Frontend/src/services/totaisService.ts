import api from "../Api.ts";
import type {
    TotalPessoa,
    TotalGeral
} from "../models/Totais";

export interface TotaisResponse {
    //Estrutura de dados que representa a resposta da API para os totais
    pessoas: TotalPessoa[];

    geral: TotalGeral;
}

export async function buscarTotais()
//Faz requisição para o Backend para buscar os totais de pessoas e valores
{
    const response =
        await api.get<TotaisResponse>(
            "/totais"
        );

    return response.data;

}