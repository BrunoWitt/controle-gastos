using System.Numerics;
using Src.Shared.Base;

namespace Src.Shared.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseModel
{
    Task CreateAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(BigInteger id);
}