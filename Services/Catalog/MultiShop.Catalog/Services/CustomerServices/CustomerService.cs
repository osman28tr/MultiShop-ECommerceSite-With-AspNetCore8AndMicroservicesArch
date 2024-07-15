using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Dtos.CustomerDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CustomerServices.Abstract;

namespace MultiShop.Catalog.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly MultiShopCatalogContext _context;
        private readonly IMapper _mapper;
        public CustomerService(MultiShopCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ResultCustomerDto>> GetAllAsync()
        {
            var customers = await _context.Customers.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCustomerDto>>(customers);
        }

        public async Task<GetByIdCustomerDto> GetByIdAsync(string customerId)
        {
            var customer = await _context.Customers.Find(x => x.Id == customerId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCustomerDto>(customer);
        }

        public async Task AddAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = _mapper.Map<Customer>(createCustomerDto);
            await _context.Customers.InsertOneAsync(customer);
        }

        public async Task UpdateAsync(UpdateCustomerDto updateCustomerDto)
        {
            var customer = _mapper.Map<Customer>(updateCustomerDto);
            await _context.Customers.ReplaceOneAsync(x => x.Id == updateCustomerDto.Id, customer);
        }

        public async Task DeleteAsync(string customerId)
        {
            await _context.Customers.DeleteOneAsync(x => x.Id == customerId);
        }
    }
}
