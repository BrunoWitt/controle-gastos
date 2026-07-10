using Shared.Base;

namespace CadastroPessoa.Models;

public class Pessoa : BaseModel
{
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
}