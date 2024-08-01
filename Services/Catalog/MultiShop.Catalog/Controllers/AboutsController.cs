using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.AboutServices.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var abouts = await _aboutService.GetAllAsync();
            return Ok(abouts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            return Ok(about);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            await _aboutService.AddAsync(createAboutDto);
            return Created("", new { message = "Hakkımızda başarıyla eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAsync(updateAboutDto);
            return Ok("Hakkımızda başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _aboutService.DeleteAsync(id);
            return Ok("Hakkımızda başarıyla silindi.");
        }
    }
}
