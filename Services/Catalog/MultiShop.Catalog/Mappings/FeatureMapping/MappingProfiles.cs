using AutoMapper;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mappings.FeatureMapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ResultFeatureDto, Feature>().ReverseMap();
            CreateMap<CreateFeatureDto, Feature>().ReverseMap();
            CreateMap<UpdateFeatureDto, Feature>().ReverseMap();
            CreateMap<GetByIdFeatureDto, Feature>().ReverseMap();
        }
    }
}
