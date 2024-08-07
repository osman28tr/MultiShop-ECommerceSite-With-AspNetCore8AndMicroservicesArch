using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.CategoryServices.Abstract
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllAsync();
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string categoryId);
        Task AddAsync(CreateCategoryDto createCategoryDto);
        Task UpdateAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteAsync(string categoryId);
    }
}
