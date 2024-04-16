using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services.Abstract
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllAsync();
        Task<GetByIdCouponDto> GetByIdAsync(int couponId);
        Task AddAsync(CreateCouponDto createCouponDto);
        Task UpdateAsync(UpdateCouponDto updateCouponDto);
        Task DeleteAsync(int couponId);
    }
}
