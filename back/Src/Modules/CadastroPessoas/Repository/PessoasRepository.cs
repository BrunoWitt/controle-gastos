using Npgsql;
using Src.Modules.CadastroPessoas.Models;
using Src.Shared.Base;

namespace Src.Modules.CadastroPessoas.Repository;

public class PessoasRepository : BaseRepository<PessoaModel>
{
    protected override string TableName => "pessoas";


    protected override PessoaModel Map(NpgsqlDataReader reader)
    {
        return new PessoaModel
        {
            Id = reader.GetInt32(reader.GetOrdinal("id")),
            Nome = reader.GetString(reader.GetOrdinal("nome")),
            Idade = reader.GetInt32(reader.GetOrdinal("idade"))
        };
    }


    public override async Task<int> CreateAsync(PessoaModel pessoa)
    {
        var query = """
            INSERT INTO pessoas(nome, idade)
            VALUES (@nome, @idade)
            RETURNING id;
            """;

        return await ExecuteScalarAsync(query, cmd =>
        {
            cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@idade", pessoa.Idade);
        });
    }


    public override async Task<bool> UpdateAsync(PessoaModel pessoa)
    {
        var query = """
            UPDATE pessoas
            SET nome = @nome,
                idade = @idade
            WHERE id = @id;
            """;


        var result = await ExecuteAsync(query, cmd =>
        {
            cmd.Parameters.AddWithValue("@id", pessoa.Id);
            cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@idade", pessoa.Idade);
        });


        return result > 0;
    }
}