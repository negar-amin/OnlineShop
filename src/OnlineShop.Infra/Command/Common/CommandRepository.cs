using Microsoft.EntityFrameworkCore;
using OnlineShop.Contracts.RepositoryContracts.Command.Common;

namespace OnlineShop.Infra.Command.Common;

public class CommandRepository : IBaseCommandRepository
{
    private readonly CommandDbContext _commandDbContext;
    public CommandRepository(CommandDbContext commandDbContext)
    {
        _commandDbContext = commandDbContext;
    }
    public async Task AddAsync<T>(T entity, CancellationToken ct = default) where T : class
    {
        await _commandDbContext.Set<T>().AddAsync(entity, ct);
    }

    public void Update<T>(T entity) where T : class
    {
        _commandDbContext.Set<T>().Update(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _commandDbContext.Set<T>().Remove(entity);
    }

    public async Task AddRangeAsync<T>(IEnumerable<T> entities, CancellationToken ct = default) where T : class
    {
        await _commandDbContext.Set<T>().AddRangeAsync(entities, ct);
    }

    public void DeleteRange<T>(IEnumerable<T> entities) where T : class
    {
        _commandDbContext.Set<T>().RemoveRange(entities);
    }

}
