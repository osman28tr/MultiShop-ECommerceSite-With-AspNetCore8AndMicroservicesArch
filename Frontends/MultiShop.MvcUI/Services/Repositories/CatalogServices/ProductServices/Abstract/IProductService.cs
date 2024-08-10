using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductServices.Abstract
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllAsync();
        Task<UpdateProductDto> GetByIdProductAsync(string productId);
        Task<List<ResultProductWithCategoryDto>> GetListProductWithCategory();
        Task AddAsync(CreateProductDto createProductDto);
        Task UpdateAsync(UpdateProductDto updateProductDto);
        Task DeleteAsync(string productId);
    }
}
