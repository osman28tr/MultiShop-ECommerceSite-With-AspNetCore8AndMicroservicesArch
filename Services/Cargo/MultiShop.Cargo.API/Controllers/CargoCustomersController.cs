using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _cargoCustomerService.TGetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _cargoCustomerService.TGetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatedCargoCustomerDto cargoCustomerDto)
        {
            await _cargoCustomerService.TAddAsync(new CargoCustomer()
            {
                Name = cargoCustomerDto.Name, City = cargoCustomerDto.City, Surname = cargoCustomerDto.Surname,
                District = cargoCustomerDto.District, Email = cargoCustomerDto.Email, Phone = cargoCustomerDto.Phone,
                Address = cargoCustomerDto.Address
            });
            return Created("", "Kargo müşteri ekleme işlemi başarıyla yapıldı.");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedCargoCustomerDto cargoCustomerDto)
        {
            await _cargoCustomerService.TUpdateAsync(new CargoCustomer()
            {
                Id = cargoCustomerDto.Id, Name = cargoCustomerDto.Name, City = cargoCustomerDto.City,
                Surname = cargoCustomerDto.Surname, District = cargoCustomerDto.District, Email = cargoCustomerDto.Email,
                Phone = cargoCustomerDto.Phone, Address = cargoCustomerDto.Address
            });
            return Ok("Kargo müşteri güncelleme işlemi başarıyla yapıldı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cargoCustomerService.TDeleteAsync(id);
            return Ok("Kargo müşteri silme işlemi başarıyla yapıldı.");
        }
    }
}
