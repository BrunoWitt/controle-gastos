using ConsultaTotais.Models;

namespace ConsultaTotais.Interfaces;

public interface ITotaisService
{
    Task<object> Consultar();
}