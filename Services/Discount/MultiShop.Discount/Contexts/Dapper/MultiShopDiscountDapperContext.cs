using System.Data;
using Microsoft.Data.SqlClient;

namespace MultiShop.Discount.Contexts.Dapper
{
    public class MultiShopDiscountDapperContext
    {
        private readonly IConfiguration _configuration;
        public MultiShopDiscountDapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection() => new SqlConnection(_configuration.GetConnectionString("MSSQL"));
    }
}
