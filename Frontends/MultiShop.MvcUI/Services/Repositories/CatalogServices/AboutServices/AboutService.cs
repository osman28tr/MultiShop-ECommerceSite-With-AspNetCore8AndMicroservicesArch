using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.AboutServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;
        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
        }

        public async Task<UpdateAboutDto> GetByIdAsync(string aboutId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateAboutDto>($"abouts/{aboutId}");
        }

        public async Task AddAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutDto>("abouts", createAboutDto);
        }

        public async Task UpdateAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync("abouts", updateAboutDto);
        }

        public async Task DeleteAsync(string aboutId)
        {
            await _httpClient.DeleteAsync($"abouts/{aboutId}");
        }
    }
}
