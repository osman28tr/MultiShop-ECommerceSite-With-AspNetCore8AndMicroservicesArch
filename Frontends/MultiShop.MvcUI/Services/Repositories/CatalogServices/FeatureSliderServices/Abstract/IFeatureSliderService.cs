using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureSliderServices.Abstract
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllAsync();
        Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string featureSliderId);
        Task AddAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteAsync(string featureSliderId);
        Task ChangeFeatureSliderStatus(string featureSliderId, bool status);
    }
}
