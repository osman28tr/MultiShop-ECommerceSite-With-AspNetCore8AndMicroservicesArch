using System.Data;
using System.Reflection.Metadata.Ecma335;
using Dapper;
using MultiShop.Discount.Contexts.Dapper;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Entities;
using MultiShop.Discount.Services.Abstract;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly MultiShopDiscountDapperContext _context;
        private readonly IDbConnection _connection;
        private readonly HttpClient _client;
        public DiscountService(MultiShopDiscountDapperContext context, HttpClient client)
        {
            _context = context;
            _client = client;
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

        public async Task<int> GetRate(string code)
        {
            var coupon =
                await _connection.QueryFirstOrDefaultAsync<Coupon>("Select * from Coupons where code= @codeInput",
                    new { codeInput = code });
            if (coupon == null || coupon.ValidDate < DateTime.Now || coupon.IsActive == false)
                return 0;
            return coupon.Rate;
        }

        public async Task AddAsync(CreateCouponDto createCouponDto)
        {
            await _connection.ExecuteAsync(
                "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@Code, @Rate, @IsActive, @ValidDate)",
                createCouponDto);
        }

        public async Task<Tuple<bool,string>> ApplyDiscountCoupon(ApplyCouponDto applyCouponDto)
        {
            bool isApplied = false;
            string productId = "";
            var coupon = await _connection.QueryFirstOrDefaultAsync<Coupon>(
                "Select * from Coupons where code= @codeInput",
                new { codeInput = applyCouponDto.Code });
            if (coupon == null || coupon.ValidDate < DateTime.Now || coupon.IsActive == false)
                return Tuple.Create(false, "");
            applyCouponDto.ProductIds.ForEach(x =>
            {
                if (x == coupon.ProductId)
                {
                    productId = x;
                    isApplied = true;
                }
            });
            return isApplied == true ? Tuple.Create(true, productId) : Tuple.Create(false, "");
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
