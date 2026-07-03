using OnlineShop.Domain.Common;

namespace OnlineShop.Contracts.Commands.Common;

public interface IBaseCommandRepository<T> where T : Entity
{
    Task AddAsync(T entity, CancellationToken ct = default); 
    void Update(T entity);
    void Delete(T entity);
    Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<List<T>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct = default);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);
    void DeleteRange(IEnumerable<T> entities);
}
