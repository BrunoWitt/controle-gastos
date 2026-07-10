using Shared.Base;

namespace Shared.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : BaseModel
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task CreateAsync(TEntity entity);
    Task DeleteAsync(int id);
}