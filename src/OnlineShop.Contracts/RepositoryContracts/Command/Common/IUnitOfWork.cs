namespace OnlineShop.Contracts.RepositoryContracts.Command.Common;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
