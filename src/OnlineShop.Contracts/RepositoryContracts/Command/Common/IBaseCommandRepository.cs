namespace OnlineShop.Contracts.RepositoryContracts.Command.Common;

public interface IBaseCommandRepository<T> where T : class
{
    Task AddAsync(T entity, CancellationToken ct = default); 
    void Update(T entity);
    void Delete(T entity);

    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);
    void DeleteRange(IEnumerable<T> entities);
}
