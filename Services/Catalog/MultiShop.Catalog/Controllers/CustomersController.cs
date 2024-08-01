using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CustomerDtos;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.CustomerServices.Abstract;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var features = await _customerService.GetAllAsync();
            return Ok(features);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var feature = await _customerService.GetByIdAsync(id);
            return Ok(feature);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto createCustomerDto)
        {
            await _customerService.AddAsync(createCustomerDto);
            return Created("", new { message = "Müşteri başarıyla eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerDto updateCustomerDto)
        {
            await _customerService.UpdateAsync(updateCustomerDto);
            return Ok("Müşteri başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _customerService.DeleteAsync(id);
            return Ok("Müşteri başarıyla silindi.");
        }
    }
}
