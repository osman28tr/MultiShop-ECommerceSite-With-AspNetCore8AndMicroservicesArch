using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.QueryHandlers.OrderDetailQueryHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public GetOrderDetailByIdQueryHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request)
        {
            var value = await _orderDetailRepository.GetAsync(x => x.Id == request.Id);
            return new GetOrderDetailByIdQueryResult
            {
                Id = value.Id,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                ProductAmount = value.ProductAmount,
                ProductTotalPrice = value.ProductTotalPrice,
                OrderId = value.OrderId
            };
        }
    }
}
