using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Services.ContactServices.Abstract;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var contacts = await _contactService.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto contactDto)
        {
            await _contactService.AddAsync(contactDto);
            return Created("", new { message = "Mesajınız başarıyla gönderildi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDto contactDto)
        {
            await _contactService.UpdateAsync(contactDto);
            return Ok("Mesajınız başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _contactService.DeleteAsync(id);
            return Ok("Mesajınız başarıyla silindi.");
        }
    }
}
