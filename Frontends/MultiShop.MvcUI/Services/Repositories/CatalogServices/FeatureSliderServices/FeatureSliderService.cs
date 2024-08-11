using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureSliderServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;
        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultFeatureSliderDto>>("featuresliders");
        }

        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string featureSliderId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateFeatureSliderDto>($"featuresliders/{featureSliderId}");
        }

        public async Task AddAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featuresliders", createFeatureSliderDto);
        }

        public async Task UpdateAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync("featuresliders", updateFeatureSliderDto);
        }

        public async Task DeleteAsync(string featureSliderId)
        {
            await _httpClient.DeleteAsync($"featuresliders/{featureSliderId}");
        }

        public async Task ChangeFeatureSliderStatus(string featureSliderId, bool status)
        {
            await _httpClient.PutAsync($"featuresliders/{featureSliderId}/status/{status}", null);
        }
    }
}
