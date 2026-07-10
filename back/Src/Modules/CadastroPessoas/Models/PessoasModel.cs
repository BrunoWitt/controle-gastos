using Src.Shared.Base;

namespace Src.Modules.CadastroPessoas.Models;
public class PessoaModel : BaseModel
{
    public required string Nome { get; set; }
    public required int Idade {get;set;}
}