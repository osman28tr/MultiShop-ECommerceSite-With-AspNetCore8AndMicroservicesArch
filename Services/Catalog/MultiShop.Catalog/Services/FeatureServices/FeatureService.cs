using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.FeatureServices.Abstract;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly MultiShopCatalogContext _context;
        private readonly IMapper _mapper;
        public FeatureService(MultiShopCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ResultFeatureDto>> GetAllAsync()
        {
            var features = await _context.Features.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(features);
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string featureId)
        {
            var feature = await _context.Features.Find(x => x.Id == featureId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureDto>(feature);
        }

        public async Task AddAsync(CreateFeatureDto createFeatureDto)
        {
            var feature = _mapper.Map<Feature>(createFeatureDto);
            await _context.Features.InsertOneAsync(feature);
        }

        public async Task UpdateAsync(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _mapper.Map<Feature>(updateFeatureDto);
            await _context.Features.ReplaceOneAsync(x => x.Id == updateFeatureDto.Id, feature);
        }

        public async Task DeleteAsync(string featureId)
        {
            await _context.Features.DeleteOneAsync(x => x.Id == featureId);
        }
    }
}
