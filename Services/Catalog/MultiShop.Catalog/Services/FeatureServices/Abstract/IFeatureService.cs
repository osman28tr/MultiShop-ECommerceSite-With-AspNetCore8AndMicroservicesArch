using MultiShop.Catalog.Dtos.FeatureDtos;

namespace MultiShop.Catalog.Services.FeatureServices.Abstract
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllAsync();
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string featureId);
        Task AddAsync(CreateFeatureDto createFeatureDto);
        Task UpdateAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteAsync(string featureId);
    }
}
