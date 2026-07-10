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