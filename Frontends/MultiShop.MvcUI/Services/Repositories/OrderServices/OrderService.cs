using MultiShop.DtoLayer.OrderDtos;
using MultiShop.MvcUI.Services.Repositories.OrderServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateAsync(CreateOrderDto createOrderDto)
        {
            await _httpClient.PostAsJsonAsync("orders", createOrderDto);
        }
    }
}
