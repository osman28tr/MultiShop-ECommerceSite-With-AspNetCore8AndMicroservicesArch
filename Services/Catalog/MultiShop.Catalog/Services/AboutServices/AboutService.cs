using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.AboutServices.Abstract;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly MultiShopCatalogContext _context;
        private readonly IMapper _mapper;
        public AboutService(MultiShopCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            var abouts = await _context.Abouts.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(abouts);
        }

        public async Task<GetByIdAboutDto> GetByIdAsync(string id)
        {
            var About = await _context.Abouts.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(About);
        }

        public async Task AddAsync(CreateAboutDto createAboutDto)
        {
            var about = _mapper.Map<About>(createAboutDto);
            await _context.Abouts.InsertOneAsync(about);
        }

        public async Task UpdateAsync(UpdateAboutDto updateAboutDto)
        {
            var about = _mapper.Map<About>(updateAboutDto);
            await _context.Abouts.ReplaceOneAsync(x => x.Id == updateAboutDto.Id, about);
        }

        public async Task DeleteAsync(string aboutId)
        {
            await _context.Abouts.DeleteOneAsync(x => x.Id == aboutId);
        }
    }
}
