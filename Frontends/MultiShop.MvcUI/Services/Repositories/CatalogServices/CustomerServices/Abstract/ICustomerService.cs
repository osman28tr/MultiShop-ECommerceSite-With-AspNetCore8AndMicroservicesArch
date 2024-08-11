using MultiShop.DtoLayer.CatalogDtos.CustomerDtos;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.CustomerServices.Abstract
{
    public interface ICustomerService
    {
        Task<UpdateCustomerDto> GetByIdAsync(string id);
        Task<List<ResultCustomerDto>> GetAllAsync();
        Task AddAsync(CreateCustomerDto createCustomerDto);
        Task UpdateAsync(UpdateCustomerDto updateCustomerDto);
        Task DeleteAsync(string id);
    }
}
