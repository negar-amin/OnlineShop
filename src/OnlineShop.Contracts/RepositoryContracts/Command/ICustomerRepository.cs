using OnlineShop.Contracts.RepositoryContracts.Command.Common;
using OnlineShop.Domain.CommandEntities;

namespace OnlineShop.Contracts.RepositoryContracts.Command;

public interface ICustomerRepository : IBaseCommandRepository<Customer>
{
}
