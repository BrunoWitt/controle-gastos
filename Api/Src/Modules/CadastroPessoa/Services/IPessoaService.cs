using CadastroPessoa.Models;

namespace CadastroPessoa.Interfaces;

public interface IPessoaService
{
    Task<IEnumerable<Pessoa>> Listar();

    Task Criar(Pessoa pessoa);

    Task Deletar(int id);
}