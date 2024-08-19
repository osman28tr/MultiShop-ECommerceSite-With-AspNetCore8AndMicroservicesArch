using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.QueryHandlers.AddressQueryHandlers
{
    public class GetListAddressQueryHandler
    {
        private readonly IAddressRepository _addressRepository;
        public GetListAddressQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _addressRepository.GetAllAsync(null);
            return values.Select(x => new GetAddressQueryResult
            {
                Id = x.Id,
                District = x.District,
                City = x.City,
                Detail = x.Detail
            }).ToList();
        }
    }
}
