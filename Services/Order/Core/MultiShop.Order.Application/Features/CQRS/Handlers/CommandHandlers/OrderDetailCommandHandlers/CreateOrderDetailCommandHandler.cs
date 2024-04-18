using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.CommandHandlers.OrderDetailCommandHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public CreateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task Handle(CreateOrderDetailCommand request)
        {
            await _orderDetailRepository.AddAsync(new OrderDetail
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                ProductAmount = request.ProductAmount,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductTotalPrice = request.ProductPrice * request.ProductAmount
            });
        }
    }
}
