using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services.Abstract;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
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

        [HttpGet("GetRateByCode/{code}")]
        public async Task<IActionResult> GetRateByCode(string code)
        {
            var result = await _discountService.GetRate(code);
            if (result == 0)
            {
                return BadRequest("Kupon kodu aktif değil veya süresi dolmuş olabilir.");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponDto createCouponDto)
        {
            await _discountService.AddAsync(createCouponDto);
            return Created();
        }
        [HttpPost("ApplyDiscountCoupon")]
        public async Task<IActionResult> ApplyDiscountCoupon(ApplyCouponDto applyCouponDto)
        {
            var result = await _discountService.ApplyDiscountCoupon(applyCouponDto);
            if (!result.Item1)
            {
                return BadRequest("Kupon uygulanamadı.");
            }
            return Ok(new { message = "Kupon başarıyla uygulandı", data = result.Item2 });
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
