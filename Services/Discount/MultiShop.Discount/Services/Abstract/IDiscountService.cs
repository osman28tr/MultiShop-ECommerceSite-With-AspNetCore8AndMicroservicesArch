using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services.Abstract
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllAsync();
        Task<GetByIdCouponDto> GetByIdAsync(int couponId);
        Task<int> GetRate(string code);
        Task AddAsync(CreateCouponDto createCouponDto);
        Task<Tuple<bool,string>> ApplyDiscountCoupon(ApplyCouponDto applyCouponDto);
        Task UpdateAsync(UpdateCouponDto updateCouponDto);
        Task DeleteAsync(int couponId);
    }
}
