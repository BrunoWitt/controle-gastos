import api from "../Api.ts";
import type { Pessoa } from "../models/Pessoa";


export async function listarPessoas()
{
    const response = await api.get<Pessoa[]>(
        "/pessoa"
    );

    return response.data;
}


export async function buscarPessoas()
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
{

    const response = await api.post<Pessoa>(
        "/pessoa",
        pessoa
    );


    return response.data;

}