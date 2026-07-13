using Shared.Base;

namespace Shared.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : BaseModel
{
    /// <summary>
    /// Interface base para repositórios de entidades, definindo métodos genéricos para operações de banco de dados, como listar, buscar por ID, criar e deletar entidades.
    /// </summary>
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task CreateAsync(TEntity entity);
    Task DeleteAsync(int id);
}