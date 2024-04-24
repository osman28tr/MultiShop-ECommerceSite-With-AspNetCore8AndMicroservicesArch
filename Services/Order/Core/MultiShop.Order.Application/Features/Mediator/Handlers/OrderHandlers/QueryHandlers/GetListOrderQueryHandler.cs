using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderHandlers.QueryHandlers
{
    public class GetListOrderQueryHandler : IRequestHandler<GetListOrderQuery,List<GetListOrderQueryResult>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetListOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task<List<GetListOrderQueryResult>> Handle(GetListOrderQuery request, CancellationToken cancellationToken)
        {
            var values = await _orderRepository.GetAllAsync(null);
            return values.Select(x => _mapper.Map<GetListOrderQueryResult>(x)).ToList();
        }
    }
}
