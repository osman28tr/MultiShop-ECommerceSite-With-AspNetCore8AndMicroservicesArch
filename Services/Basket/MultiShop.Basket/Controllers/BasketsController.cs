using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices.Abstract;
using MultiShop.Basket.Services.Abstract;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;
        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var basket = await _basketService.GetBasketAsync(_loginService.GetUserId);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BasketDto basket)
        {
            await _basketService.AddAsync(basket);
            return Created("","Sepet başarıyla kaydedildi.");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BasketDto basket)
        {
            await _basketService.UpdateAsync(basket);
            return Ok("Sepet başarıyla güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await _basketService.DeleteAsync(_loginService.GetUserId);
            return Ok("Sepet başarıyla silindi.");
        }
    }
}
