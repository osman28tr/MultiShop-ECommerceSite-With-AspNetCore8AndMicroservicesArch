using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductDetailServices.Abstract
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllAsync();
        Task<ResultProductDetailDto> GetByProductAsync(string productId);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string productDetailId);
        Task AddAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteAsync(string productDetailId);
    }
}
