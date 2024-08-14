using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultProductDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductDto>>("products");
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string productId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateProductDto>($"products/{productId}");
        }

        public async Task<List<ResultProductWithCategoryDto>> GetListProductWithCategory()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDto>>($"products");
        }

        public async Task<List<ResultProductDto>> GetListProductByCategory(string categoryId)
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductDto>>($"products/GetListByCategory/{categoryId}");
        }

        public async Task AddAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("products", createProductDto);
        }

        public async Task UpdateAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync("products", updateProductDto);
        }

        public async Task DeleteAsync(string ProductId)
        {
            await _httpClient.DeleteAsync($"products/{ProductId}");
        }
    }
}
