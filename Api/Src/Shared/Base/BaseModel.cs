namespace Shared.Base;

public abstract class BaseModel
{
    /// <summary>
    /// Modelo Base para todas as entidades do sistema. Como o modelo de dados é simples tem apenas o Id como propriedade, mas caso seja necessário pode-se adicionar outras propriedades comuns a todas as entidades.
    /// </summary>
    public int Id { get; set; }
}