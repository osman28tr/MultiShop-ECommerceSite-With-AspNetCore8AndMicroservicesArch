using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderQueries
{
    public class GetListOrderQuery : IRequest<List<GetListOrderQueryResult>>
    {

    }
}
