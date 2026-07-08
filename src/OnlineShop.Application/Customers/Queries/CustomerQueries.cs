using MediatR;
using OnlineShop.Domain.QueryEntities;

namespace OnlineShop.Application.Customers.Queries;

public class  GetCustomersQuery : IRequest<List<Customer>>
{
}
