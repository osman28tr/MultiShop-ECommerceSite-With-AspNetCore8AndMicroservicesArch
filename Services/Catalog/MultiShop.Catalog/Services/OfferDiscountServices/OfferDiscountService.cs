using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.OfferDiscountServices.Abstract;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly MultiShopCatalogContext _context;
        private readonly IMapper _mapper;
        public OfferDiscountService(MultiShopCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ResultOfferDiscountDto>> GetAllAsync()
        {
            var offerDiscounts = await _context.OfferDiscounts.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDto>>(offerDiscounts);
        }

        public async Task<GetByIdOfferDiscountDto> GetByIdAsync(string offerDiscountId)
        {
            var offerDiscount = await _context.OfferDiscounts.Find(x => x.Id == offerDiscountId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOfferDiscountDto>(offerDiscount);
        }

        public async Task AddAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var offerDiscount = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
            await _context.OfferDiscounts.InsertOneAsync(offerDiscount);
        }

        public async Task UpdateAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var offerDiscount = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
            await _context.OfferDiscounts.ReplaceOneAsync(x => x.Id == updateOfferDiscountDto.Id, offerDiscount);
        }

        public async Task DeleteAsync(string offerDiscountId)
        {
            await _context.OfferDiscounts.DeleteOneAsync(x => x.Id == offerDiscountId);
        }
    }
}
