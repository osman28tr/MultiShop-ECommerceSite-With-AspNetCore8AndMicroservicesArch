using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Dtos;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public List<CreateOrderDetailDto> OrderDetails { get; set; }
        public CreateOrderAddressDto OrderAddress { get; set; }

        public CreateOrderCommand()
        {
            OrderDetails = new List<CreateOrderDetailDto>();
            OrderAddress = new CreateOrderAddressDto();
        }
    }
}
