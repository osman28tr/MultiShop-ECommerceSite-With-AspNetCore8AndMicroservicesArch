using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductDetailServices.Abstract;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly MultiShopCatalogContext _context;
        private readonly IMapper _mapper;
        public ProductDetailService(MultiShopCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ResultProductDetailDto>> GetAllAsync()
        {
            var productDetails = await _context.ProductDetails.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(productDetails);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string productDetailId)
        {
            var productDetail = await _context.ProductDetails.Find(x => x.Id == productDetailId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(productDetail);
        }

        public async Task AddAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _context.ProductDetails.InsertOneAsync(_mapper.Map<ProductDetail>(createProductDetailDto));
        }

        public Task UpdateAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
            return _context.ProductDetails.ReplaceOneAsync(x => x.Id == updateProductDetailDto.Id, productDetail);
        }

        public async Task DeleteAsync(string productDetailId)
        {
            await _context.ProductDetails.DeleteOneAsync(x => x.Id == productDetailId);
        }
    }
}
