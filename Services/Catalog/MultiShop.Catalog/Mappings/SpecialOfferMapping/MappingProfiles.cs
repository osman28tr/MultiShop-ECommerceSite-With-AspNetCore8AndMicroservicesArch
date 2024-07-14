using AutoMapper;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mappings.SpecialOfferMapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<CreateSpecialOfferDto, SpecialOffer>().ReverseMap();
            CreateMap<UpdateSpecialOfferDto, SpecialOffer>().ReverseMap();
        }
    }
}
