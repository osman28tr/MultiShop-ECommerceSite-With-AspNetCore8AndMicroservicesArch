using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductServices.Abstract;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly MultiShopCatalogContext _context;
        private readonly IMapper _mapper;
        public ProductService(MultiShopCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResultProductDto>> GetAllAsync()
        {
            var products = await _context.Products.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string productId)
        {
            var product = await _context.Products.Find(x => x.Id == productId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(product);
        }

        public async Task AddAsync(CreateProductDto createProductDto)
        {
            await _context.Products.InsertOneAsync(_mapper.Map<Product>(createProductDto));
        }

        public async Task UpdateAsync(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            await _context.Products.ReplaceOneAsync(x => x.Id == updateProductDto.Id, product);
        }

        public async Task DeleteAsync(string productId)
        {
            await _context.Products.DeleteOneAsync(x => x.Id == productId);
        }
    }
}
