using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Domain.Entities
{
    public class Ordering
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public string OrderNumber { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public Address Address { get; set; }
        public PaymentType PaymentType { get; set; }

        public Ordering()
        {
            OrderDetails = new List<OrderDetail>();
            Address = new Address();
        }
    }

    public enum PaymentType
    {
        Card,
        PayPal,
        DirectCheck
    }
}
