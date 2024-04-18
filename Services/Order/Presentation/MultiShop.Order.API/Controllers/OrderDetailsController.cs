using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.CommandHandlers.OrderDetailCommandHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.QueryHandlers.OrderDetailQueryHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetListOrderDetailQueryHandler _getListOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly DeleteOrderDetailCommandHandler _deleteOrderDetailCommandHandler;

        public OrderDetailsController(GetListOrderDetailQueryHandler getListOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler)
        {
            _getListOrderDetailQueryHandler = getListOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _deleteOrderDetailCommandHandler = deleteOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _getListOrderDetailQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDetailCommand request)
        {
            await _createOrderDetailCommandHandler.Handle(request);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDetailCommand request)
        {
            await _updateOrderDetailCommandHandler.Handle(request);
            return Ok("Sipariş detayı başarıyla güncellendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteOrderDetailCommandHandler.Handle(new DeleteOrderDetailCommand(id));
            return Ok("Sipariş detayı başarıyla silindi.");
        }
    }
}
