using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.SpecialOfferServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;
        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultSpecialOfferDto>>("specialoffers");
        }

        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string specialOfferId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateSpecialOfferDto>($"specialoffers/{specialOfferId}");
        }

        public async Task AddAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", createSpecialOfferDto);
        }

        public async Task UpdateAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync("specialoffers", updateSpecialOfferDto);
        }

        public async Task DeleteAsync(string specialOfferId)
        {
            await _httpClient.DeleteAsync($"specialoffers/{specialOfferId}");
        }
    }
}
