using MultiShop.Catalog.Dtos.CustomerDtos;

namespace MultiShop.Catalog.Services.CustomerServices.Abstract
{
    public interface ICustomerService
    {
        Task<GetByIdCustomerDto> GetByIdAsync(string id);
        Task<List<ResultCustomerDto>> GetAllAsync();
        Task AddAsync(CreateCustomerDto createCustomerDto);
        Task UpdateAsync(UpdateCustomerDto updateCustomerDto);
        Task DeleteAsync(string id);
    }
}
