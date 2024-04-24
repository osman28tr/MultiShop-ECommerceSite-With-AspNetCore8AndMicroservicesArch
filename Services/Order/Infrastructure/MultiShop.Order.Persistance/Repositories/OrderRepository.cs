using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistance.Contexts;

namespace MultiShop.Order.Persistance.Repositories
{
    public class OrderRepository : GenericRepository<Ordering> , IOrderRepository
    {
        public OrderRepository(MultiShopOrderContext context) : base(context)
        {
        }
    }
}
