using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.MvcUI.Services.Repositories.BasketServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductServices.Abstract;

namespace MultiShop.MvcUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        public BasketController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var basket = await _basketService.GetBasketAsync();
            return View(basket);
        }

        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var values = await _productService.GetByIdProductAsync(productId);
            BasketItemDto basketItemDto = new BasketItemDto
            {
                ProductId = values.Id,
                ProductName = values.Name,
                Price = values.Price,
                Quantity = 1,
                ProductImageUrl = values.ImageUrl
            };
            await _basketService.AddBasketItem(basketItemDto);
            return RedirectToAction("Index");
        }   

        public async Task<IActionResult> DeleteBasketItem(string productId)
        {
            await _basketService.DeleteBasketItemAsync(productId);
            return RedirectToAction("Index");
        }
    }
}
