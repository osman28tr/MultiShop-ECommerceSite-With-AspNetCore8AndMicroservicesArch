using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ContactServices.Abstract;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly MultiShopCatalogContext _context;
        private readonly IMapper _mapper;
        public ContactService(MultiShopCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateContactDto createContactDto)
        {
            var contactMapping = _mapper.Map<Contact>(createContactDto);
            await _context.Contacts.InsertOneAsync(contactMapping);
        }

        public async Task DeleteAsync(string contactId)
        {
            await _context.Contacts.DeleteOneAsync(x => x.Id == contactId);
        }
        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            var contacts = await _context.Contacts.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(contacts);
        }

        public async Task<GetByIdContactDto> GetByIdAsync(string contactId)
        {
            var contact = await _context.Contacts.Find(x => x.Id == contactId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(contact);
        }

        public async Task UpdateAsync(UpdateContactDto updateContactDto)
        {
            var contact = _mapper.Map<Contact>(updateContactDto);
            await _context.Contacts.ReplaceOneAsync(x => x.Id == updateContactDto.Id, contact);
        }
    }
}
