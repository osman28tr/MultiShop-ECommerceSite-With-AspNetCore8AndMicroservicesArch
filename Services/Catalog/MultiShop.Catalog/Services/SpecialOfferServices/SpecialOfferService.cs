using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.SpecialOfferServices.Abstract;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly MultiShopCatalogContext _context;
        private readonly IMapper _mapper;
        public SpecialOfferService(MultiShopCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var mappingValue = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _context.SpecialOffers.InsertOneAsync(mappingValue);
        }

        public async Task DeleteAsync(string SpecialOfferId)
        {
            await _context.SpecialOffers.DeleteOneAsync(x => x.Id == SpecialOfferId);
        }
        public async Task<List<ResultSpecialOfferDto>> GetAllAsync()
        {
            var specialOffers = await _context.SpecialOffers.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(specialOffers);
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string SpecialOfferId)
        {
            var specialOffer = await _context.SpecialOffers.Find(x => x.Id == SpecialOfferId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDto>(specialOffer);
        }

        public async Task UpdateAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var specialOffer = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _context.SpecialOffers.ReplaceOneAsync(x => x.Id == updateSpecialOfferDto.Id, specialOffer);
        }
    }
}
