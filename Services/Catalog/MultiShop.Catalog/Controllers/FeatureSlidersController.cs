using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var featureSliders = await _featureSliderService.GetAllAsync();
            return Ok(featureSliders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var featureSlider = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(featureSlider);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.AddAsync(createFeatureSliderDto);
            return Created("", new { message = "Öne çıkan görsel başarıyla eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateAsync(updateFeatureSliderDto);
            return Ok("Öne çıkan görsel başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _featureSliderService.DeleteAsync(id);
            return Ok("Öne çıkan görsel başarıyla silindi.");
        }

        [HttpPut("{id}/status/{status}")]
        public async Task<IActionResult> ChangeFeatureSliderStatus(string id, bool status)
        {
            await _featureSliderService.ChangeFeatureSliderStatus(id, status);
            return Ok("Öne çıkan görselin durumu başarıyla güncellendi.");
        }
    }
}
