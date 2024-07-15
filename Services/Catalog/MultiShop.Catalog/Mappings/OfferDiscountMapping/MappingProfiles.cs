using AutoMapper;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mappings.OfferDiscountMapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateOfferDiscountDto, OfferDiscount>().ReverseMap();
            CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            CreateMap<GetByIdOfferDiscountDto, OfferDiscount>().ReverseMap();
            CreateMap<UpdateOfferDiscountDto, OfferDiscount>().ReverseMap();
        }
    }
}
