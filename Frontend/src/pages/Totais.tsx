import {
    useEffect,
    useState
} from "react";

import {
    buscarTotais
} from "../services/totaisService";


import type {
    TotalPessoa,
    TotalGeral
} from "../models/Totais";



function Totais()
{


    const [pessoas,setPessoas]
        = useState<TotalPessoa[]>([]);


    const [geral,setGeral]
        = useState<TotalGeral>();



    useEffect(()=>{

        carregar();

    },[]);



    async function carregar()
    {

        const dados =
            await buscarTotais();


        setPessoas(
            dados.pessoas
        );


        setGeral(
            dados.geral
        );

    }



    return (

        <>

        <h1>
            Totais
        </h1>



        <table>


        <thead>

            <tr>

                <th>
                    Pessoa
                </th>


                <th>
                    Receitas
                </th>


                <th>
                    Despesas
                </th>


                <th>
                    Saldo
                </th>

            </tr>

        </thead>



        <tbody>


        {
            pessoas.map(pessoa=>(

                <tr key={pessoa.pessoaId}>


                    <td>
                        {pessoa.nome}
                    </td>


                    <td>
                        R$ {pessoa.totalReceitas}
                    </td>


                    <td>
                        R$ {pessoa.totalDespesas}
                    </td>


                    <td>
                        R$ {pessoa.saldo}
                    </td>


                </tr>

            ))
        }


        </tbody>


        </table>



        {
            geral &&

            <>

            <h2>
                Total Geral
            </h2>


            <p>
                Receitas:
                R$ {geral.totalReceitas}
            </p>


            <p>
                Despesas:
                R$ {geral.totalDespesas}
            </p>


            <p>
                Saldo:
                R$ {geral.saldo}
            </p>


            </>

        }



        </>

    );

}


export default Totais;