using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Customers.Commands;
using OnlineShop.Application.Customers.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCustomers()
    {
        var result = await _mediator.Send(new GetCustomersQuery());
        return Ok(result);
    }
}
