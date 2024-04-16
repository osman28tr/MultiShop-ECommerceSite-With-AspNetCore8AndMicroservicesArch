using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices.Abstract
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllAsync();
        Task<GetByIdProductDto> GetByIdProductAsync(string productId);
        Task AddAsync(CreateProductDto createProductDto);
        Task UpdateAsync(UpdateProductDto updateProductDto);
        Task DeleteAsync(string productId);
    }
}
