using MediatR;
using OnlineShop.Contracts.Commands.Common;
using OnlineShop.Domain.CommandEntities;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Application.Products;

public class ProductCommandsHandler : IRequestHandler<ProductCommands, CommandResult<Product>>
{
    private readonly IUnitOfWork _uow;
    public ProductCommandsHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<CommandResult<Product>> Handle(ProductCommands request, CancellationToken cancellationToken)
    {
        var product = Product.Create(request.Name,request.Price, request.Stock);
        if (product == null)
            return CommandResult<Product>.Failure(new List<string>{"موجودی و قیمت محصول نمیتواند منفی باشد"});
        await _uow.Products.AddAsync(product);
        await _uow.SaveChangesAsync();
        return CommandResult<Product>.Success(product);
    }
}
