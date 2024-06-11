using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _cargoDetailService.TGetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _cargoDetailService.TGetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatedCargoDetailDto cargoDetailDto)
        {
            await _cargoDetailService.TAddAsync(new CargoDetail()
            {
                SenderCustomerId = cargoDetailDto.SenderCustomerId,
                ReceiverCustomerId = cargoDetailDto.ReceiverCustomerId, CargoCompanyId = cargoDetailDto.CargoCompanyId,
                Barcode = cargoDetailDto.Barcode
            });
            return Created("", "Kargo detay ekleme işlemi başarıyla yapıldı.");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedCargoDetailDto cargoDetailDto)
        {
            await _cargoDetailService.TUpdateAsync(new CargoDetail()
            {
                Id = cargoDetailDto.Id, SenderCustomerId = cargoDetailDto.SenderCustomerId,
                ReceiverCustomerId = cargoDetailDto.ReceiverCustomerId, CargoCompanyId = cargoDetailDto.CargoCompanyId,
                Barcode = cargoDetailDto.Barcode
            });
            return Ok("Kargo detay güncelleme işlemi başarıyla yapıldı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cargoDetailService.TDeleteAsync(id);
            return Ok("Kargo detay silme işlemi başarıyla yapıldı.");
        }
    }
}
