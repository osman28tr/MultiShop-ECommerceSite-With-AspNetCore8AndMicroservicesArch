using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductImageServices.Abstract
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllAsync();
        Task<List<UpdateProductImageDto>> GetAllByProductAsync(string productId);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string productImageId);
        Task AddAsync(CreateProductImageDto createProductImageDto);
        Task UpdateAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteAsync(string productImageId);
    }
}
