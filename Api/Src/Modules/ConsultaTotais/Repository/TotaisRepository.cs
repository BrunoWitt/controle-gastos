using ConsultaTotais.Interfaces;
using ConsultaTotais.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;


namespace ConsultaTotais.Repository;


public class TotaisRepository : ITotaisRepository
{

    private readonly IConfiguration _configuration;


    public TotaisRepository(
        IConfiguration configuration
    )
    {
        _configuration = configuration;
    }



    private NpgsqlConnection Connection =>
        new(
            _configuration
            .GetConnectionString("Default")
        );



    public async Task<IEnumerable<TotalPessoa>> ObterTotais()
    {

        var lista = new List<TotalPessoa>();


        var sql = """
            SELECT 
                p.id,
                p.nome,

                COALESCE(
                    SUM(
                        CASE 
                            WHEN t.tipo = 'RECEITA'
                            THEN t.valor 
                            ELSE 0 
                        END
                    ),0
                ) AS receitas,


                COALESCE(
                    SUM(
                        CASE 
                            WHEN t.tipo = 'DESPESA'
                            THEN t.valor 
                            ELSE 0 
                        END
                    ),0
                ) AS despesas


            FROM pessoa p

            LEFT JOIN transacao t
                ON t.pessoa_id = p.id

            GROUP BY 
                p.id,
                p.nome

            ORDER BY 
                p.nome;
            """;



        using var connection = Connection;

        await connection.OpenAsync();



        using var command =
            new NpgsqlCommand(
                sql,
                connection
            );



        using var reader =
            await command.ExecuteReaderAsync();



        while(await reader.ReadAsync())
        {

            lista.Add(
                new TotalPessoa
                {
                    PessoaId = reader.GetInt32(0),

                    Nome = reader.GetString(1),

                    TotalReceitas =
                        reader.GetDecimal(2),

                    TotalDespesas =
                        reader.GetDecimal(3)
                }
            );

        }


        return lista;

    }

}