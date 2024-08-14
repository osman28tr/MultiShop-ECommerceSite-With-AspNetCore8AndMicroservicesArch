using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ContactServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("contacts");
        }

        public async Task<UpdateContactDto> GetByIdAsync(string contactId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateContactDto>($"contacts/{contactId}");
        }

        public async Task AddAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDto>("contacts", createContactDto);
        }

        public async Task UpdateAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync("contacts", updateContactDto);
        }

        public async Task DeleteAsync(string contactId)
        {
            await _httpClient.DeleteAsync($"contacts/{contactId}");
        }
    }
}
