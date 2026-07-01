using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Products;

namespace OnlineShop.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : Controller
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("create")]
    public async Task<IActionResult> Create(ProductCommands request)
    {
        var product = await _mediator.Send(request);
        return Ok(product);
    }
}
