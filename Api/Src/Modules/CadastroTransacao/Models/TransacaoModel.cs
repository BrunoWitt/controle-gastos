using Shared.Base;

namespace CadastroTransacao.Models;

public class Transacao : BaseModel
{
    public string Descricao { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public TipoTransacao Tipo { get; set; }

    public int PessoaId { get; set; }
}


public enum TipoTransacao
{
    Despesa = 1,
    Receita = 2
}