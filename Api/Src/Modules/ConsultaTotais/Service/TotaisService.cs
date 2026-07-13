using ConsultaTotais.Interfaces;
using ConsultaTotais.Models;

namespace ConsultaTotais.Services;

public class TotaisService : ITotaisService
{
    private readonly ITotaisRepository _repository;


    public TotaisService(
        ITotaisRepository repository
    )
    {
        _repository = repository;
    }


    public async Task<object> Consultar()
    {
        /// <summary>
        /// Consulta os totais de receitas, despesas e saldo das pessoas cadastradas.
        /// </summary>
        /// <returns>Retorna um objeto com os totais calculados.</returns>

        var pessoas =
            await _repository.ObterTotais();

        return new
        {
            Pessoas = pessoas,

            TotalGeralReceitas =
                pessoas.Sum(x => x.TotalReceitas),


            TotalGeralDespesas =
                pessoas.Sum(x => x.TotalDespesas),


            Saldo =
                pessoas.Sum(x => x.Saldo)
        };

    }

}