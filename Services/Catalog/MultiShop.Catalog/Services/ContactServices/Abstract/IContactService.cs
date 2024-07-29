using MultiShop.Catalog.Dtos.ContactDtos;

namespace MultiShop.Catalog.Services.ContactServices.Abstract
{
    public interface IContactService
    {
        Task<GetByIdContactDto> GetByIdAsync(string id);
        Task<List<ResultContactDto>> GetAllAsync();
        Task AddAsync(CreateContactDto createContactDto);
        Task UpdateAsync(UpdateContactDto updateContactDto);
        Task DeleteAsync(string id);
    }
}
