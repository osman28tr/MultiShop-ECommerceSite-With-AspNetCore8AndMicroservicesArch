using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController : ControllerBase
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountsController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var offerDiscounts = await _offerDiscountService.GetAllAsync();
            return Ok(offerDiscounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var offerDiscount = await _offerDiscountService.GetByIdAsync(id);
            return Ok(offerDiscount);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOfferDiscountDto offerDiscountDto)
        {
            await _offerDiscountService.AddAsync(offerDiscountDto);
            return Created("", new { message = "Özel Teklif başarıyla eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOfferDiscountDto offerDiscountDto)
        {
            await _offerDiscountService.UpdateAsync(offerDiscountDto);
            return Ok("Özel Teklif başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _offerDiscountService.DeleteAsync(id);
            return Ok("Özel Teklif başarıyla silindi.");
        }
    }
}
