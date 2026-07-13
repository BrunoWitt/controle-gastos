using CadastroPessoa.Interfaces;
using CadastroPessoa.Models;

namespace CadastroPessoa.Services;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _repository;


    public PessoaService(
        IPessoaRepository repository
    )
    {
        _repository = repository;
    }


    public async Task<IEnumerable<Pessoa>> Listar()
    {
        return await _repository.GetAllAsync();
    }


    public async Task Criar(Pessoa pessoa)
    {
        /// <summary>
        /// Cria uma nova pessoa, realizando validações de negócio antes de persistir no banco de dados.
        /// </summary>
        if(string.IsNullOrWhiteSpace(pessoa.Nome))
        {
            throw new Exception("Nome obrigatório");
        }


        if(pessoa.Idade < 0)
        {
            throw new Exception("Idade inválida");
        }


        await _repository.CreateAsync(pessoa);
    }


    public async Task Deletar(int id)
    {
        await _repository.DeleteAsync(id);
    }
}