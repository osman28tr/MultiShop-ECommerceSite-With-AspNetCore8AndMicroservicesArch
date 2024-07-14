using MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferServices.Abstract
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllAsync();
        Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string SpecialOfferId);
        Task AddAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteAsync(string SpecialOfferId);
    }
}
