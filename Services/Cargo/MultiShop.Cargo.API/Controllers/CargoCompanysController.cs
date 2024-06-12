using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanysController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        public CargoCompanysController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _cargoCompanyService.TGetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatedCargoCompanyDto cargoCompanyDto)
        {
            await _cargoCompanyService.TAddAsync(new CargoCompany() { Name = cargoCompanyDto.Name });
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _cargoCompanyService.TGetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedCargoCompanyDto cargoCompanyDto)
        {
            await _cargoCompanyService.TUpdateAsync(new CargoCompany() { Id = cargoCompanyDto.Id, Name = cargoCompanyDto.Name });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cargoCompanyService.TDeleteAsync(id);
            return Ok();
        }
    }
}
