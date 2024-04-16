using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services.Abstract;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _discountService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{couponId}")]
        public async Task<IActionResult> GetById(int couponId)
        {
            var result = await _discountService.GetByIdAsync(couponId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponDto createCouponDto)
        {
            await _discountService.AddAsync(createCouponDto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateAsync(updateCouponDto);
            return Ok("Kupon başarıyla güncellendi.");
        }

        [HttpDelete("{couponId}")]
        public async Task<IActionResult> Delete(int couponId)
        {
            await _discountService.DeleteAsync(couponId);
            return Ok("Kupon başarıyla silindi.");
        }
    }
}
