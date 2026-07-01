using MediatR;

namespace OnlineShop.Application.Customers.CustomerCommands;


public class CreateCustomerCommand : IRequest<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}
