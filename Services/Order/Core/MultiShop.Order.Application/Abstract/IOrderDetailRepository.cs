using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Abstract
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
    }
}
