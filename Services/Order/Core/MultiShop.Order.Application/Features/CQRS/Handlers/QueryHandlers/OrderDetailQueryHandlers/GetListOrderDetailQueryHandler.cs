using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.QueryHandlers.OrderDetailQueryHandlers
{
    public class GetListOrderDetailQueryHandler
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public GetListOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<GetListOrderDetailQueryResult>> Handle()
        {
            var values = await _orderDetailRepository.GetAllAsync(null);
            return values.Select(x => new GetListOrderDetailQueryResult
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                ProductAmount = x.ProductAmount,
                ProductPrice = x.ProductPrice,
                ProductName = x.ProductName,
                ProductTotalPrice = x.ProductTotalPrice
            }).ToList();
        }
    }
}
