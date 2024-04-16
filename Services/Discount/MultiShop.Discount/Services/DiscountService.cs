using System.Data;
using Dapper;
using MultiShop.Discount.Contexts.Dapper;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services.Abstract;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly MultiShopDiscountDapperContext _context;
        private readonly IDbConnection _connection;
        public DiscountService(MultiShopDiscountDapperContext context)
        {
            _context = context;
            _connection = _context.CreateConnection();
        }
        public async Task<List<ResultCouponDto>> GetAllAsync()
        {
            return (await _connection.QueryAsync<ResultCouponDto>("SELECT * FROM Coupons")).ToList();
        }

        public async Task<GetByIdCouponDto> GetByIdAsync(int couponId)
        {
            return await _connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>("SELECT * FROM Coupons WHERE Id = @Id", new { Id = couponId });
        }

        public async Task AddAsync(CreateCouponDto createCouponDto)
        {
            await _connection.ExecuteAsync(
                "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@Code, @Rate, @IsActive, @ValidDate)",
                createCouponDto);
        }

        public async Task UpdateAsync(UpdateCouponDto updateCouponDto)
        {
            await _connection.ExecuteAsync(
                               "UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE Id = @Id",
                                              updateCouponDto);
        }

        public async Task DeleteAsync(int couponId)
        {
            await _connection.ExecuteAsync("DELETE FROM Coupons WHERE Id = @Id", new { Id = couponId });
        }
    }
}
