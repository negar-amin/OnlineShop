using MediatR;
using OnlineShop.Application.Products;
using OnlineShop.Contracts.Commands.Common;

namespace OnlineShop.Application.Orders;

public class CreateOrderCommands : IRequest<CommandResult>
{
    public Guid CustomerId { get; set; }
    public List<OrderItem> OrderItems{ get; set; }
}
public class OrderItem
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}