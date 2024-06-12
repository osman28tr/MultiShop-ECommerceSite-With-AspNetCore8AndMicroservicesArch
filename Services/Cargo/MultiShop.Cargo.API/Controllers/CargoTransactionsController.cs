using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoTransactionDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoTransactionsController : ControllerBase
    {
        private readonly ICargoTransactionService _cargoTransactionService;
        public CargoTransactionsController(ICargoTransactionService cargoTransactionService)
        {
            _cargoTransactionService = cargoTransactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _cargoTransactionService.TGetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _cargoTransactionService.TGetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatedCargoTransactionDto cargoTransactionDto)
        {
            await _cargoTransactionService.TAddAsync(new CargoTransaction()
            {
                Barcode = cargoTransactionDto.Barcode,
                Description = cargoTransactionDto.Description,
                Date = DateTime.Now
            });
            return Created("", "Kargo hareketi ekleme işlemi başarıyla yapıldı.");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedCargoTransactionDto cargoTransactionDto)
        {
            await _cargoTransactionService.TUpdateAsync(new CargoTransaction()
            {
                Id = cargoTransactionDto.Id,
                Barcode = cargoTransactionDto.Barcode,
                Description = cargoTransactionDto.Description,
                Date = DateTime.Now
            });
            return Ok("Kargo hareketi güncelleme işlemi başarıyla yapıldı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cargoTransactionService.TDeleteAsync(id);
            return Ok("Kargo hareketi silme işlemi başarıyla yapıldı.");
        }
    }
}
