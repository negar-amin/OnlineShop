using MediatR;
using OnlineShop.Contracts.Commands.Common;
using OnlineShop.Domain.CommandEntities;
using System.Runtime;

namespace OnlineShop.Application.Products;

public class ProductCommands : IRequest<CommandResult<Product>>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public long Price { get; set; }
}
