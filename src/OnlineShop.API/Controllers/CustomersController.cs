using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Customers.CustomerCommands;

namespace OnlineShop.API.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateCustomerCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}
