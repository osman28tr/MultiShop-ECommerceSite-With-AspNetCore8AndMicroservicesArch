using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.CommandHandlers.AddressCommandHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IAddressRepository _addressRepository;
        public UpdateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task Handle(UpdateAddressCommand request)
        {
            var value = await _addressRepository.GetAsync(x => x.Id == request.Id);
            value.Detail = request.Detail;
            value.City = request.City;
            value.District = request.District;
            value.UserId = request.UserId;
            await _addressRepository.UpdateAsync(value);
        }
    }
}
