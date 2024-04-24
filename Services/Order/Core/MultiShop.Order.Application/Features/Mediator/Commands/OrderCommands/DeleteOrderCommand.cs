using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderCommands
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
