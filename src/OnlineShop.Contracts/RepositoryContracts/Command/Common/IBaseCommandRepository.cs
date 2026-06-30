namespace OnlineShop.Contracts.RepositoryContracts.Command.Common;

public interface IBaseCommandRepository
{
    Task AddAsync<T>(T entity, CancellationToken ct = default) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;

    Task AddRangeAsync<T>(IEnumerable<T> entities, CancellationToken ct = default) where T : class;
    void DeleteRange<T>(IEnumerable<T> entities) where T : class;
}
