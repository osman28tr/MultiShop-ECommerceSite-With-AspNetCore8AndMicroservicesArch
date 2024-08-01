using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices.Abstract;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOffersController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<ActionResult<ResultSpecialOfferDto>> GetSpecialOffers()
        {
            var specialOffers = await _specialOfferService.GetAllAsync();
            return Ok(specialOffers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetByIdSpecialOfferDto>> GetSpecialOffer(string id)
        {
            var specialOffer = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(specialOffer);
        }

        [HttpPost]
        public async Task<ActionResult<ResultSpecialOfferDto>> CreateSpecialOffer(
            [FromBody] CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.AddAsync(createSpecialOfferDto);
            return Created("", new { message = "Özel teklifiniz başarıyla kaydedildi." });
        }

        [HttpPut]
        public async Task<ActionResult<ResultSpecialOfferDto>> UpdateSpecialOffer(
            [FromBody] UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateAsync(updateSpecialOfferDto);
            return Ok("Özel teklifiniz başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteAsync(id);
            return Ok("Özel teklifiniz başarıyla silindi.");
        }
    }
}
