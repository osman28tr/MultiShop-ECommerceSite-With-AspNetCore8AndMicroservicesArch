using MultiShop.DtoLayer.CatalogDtos.CustomerDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CustomerServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCustomerDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCustomerDto>>("Customers");
        }

        public async Task<UpdateCustomerDto> GetByIdAsync(string customerId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateCustomerDto>($"Customers/{customerId}");
        }

        public async Task AddAsync(CreateCustomerDto createCustomerDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCustomerDto>("Customers", createCustomerDto);
        }

        public async Task UpdateAsync(UpdateCustomerDto updateCustomerDto)
        {
            await _httpClient.PutAsJsonAsync("Customers", updateCustomerDto);
        }

        public async Task DeleteAsync(string customerId)
        {
            await _httpClient.DeleteAsync($"Customers/{customerId}");
        }
    }
}
