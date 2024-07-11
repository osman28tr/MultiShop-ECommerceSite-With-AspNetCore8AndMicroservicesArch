using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices.Abstract
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllAsync();
        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string featureSliderId);
        Task AddAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteAsync(string featureSliderId);
        Task ChangeFeatureSliderStatus(string featureSliderId, bool status);
    }
}
