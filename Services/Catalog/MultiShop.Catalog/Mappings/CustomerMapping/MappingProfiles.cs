using AutoMapper;
using MultiShop.Catalog.Dtos.CustomerDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mappings.CustomerMapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCustomerDto, Customer>().ReverseMap();
            CreateMap<UpdateCustomerDto, Customer>().ReverseMap();
            CreateMap<ResultCustomerDto, Customer>().ReverseMap();
            CreateMap<GetByIdCustomerDto, Customer>().ReverseMap();
        }
    }
}
