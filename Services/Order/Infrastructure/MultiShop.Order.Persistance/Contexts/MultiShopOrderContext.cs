using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistance.Contexts
{
    public class MultiShopOrderContext : DbContext
    {
        public MultiShopOrderContext(DbContextOptions<MultiShopOrderContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Ordering> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
