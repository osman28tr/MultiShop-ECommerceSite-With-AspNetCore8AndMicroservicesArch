using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductDetailServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductDetailDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;
        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultProductDetailDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductDetailDto>>("ProductDetails");
        }

        public async Task<ResultProductDetailDto> GetByProductAsync(string productId)
        {
            return await _httpClient.GetFromJsonAsync<ResultProductDetailDto>($"ProductDetails/GetByProduct/{productId}");
        }

        public Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string productDetailId)
        {
            var result = _httpClient.GetFromJsonAsync<GetByIdProductDetailDto>($"ProductDetails/{productDetailId}");
            return result;
        }

        public async Task AddAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("ProductDetails", createProductDetailDto);
        }

        public async Task UpdateAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync("ProductDetails", updateProductDetailDto);
        }

        public async Task DeleteAsync(string productDetailId)
        {
            await _httpClient.DeleteAsync($"ProductDetails/{productDetailId}");
        }
    }
}
