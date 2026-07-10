using CadastroTransacao.Interfaces;
using CadastroTransacao.Models;
using Microsoft.Extensions.Configuration;
using Shared.Base;


namespace CadastroTransacao.Repository;

public class TransacaoRepository 
    : BaseRepository<Transacao>, ITransacaoRepository
{

    public TransacaoRepository(
        IConfiguration configuration
    ) : base(configuration)
    {

    }

}