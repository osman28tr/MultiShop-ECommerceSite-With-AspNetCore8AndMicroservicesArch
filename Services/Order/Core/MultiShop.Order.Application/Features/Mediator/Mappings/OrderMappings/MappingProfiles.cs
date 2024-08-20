using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderCommands;
using MultiShop.Order.Application.Features.Mediator.Dtos;
using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Mappings.OrderMappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Ordering, GetListOrderQueryResult>().ReverseMap();
            CreateMap<Ordering, GetOrderByIdQueryResult>().ReverseMap();
            //CreateMap<Ordering, CreateOrderCommand>()
            //    .ForMember(x => x.OrderDetails, opt => opt.Ignore())
            //    .ForMember(x => x.OrderAddress, opt => opt.MapFrom(src => src.Address))
            //    .ReverseMap();
            CreateMap<Address, CreateOrderAddressDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
            CreateMap<Ordering, UpdateOrderCommand>().ReverseMap();
        }
    }
}
