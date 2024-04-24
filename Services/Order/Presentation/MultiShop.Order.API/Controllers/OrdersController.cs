using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderQueries;

namespace MultiShop.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetListOrderQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla silindi.");
        }
    }
}
