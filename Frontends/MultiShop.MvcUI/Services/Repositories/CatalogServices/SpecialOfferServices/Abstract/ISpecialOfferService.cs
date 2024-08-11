using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.SpecialOfferServices.Abstract
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllAsync();
        Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string specialOfferId);
        Task AddAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteAsync(string specialOfferId);
    }
}
