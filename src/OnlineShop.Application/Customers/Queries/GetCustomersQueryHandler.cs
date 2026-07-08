using MediatR;
using OnlineShop.Contracts.Query;
using OnlineShop.Domain.QueryEntities;
using System.Security.Cryptography.X509Certificates;

namespace OnlineShop.Application.Customers.Queries;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
{
    private readonly IBaseQueryRepository<Customer> _customerRepository;
    public GetCustomersQueryHandler(IBaseQueryRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = _customerRepository.Query().ToList();
        return customers;
    }
}
