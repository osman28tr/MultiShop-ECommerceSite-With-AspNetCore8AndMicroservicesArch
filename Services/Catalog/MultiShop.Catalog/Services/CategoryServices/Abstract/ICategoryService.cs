using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices.Abstract
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
