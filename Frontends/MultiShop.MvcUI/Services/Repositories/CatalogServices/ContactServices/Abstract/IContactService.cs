using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.ContactServices.Abstract
{
    public interface IContactService
    {
        Task<UpdateContactDto> GetByIdAsync(string id);
        Task<List<ResultContactDto>> GetAllAsync();
        Task AddAsync(CreateContactDto createContactDto);
        Task UpdateAsync(UpdateContactDto updateContactDto);
        Task DeleteAsync(string id);
    }
}
