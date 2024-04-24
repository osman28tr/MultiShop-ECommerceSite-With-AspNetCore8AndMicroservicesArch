using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderCommands;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderHandlers.CommandHandlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var deletedOrder = await _orderRepository.GetAsync(x => x.Id == request.Id);
            await _orderRepository.DeleteAsync(deletedOrder);
        }
    }
}
