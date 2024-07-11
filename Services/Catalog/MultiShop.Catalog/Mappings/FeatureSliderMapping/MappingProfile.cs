using AutoMapper;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mappings.FeatureSliderMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ResultFeatureSliderDto, FeatureSlider>().ReverseMap();
            CreateMap<GetByIdFeatureSliderDto, FeatureSlider>().ReverseMap();
            CreateMap<UpdateFeatureSliderDto, FeatureSlider>().ReverseMap();
            CreateMap<CreateFeatureSliderDto, FeatureSlider>().ReverseMap();
        }
    }
}
