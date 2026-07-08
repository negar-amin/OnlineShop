using MediatR;
using OnlineShop.Contracts.Commands.Common;
using OnlineShop.Domain.CommandEntities;

namespace OnlineShop.Application.Customers.Commands;


public class CreateCustomerCommand : IRequest<CommandResult<Customer>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}
