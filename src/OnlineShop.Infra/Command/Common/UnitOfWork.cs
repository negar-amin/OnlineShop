using OnlineShop.Contracts.RepositoryContracts.Command.Common;

namespace OnlineShop.Infra.Command.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly CommandDbContext _context;

    public UnitOfWork(CommandDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return _context.SaveChangesAsync(ct);
    }
}
