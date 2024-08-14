using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductImageServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;
        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultProductImageDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductImageDto>>("ProductImages");
        }

        public async Task<List<UpdateProductImageDto>> GetAllByProductAsync(string productId)
        {
            return await _httpClient.GetFromJsonAsync<List<UpdateProductImageDto>>($"ProductImages/GetListByProductId/{productId}");
        }

        public Task<GetByIdProductImageDto> GetByIdProductImageAsync(string productImageId)
        {
            var result = _httpClient.GetFromJsonAsync<GetByIdProductImageDto>($"ProductImages/{productImageId}");
            return result;
        }

        public async Task AddAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("ProductImages", createProductImageDto);
        }

        public async Task UpdateAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync("ProductImages", updateProductImageDto);
        }

        public async Task DeleteAsync(string productImageId)
        {
            await _httpClient.DeleteAsync($"ProductImages/{productImageId}");
        }
    }
}
