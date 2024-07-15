using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountServices.Abstract
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllAsync();
        Task<GetByIdOfferDiscountDto> GetByIdAsync(string offerDiscountId);
        Task AddAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task UpdateAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
        Task DeleteAsync(string offerDiscountId);
    }
}
