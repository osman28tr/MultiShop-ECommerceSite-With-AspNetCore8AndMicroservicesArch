using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.MvcUI.Services.Repositories.DiscountServices.Abstract
{
    public interface IDiscountService
    {
        Task<int> GetRate(string code);
        Task<Tuple<bool,decimal>> ApplyDiscountCode(ApplyCouponDto applyCouponDto);
    }
}
