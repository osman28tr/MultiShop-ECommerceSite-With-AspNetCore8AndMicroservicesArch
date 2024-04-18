using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.CommandHandlers.AddressCommandHandlers
{
    public class DeleteAddressCommandHandler
    {
        private readonly IAddressRepository _addressRepository;
        public DeleteAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task Handle(DeleteAddressCommand request)
        {
            var deletedAddress = await _addressRepository.GetAsync(x => x.Id == request.Id);
            await _addressRepository.DeleteAsync(deletedAddress);
        }
    }
}
