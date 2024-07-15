using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CategoryServices.Abstract;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly MultiShopCatalogContext _context;
        private readonly IMapper _mapper;
        public CategoryService(MultiShopCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddAsync(CreateCategoryDto createCategoryDto)
        {
            var categoryMapping = _mapper.Map<Category>(createCategoryDto);
            await _context.Categories.InsertOneAsync(categoryMapping);
        }

        public async Task DeleteAsync(string categoryId)
        {
            await _context.Categories.DeleteOneAsync(x => x.Id == categoryId);
        }
        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(categories);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string categoryId)
        {
            var category = await _context.Categories.Find(x => x.Id == categoryId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(category);
        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            await _context.Categories.ReplaceOneAsync(x => x.Id == updateCategoryDto.Id, category);
        }
    }
}
