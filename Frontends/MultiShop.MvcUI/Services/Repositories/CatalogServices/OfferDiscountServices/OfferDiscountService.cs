using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.OfferDiscountServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;
        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultOfferDiscountDto>>("offerdiscounts");
        }

        public async Task<UpdateOfferDiscountDto> GetByIdAsync(string offerDiscountId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateOfferDiscountDto>($"offerdiscounts/{offerDiscountId}");
        }

        public async Task AddAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("offerdiscounts", createOfferDiscountDto);
        }

        public async Task UpdateAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _httpClient.PutAsJsonAsync("offerdiscounts", updateOfferDiscountDto);
        }

        public async Task DeleteAsync(string offerDiscountId)
        {
            await _httpClient.DeleteAsync($"offerdiscounts/{offerDiscountId}");
        }
    }
}
