using OnlineShop.Domain.CommandEntities;

namespace OnlineShop.Contracts.Commands.Common;

public interface IUnitOfWork
{
    IBaseCommandRepository<Product> Products { get; }
    IBaseCommandRepository<Order> Orders { get; }
    IBaseCommandRepository<Customer> Customers { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
