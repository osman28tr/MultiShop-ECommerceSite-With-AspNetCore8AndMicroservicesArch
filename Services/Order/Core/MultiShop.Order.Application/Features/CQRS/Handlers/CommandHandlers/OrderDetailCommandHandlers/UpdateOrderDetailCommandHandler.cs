using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.CommandHandlers.OrderDetailCommandHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public UpdateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task Handle(UpdateOrderDetailCommand request)
        {
            var orderDetail = await _orderDetailRepository.GetAsync(x => x.Id == request.Id);
            orderDetail.ProductId = request.ProductId;
            orderDetail.ProductAmount = request.ProductAmount;
            orderDetail.ProductPrice = request.ProductPrice;
            orderDetail.ProductName = request.ProductName;
            orderDetail.ProductTotalPrice = request.ProductPrice * request.ProductAmount;
            await _orderDetailRepository.UpdateAsync(orderDetail);
        }
    }
}
