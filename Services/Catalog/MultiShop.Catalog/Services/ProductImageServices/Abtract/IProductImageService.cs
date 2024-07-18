using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices.Abtract
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllAsync();
        Task<UpdateProductImageDto> GetAllByProductAsync(string productId);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string productImageId);
        Task AddAsync(CreateProductImageDto createProductImageDto);
        Task UpdateAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteAsync(string productImageId);
    }
}
