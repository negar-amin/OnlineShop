using MediatR;
using OnlineShop.Application.Customers.CustomerCommands;
using OnlineShop.Contracts.Commands.Common;
using OnlineShop.Domain.CommandEntities;
using OnlineShop.Domain.ValueObjects;
namespace OnlineShop.Application.Customers.CustomerCommandsHandler;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CommandResult<Customer>>
{
    private readonly IUnitOfWork _uow;

    public CreateCustomerCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<CommandResult<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var customer = Customer.Create(
                request.FirstName,
                request.LastName,
                PhoneNumber.Create(request.PhoneNumber)
            );
            await _uow.Customers.AddAsync(customer);
            await _uow.SaveChangesAsync();
            return CommandResult<Customer>.Success(customer);
        }
        catch (Exception ex)
        {
            return CommandResult.Failure(ex.Message);
        }
    }
}
