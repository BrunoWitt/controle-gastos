using CadastroPessoa.Interfaces;
using CadastroTransacao.Interfaces;
using CadastroTransacao.Models;


namespace CadastroTransacao.Services;

public class TransacaoService : ITransacaoService
{

    private readonly ITransacaoRepository _repository;

    private readonly IPessoaRepository _pessoaRepository;



    public TransacaoService(
        ITransacaoRepository repository,
        IPessoaRepository pessoaRepository
    )
    {
        _repository = repository;
        _pessoaRepository = pessoaRepository;
    }



    public async Task<IEnumerable<Transacao>> Listar()
    {
        return await _repository.GetAllAsync();
    }



    public async Task Criar(
        Transacao transacao
    )
    {

        var pessoa =
            await _pessoaRepository.GetByIdAsync(
                transacao.PessoaId
            );


        if(pessoa == null)
        {
            throw new Exception(
                "Pessoa não encontrada"
            );
        }

        if(
            pessoa.Idade < 18 &&
            transacao.Tipo == TipoTransacao.Receita
        )
        {
            throw new Exception(
                "Menores de idade não podem possuir receitas"
            );
        }

        if(transacao.Valor <= 0)
        {
            throw new Exception(
                "O valor deve ser maior que zero"
            );
        }

        if(string.IsNullOrWhiteSpace(transacao.Descricao))
        {
            throw new Exception(
                "Descrição obrigatória"
            );
        }

        await _repository.CreateAsync(transacao);

    }

}