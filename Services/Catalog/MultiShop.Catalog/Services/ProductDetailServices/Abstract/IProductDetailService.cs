using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices.Abstract
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllAsync();
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string productDetailId);
        Task AddAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteAsync(string productDetailId);
    }
}
