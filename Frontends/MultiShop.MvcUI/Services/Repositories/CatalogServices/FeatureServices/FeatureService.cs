using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;
        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultFeatureDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultFeatureDto>>("features");
        }

        public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string featureId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateFeatureDto>($"features/{featureId}");
        }

        public async Task AddAsync(CreateFeatureDto createFeatureDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureDto>("features", createFeatureDto);
        }

        public async Task UpdateAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _httpClient.PutAsJsonAsync("features", updateFeatureDto);
        }

        public async Task DeleteAsync(string featureId)
        {
            await _httpClient.DeleteAsync($"features/{featureId}");
        }
    }
}
