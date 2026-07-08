using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Orders;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateOrderCommands command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
