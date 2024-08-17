using MultiShop.DtoLayer.BasketDtos;
using MultiShop.DtoLayer.DiscountDtos;
using MultiShop.MvcUI.Services.Repositories.BasketServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.DiscountServices.Abstract;
using MultiShop.MvcUI.ViewModels;

namespace MultiShop.MvcUI.Services.Repositories.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _client;
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        public DiscountService(HttpClient client, IBasketService basketService, IProductService productService)
        {
            _client = client;
            _basketService = basketService;
            _productService = productService;
        }

        public async Task<int> GetRate(string code)
        {
            var result = await _client.GetAsync($"discounts/GetRateByCode/{code}");
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<int>();
            }
            return 0;
        }
        public async Task<Tuple<bool,decimal>> ApplyDiscountCode(ApplyCouponDto applyCouponDto)
        {
            var basket = await _basketService.GetBasketAsync();
            var rate = await GetRate(applyCouponDto.Code);
            if (basket == null)
                return Tuple.Create(false,0M);
            applyCouponDto.ProductIds = basket.BasketItems.Select(x => x.ProductId).ToList();
            var response =
                await _client.PostAsJsonAsync<ApplyCouponDto>("discounts/ApplyDiscountCoupon", applyCouponDto);
            if (response.IsSuccessStatusCode)
            {
                var responseViewModel = response.Content.ReadFromJsonAsync<DiscountViewModel>();
                var product = await _productService.GetByIdProductAsync(responseViewModel.Result.Data);
                var discountAmount = product.Price * rate / 100;
                return Tuple.Create(true, discountAmount);
            }
            return Tuple.Create(false, 0M);
        }
    }
}
