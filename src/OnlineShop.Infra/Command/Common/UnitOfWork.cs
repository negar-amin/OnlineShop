using OnlineShop.Contracts.RepositoryContracts.Command;
using OnlineShop.Contracts.RepositoryContracts.Command.Common;
using OnlineShop.Domain.CommandEntities;

namespace OnlineShop.Infra.Command.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly CommandDbContext _context;

    public UnitOfWork(CommandDbContext context,IBaseCommandRepository<Order> orders, IBaseCommandRepository<Customer> customers, IBaseCommandRepository<Product> products)
    {
        Orders = orders;
        Products = products;
        Customers = customers;
        _context = context;
    }

    public IBaseCommandRepository<Product> Products { get; }

    public IBaseCommandRepository<Order> Orders { get; }

    public IBaseCommandRepository<Customer> Customers { get; }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return _context.SaveChangesAsync(ct);
    }
}
