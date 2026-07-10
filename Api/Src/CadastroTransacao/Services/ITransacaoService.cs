using CadastroTransacao.Models;

namespace CadastroTransacao.Interfaces;

public interface ITransacaoService
{

    Task<IEnumerable<Transacao>> Listar();

    Task Criar(Transacao transacao);

}