using MediatR;
using OnlineShop.Contracts.Commands.Common;
using OnlineShop.Domain.CommandEntities;

namespace OnlineShop.Application.Orders;

public class OrderCommandsHandler : IRequestHandler<CreateOrderCommands, CommandResult>
{
    private readonly IUnitOfWork _uow;
    public OrderCommandsHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<CommandResult> Handle(CreateOrderCommands request, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await _uow.Customers.GetByIdAsync(request.CustomerId);
            if (customer == null)
            {
                return CommandResult.Failure("مشتری پیدا نشد");
            }
            var order = Order.Create(customer.Id);
            await _uow.Orders.AddAsync(order);
            foreach (var item in request.OrderItems)
            {
                var product = await _uow.Products.GetByIdAsync(item.ProductId);
                if(product == null)
                {
                    return CommandResult.Failure("محصول پیدا نشد");
                }
                product.Reserve(item.Quantity);
                order.AddLineItem(product.Id, item.Quantity);

            }
            await _uow.SaveChangesAsync();
            return CommandResult.Success();
        }
        catch (Exception ex)
        {
            return CommandResult.Failure(ex.Message);
        }
    }
}
