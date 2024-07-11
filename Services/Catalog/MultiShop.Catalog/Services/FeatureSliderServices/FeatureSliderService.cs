using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.FeatureSliderServices.Abstract;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly MultiShopCatalogContext _context;
        private readonly IMapper _mapper;
        public FeatureSliderService(MultiShopCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ResultFeatureSliderDto>> GetAllAsync()
        {
            var featureSliders = await _context.FeatureSliders.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(featureSliders);
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string featureSliderId)
        {
            var featureSlider = await _context.FeatureSliders.Find(x => x.Id == featureSliderId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureSliderDto>(featureSlider);
        }

        public async Task AddAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var featureSlider = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _context.FeatureSliders.InsertOneAsync(featureSlider);
        }

        public async Task UpdateAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var featureSlider = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _context.FeatureSliders.ReplaceOneAsync(x => x.Id == updateFeatureSliderDto.Id, featureSlider);
        }

        public async Task DeleteAsync(string featureSliderId)
        {
            await _context.FeatureSliders.DeleteOneAsync(x => x.Id == featureSliderId);
        }

        public async Task ChangeFeatureSliderStatus(string featureSliderId, bool status)
        {
            var featureSlider = await _context.FeatureSliders.Find(x => x.Id == featureSliderId).FirstOrDefaultAsync();
            featureSlider.Status = status;
            await _context.FeatureSliders.ReplaceOneAsync(x => x.Id == featureSliderId, featureSlider);
        }
    }
}
