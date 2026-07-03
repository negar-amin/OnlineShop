using Microsoft.EntityFrameworkCore;
using OnlineShop.Contracts.Commands.Common;
using OnlineShop.Domain.Common;

namespace OnlineShop.Infra.Command.Common;

public class BaseCommandRepository<T> : IBaseCommandRepository<T> where T : Entity
{
    private readonly CommandDbContext _commandDbContext;
    public BaseCommandRepository(CommandDbContext commandDbContext)
    {
        _commandDbContext = commandDbContext;
    }
    public async Task AddAsync(T entity, CancellationToken ct = default) 
    {
        await _commandDbContext.Set<T>().AddAsync(entity, ct);
    }
    public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _commandDbContext.Set<T>().FindAsync(new object[] { id }, ct);
    }
    public void Update(T entity)
    {
        _commandDbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _commandDbContext.Set<T>().Remove(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
    {
        await _commandDbContext.Set<T>().AddRangeAsync(entities, ct);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _commandDbContext.Set<T>().RemoveRange(entities);
    }
    public async Task<List<T>> GetByIdsAsync(
    IEnumerable<Guid> ids,
    CancellationToken ct = default)
    {
        return await _commandDbContext
            .Set<T>()
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(ct);
    }
}
