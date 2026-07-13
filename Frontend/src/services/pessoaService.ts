import api from "../Api.ts";
import type { Pessoa } from "../models/Pessoa";


export async function listarPessoas()
//Faz requisição para o Backend para listar todas as pessoas cadastradas
{
    const response = await api.get<Pessoa[]>(
        "/pessoa"
    );

    return response.data;
}

export async function buscarPessoas()
//Faz requisição para o Backend para buscar todas as pessoas cadastradas
{
    const response =
        await api.get<Pessoa[]>(
            "/pessoa"
        );


    return response.data;
}

export async function criarPessoa(
    pessoa: Omit<Pessoa, "id">
)
//Faz requisição para o Backend para criar uma nova pessoa
{
    const response = await api.post<Pessoa>(
        "/pessoa",
        pessoa
    );

    return response.data;

}