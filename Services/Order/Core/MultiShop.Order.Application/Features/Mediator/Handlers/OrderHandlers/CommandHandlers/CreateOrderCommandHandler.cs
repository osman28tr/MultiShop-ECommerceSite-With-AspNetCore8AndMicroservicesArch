using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderCommands;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderHandlers.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Ordering()
            {
                Date = request.Date,
                UserId = request.UserId,
                TotalPrice = request.TotalPrice,
                Address = _mapper.Map<Address>(request.OrderAddress)
            };
            request.OrderDetails.ForEach(x => order.OrderDetails.Add(_mapper.Map<OrderDetail>(x)));
            Random rnd = new Random();
            order.OrderNumber = rnd.Next(1000000, 9999999).ToString();
            order.Date = DateTime.Now;
            await _orderRepository.AddAsync(order);
        }
    }
}
