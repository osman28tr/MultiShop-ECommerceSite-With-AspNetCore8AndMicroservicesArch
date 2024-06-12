using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services.Abstract
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasketAsync(string userId);
        Task AddAsync(BasketDto basketDto);
        Task DeleteAsync(string userId);
        Task UpdateAsync(BasketDto basketDto);
    }
}
