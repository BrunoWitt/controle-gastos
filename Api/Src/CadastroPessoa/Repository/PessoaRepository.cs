using CadastroPessoa.Models;
using CadastroPessoa.Interfaces;
using Shared.Base;
using Microsoft.Extensions.Configuration;


namespace CadastroPessoa.Repository;

public class PessoaRepository 
    : BaseRepository<Pessoa>, IPessoaRepository
{

    public PessoaRepository(
        IConfiguration configuration
    ) : base(configuration)
    {

    }
}