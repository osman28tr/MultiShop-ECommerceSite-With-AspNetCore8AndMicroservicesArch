using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.DiscountDtos;
using MultiShop.MvcUI.Services.Repositories.DiscountServices.Abstract;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MultiShop.MvcUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public PartialViewResult ApplyCode()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ApplyCode(string code)
        {
            var result = await _discountService.ApplyDiscountCode(new ApplyCouponDto() { Code = code });
            if (!result.Item1)
                TempData["isAppliedCoupon"] = "Kupon uygulanamadı.";
            else
            {
                TempData["isAppliedCoupon"] = "Kupon başarıyla uygulandı.";
                TempData["discountRate"] = await _discountService.GetRate(code);
                float.TryParse(result.Item2.ToString(), out float discountAmount);
                TempData["discountAmount"] = JsonSerializer.Serialize(discountAmount);
            }
            return RedirectToAction("Index", "Basket");
        }
    }
}
