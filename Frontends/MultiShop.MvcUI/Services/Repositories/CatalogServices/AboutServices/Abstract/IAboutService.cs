using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.AboutServices.Abstract
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAsync();
        Task<UpdateAboutDto> GetByIdAsync(string id);
        Task AddAsync(CreateAboutDto createAboutDto);
        Task UpdateAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAsync(string id);
    }
}
