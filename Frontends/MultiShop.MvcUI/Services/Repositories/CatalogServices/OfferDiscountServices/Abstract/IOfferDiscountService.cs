using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.OfferDiscountServices.Abstract
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllAsync();
        Task<UpdateOfferDiscountDto> GetByIdAsync(string offerDiscountId);
        Task AddAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task UpdateAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
        Task DeleteAsync(string offerDiscountId);
    }
}
