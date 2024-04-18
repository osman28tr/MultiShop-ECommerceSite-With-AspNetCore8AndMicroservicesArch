using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.CommandHandlers.OrderDetailCommandHandlers
{
    public class DeleteOrderDetailCommandHandler
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public DeleteOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task Handle(DeleteOrderDetailCommand request)
        {
            var deletedOrderDetail = await _orderDetailRepository.GetAsync(x => x.Id == request.Id);
            await _orderDetailRepository.DeleteAsync(deletedOrderDetail);
        }
    }
}
