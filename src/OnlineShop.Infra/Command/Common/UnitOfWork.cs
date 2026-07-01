using OnlineShop.Contracts.RepositoryContracts.Command;
using OnlineShop.Contracts.RepositoryContracts.Command.Common;

namespace OnlineShop.Infra.Command.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly CommandDbContext _context;

    public UnitOfWork(CommandDbContext context,IOrderRepository orders, ICustomerRepository customers, IProductRepository products)
    {
        Orders = orders;
        Products = products;
        Customers = customers;
        _context = context;
    }

    public IProductRepository Products { get; }

    public IOrderRepository Orders { get; }

    public ICustomerRepository Customers { get; }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return _context.SaveChangesAsync(ct);
    }
}
