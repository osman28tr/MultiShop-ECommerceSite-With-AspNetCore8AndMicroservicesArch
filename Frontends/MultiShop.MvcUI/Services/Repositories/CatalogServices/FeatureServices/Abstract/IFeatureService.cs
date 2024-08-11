using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureServices.Abstract
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllAsync();
        Task<UpdateFeatureDto> GetByIdFeatureAsync(string featureId);
        Task AddAsync(CreateFeatureDto createFeatureDto);
        Task UpdateAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteAsync(string featureId);
    }
}
