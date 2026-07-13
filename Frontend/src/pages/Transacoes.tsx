import {
    useEffect,
    useState
} from "react";

import type { Transacao } from "../models/Transacao";

import type { Pessoa } from "../models/Pessoa";

import {
    listarTransacoes,
    criarTransacao
} from "../services/transacaoService";

import {
    buscarPessoas
} from "../services/pessoaService";

function Transacoes()
{
    const [transacoes,setTransacoes]
        = useState<Transacao[]>([]);

    const [pessoas,setPessoas]
        = useState<Pessoa[]>([]);

    const [descricao,setDescricao]
        = useState("");

    const [valor,setValor]
        = useState(0);

    const [tipo,setTipo]
        = useState<"Receita"|"Despesa">(
            "Despesa"
        );

    const [pessoaId,setPessoaId]
        = useState(0);

    useEffect(()=>{

        carregar();

    },[]);

    async function carregar()
    {

        const transacoes =
            await listarTransacoes();


        const pessoas =
            await buscarPessoas();

        setTransacoes(transacoes);

        setPessoas(pessoas);

    }

    async function cadastrar()
    {

        await criarTransacao({

            descricao,

            valor,

            tipo,

            pessoaId

        });


        setDescricao("");

        setValor(0);


        carregar();

    }

    return (

        <>

        <h1>
            Transações
        </h1>

        <div>
            <input

                placeholder="Descrição"

                value={descricao}

                onChange={
                    e=>setDescricao(e.target.value)
                }

            />
            <input

                type="number"

                placeholder="Valor"

                value={valor}

                onChange={
                    e=>setValor(
                        Number(e.target.value)
                    )
                }

            />
            <select

                value={tipo}

                onChange={
                    e=>setTipo(
                        e.target.value as "Receita"|"Despesa"
                    )
                }
            >
                <option value="Receita">
                    Receita
                </option>


                <option value="Despesa">
                    Despesa
                </option>
            </select>

            <select

                value={pessoaId}

                onChange={
                    e=>setPessoaId(
                        Number(e.target.value)
                    )
                }

            >

                <option value="0">
                    Selecione pessoa
                </option>

                {
                    pessoas.map(pessoa=>(

                        <option
                            key={pessoa.id}
                            value={pessoa.id}
                        >

                            {pessoa.nome}

                        </option>

                    ))
                }
            </select>

            <button onClick={cadastrar}>
                Cadastrar
            </button>
        </div>
        <hr/>

        <table>
            <thead>
                <tr>
                    <th>
                        Descrição
                    </th>

                    <th>
                        Valor
                    </th>

                    <th>
                        Tipo
                    </th>

                    <th>
                        Pessoa
                    </th>
                </tr>
            </thead>
            <tbody>
            {
                transacoes.map(t=>(

                    <tr key={t.id}>

                        <td>
                            {t.descricao}
                        </td>

                        <td>
                            R$ {t.valor}
                        </td>

                        <td>
                            {t.tipo}
                        </td>

                        <td>
                            {t.pessoaId}
                        </td>

                    </tr>

                ))
            }
            </tbody>

        </table>
        </>
    );
}

export default Transacoes;