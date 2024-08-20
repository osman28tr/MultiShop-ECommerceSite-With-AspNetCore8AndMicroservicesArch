using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.DtoLayer.PaymentDtos;

namespace MultiShop.DtoLayer.OrderDtos
{
    public class CreateOrderDto
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public List<CreateOrderDetailDto> OrderDetails { get; set; }
        public CreateOrderAddressDto OrderAddress { get; set; }
        public PaymentTypeDto PaymentType { get; set; }
        public CreateOrderDto()
        {
            OrderDetails = new List<CreateOrderDetailDto>();
            OrderAddress = new CreateOrderAddressDto();
        }
    }
}
