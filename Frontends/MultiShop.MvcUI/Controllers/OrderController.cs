using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.DtoLayer.OrderDtos;
using MultiShop.MvcUI.Services.Abstract;
using MultiShop.MvcUI.Services.Repositories.BasketServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.OrderServices.Abstract;

namespace MultiShop.MvcUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;
        public OrderController(IOrderService orderService, IBasketService basketService, IUserService userService)
        {
            _orderService = orderService;
            _basketService = basketService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? totalPrice)
        {
            var basket = await GetBasket();
            ViewBag.Basket = basket;
            ViewBag.TotalPrice = Convert.ToDecimal(totalPrice);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderDto createOrderDto)
        {
            createOrderDto.UserId = _userService.GetUserInfo().Result.Id;
            var basket = await GetBasket();
            createOrderDto.OrderDetails.AddRange(basket.BasketItems.Select(x => new CreateOrderDetailDto()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.Price,
                ProductTotalPrice = x.Price * x.Quantity,
                ProductAmount = x.Quantity
            }));
            await _orderService.CreateAsync(createOrderDto);
            return RedirectToAction("Index","Payment");
        }

        private async Task<BasketDto> GetBasket()
        {
            return await _basketService.GetBasketAsync();
        }
    }
}
