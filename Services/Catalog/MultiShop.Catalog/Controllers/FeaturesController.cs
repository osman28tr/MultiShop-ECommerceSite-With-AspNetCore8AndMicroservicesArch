using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices.Abstract;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var features = await _featureService.GetAllAsync();
            return Ok(features);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var feature = await _featureService.GetByIdFeatureAsync(id);
            return Ok(feature);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFeatureDto createFeatureDto)
        {
            await _featureService.AddAsync(createFeatureDto);
            return Created("", new { message = "Öne çıkan alan başarıyla eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateAsync(updateFeatureDto);
            return Ok("Öne çıkan alan başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _featureService.DeleteAsync(id);
            return Ok("Öne çıkan alan başarıyla silindi.");
        }
    }
}
