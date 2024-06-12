using System.Text.Json;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.Services.Abstract;
using MultiShop.Basket.Settings;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;
        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }
        public async Task<BasketDto> GetBasketAsync(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            if (string.IsNullOrEmpty(existBasket))
            {
                return null;
            }
            return JsonSerializer.Deserialize<BasketDto>(existBasket);
        }

        public async Task AddAsync(BasketDto basketDto)
        {
            await _redisService.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
        }

        public async Task DeleteAsync(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task UpdateAsync(BasketDto basketDto)
        {
            await _redisService.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
        }
    }
}
