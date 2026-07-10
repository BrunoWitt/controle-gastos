import api from "../Api.ts";
import type {
    TotalPessoa,
    TotalGeral
} from "../models/Totais";



export interface TotaisResponse {

    pessoas: TotalPessoa[];

    geral: TotalGeral;

}



export async function buscarTotais()
{

    const response =
        await api.get<TotaisResponse>(
            "/totais"
        );


    return response.data;

}