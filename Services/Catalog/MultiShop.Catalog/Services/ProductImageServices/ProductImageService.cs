using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductImageServices.Abtract;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly MultiShopCatalogContext _context;
        private readonly IMapper _mapper;
        public ProductImageService(MultiShopCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ResultProductImageDto>> GetAllAsync()
        {
            var productImages = await _context.ProductImages.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(productImages);
        }

        public async Task<UpdateProductImageDto> GetAllByProductAsync(string productId)
        {
            var productImages = await _context.ProductImages.Find(x => x.ProductId == productId).ToListAsync();
            var updateProductImageDto = _mapper.Map<UpdateProductImageDto>(productImages);
            return updateProductImageDto;
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string productImageId)
        {
            var productImage = await _context.ProductImages.Find(x => x.Id == productImageId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(productImage);
        }

        public async Task AddAsync(CreateProductImageDto createProductImageDto)
        {
            var productImage = _mapper.Map<ProductImage>(createProductImageDto);
            await _context.ProductImages.InsertOneAsync(productImage);
        }

        public async Task UpdateAsync(UpdateProductImageDto updateProductImageDto)
        {
            var productImage = _mapper.Map<ProductImage>(updateProductImageDto);
            await _context.ProductImages.ReplaceOneAsync(x => x.Id == updateProductImageDto.Id, productImage);
        }

        public async Task DeleteAsync(string productImageId)
        {
            await _context.ProductImages.DeleteOneAsync(x => x.Id == productImageId);
        }
    }
}
