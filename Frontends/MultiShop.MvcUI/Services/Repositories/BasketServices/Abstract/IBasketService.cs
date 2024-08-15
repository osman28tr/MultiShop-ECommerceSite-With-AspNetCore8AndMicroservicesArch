using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.MvcUI.Services.Repositories.BasketServices.Abstract
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasketAsync();
        Task AddAsync(BasketDto basketDto);
        Task DeleteAsync();
        Task UpdateAsync(BasketDto basketDto);
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<bool> DeleteBasketItemAsync(string productId);
    }
}
