import { useEffect, useState } from "react";
import type { Pessoa } from "../models/Pessoa";
import {
    listarPessoas,
    criarPessoa
} from "../services/pessoaService";


function Pessoas(){
    const [pessoas, setPessoas] = useState<Pessoa[]>([]);

    const [nome, setNome] = useState("");

    const [idade, setIdade] = useState(0);

    useEffect(()=>{

        carregarPessoas();

    },[]);

    async function carregarPessoas()
    {

        const dados = await listarPessoas();

        setPessoas(dados);

    }

    async function cadastrar()
    {

        await criarPessoa({
            nome,
            idade
        });


        setNome("");

        setIdade(0);

        carregarPessoas();

    }

    return (
        <>
        <h1>
            Pessoas
        </h1>

        <div>
            <input
                placeholder="Nome"
                value={nome}
                onChange={
                    e => setNome(e.target.value)
                }
            />

            <input
                type="number"
                placeholder="Idade"
                value={idade}
                onChange={
                    e => setIdade(Number(e.target.value))
                }
            />

            <button onClick={cadastrar}>
                Cadastrar
            </button>
        </div>
        <hr/>

        <table>
            <thead>
                <tr>
                    <th>
                        Id
                    </th>

                    <th>
                        Nome
                    </th>

                    <th>
                        Idade
                    </th>
                </tr>
            </thead>

            <tbody>
            {
                pessoas.map(pessoa => (

                    <tr key={pessoa.id}>

                        <td>
                            {pessoa.id}
                        </td>

                        <td>
                            {pessoa.nome}
                        </td>

                        <td>
                            {pessoa.idade}
                        </td>

                    </tr>
                ))
            }
            </tbody>

        </table>

        </>
    )
}

export default Pessoas;