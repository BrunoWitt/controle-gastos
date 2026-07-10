using ConsultaTotais.Models;

namespace ConsultaTotais.Interfaces;

public interface ITotaisRepository
{
    Task<IEnumerable<TotalPessoa>> ObterTotais();
}