using AutoMapper;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mappings.ContactMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
        }
    }
}
