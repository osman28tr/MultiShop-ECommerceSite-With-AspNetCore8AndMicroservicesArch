using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CategoryServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string categoryId)
        {
            return await _httpClient.GetFromJsonAsync<GetByIdCategoryDto>($"categories/{categoryId}");
        }

        public async Task AddAsync(CreateCategoryDto createCategoryDto)
        {
             await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);
        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync("categories", updateCategoryDto);
        }

        public async Task DeleteAsync(string categoryId)
        {
            await _httpClient.DeleteAsync($"categories/{categoryId}");
        }
    }
}
