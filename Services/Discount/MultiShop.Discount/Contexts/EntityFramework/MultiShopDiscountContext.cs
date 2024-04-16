using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Contexts.EntityFramework
{
    public class MultiShopDiscountContext : DbContext
    {
        public MultiShopDiscountContext(DbContextOptions<MultiShopDiscountContext> options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
