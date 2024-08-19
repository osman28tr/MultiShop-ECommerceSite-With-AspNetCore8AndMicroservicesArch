using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.QueryHandlers.AddressQueryHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IAddressRepository _addressRepository;
        public GetAddressByIdQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery request)
        {
            var value = await _addressRepository.GetAsync(x => x.Id == request.Id);
            return new GetAddressByIdQueryResult
            {
                Id = value.Id,
                District = value.District,
                City = value.City,
                Detail = value.Detail
            };
        }
    }
}
