using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.CommandHandlers.AddressCommandHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IAddressRepository _addressRepository;
        public CreateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task Handle(CreateAddressCommand request)
        {
            var address = new Address
            {
                District = request.District,
                City = request.City,
                Detail = request.Detail
            };
            await _addressRepository.AddAsync(address);
        }
    }
}
