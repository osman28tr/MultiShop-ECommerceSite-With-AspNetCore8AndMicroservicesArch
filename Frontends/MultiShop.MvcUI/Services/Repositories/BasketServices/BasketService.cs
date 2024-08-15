using MultiShop.DtoLayer.BasketDtos;
using MultiShop.MvcUI.Services.Repositories.BasketServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BasketDto> GetBasketAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BasketDto>($"baskets");
            if (response != null)
                return response;
            return null;
        }
        public async Task AddAsync(BasketDto basketDto)
        {
            await _httpClient.PostAsJsonAsync("baskets", basketDto);
        }

        public async Task DeleteAsync()
        {
            await _httpClient.DeleteAsync($"baskets");
        }

        public async Task UpdateAsync(BasketDto basketDto)
        {
            await _httpClient.PutAsJsonAsync("baskets", basketDto);
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasketAsync();
            if (values != null)
            {
                if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId).Quantity += basketItemDto.Quantity;
                }
                await UpdateAsync(values);
            }
            else
            {
                BasketDto basketDto = new BasketDto();
                basketDto.BasketItems.Add(basketItemDto);
                await AddAsync(basketDto);
            }
        }

        public async Task<bool> DeleteBasketItemAsync(string productId)
        {
            var values = await GetBasketAsync();
            if (values != null)
            {
                var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
                if (deletedItem != null)
                {
                    values.BasketItems.Remove(deletedItem);
                    await UpdateAsync(values);
                    return true;
                }
            }
            return false;
        }
    }
}
