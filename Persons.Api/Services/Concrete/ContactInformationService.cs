using Microsoft.EntityFrameworkCore;
using Persons.Api.Context;
using Persons.Api.Dtos;
using Persons.Api.Entity;
using Persons.Api.Services.Abstract;

namespace Persons.Api.Services.Concrete
{
    public class ContactInformationService : IContactInformationService
    {
        private readonly AppDbContext _dbContext;

        public ContactInformationService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddContact(ContactInformationCreateDto data)
        {
            ContactInformation contact = new ContactInformation()
            {
                Email = data.Email,
                Location = data.Location,
                Phone = data.Phone,
                PersonID = data.PersonID
            };

            _dbContext.ContactInformations.Add(contact);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteContact(Guid id)
        {
            var contactDelete = await _dbContext.Persons.FindAsync(id);

            if (contactDelete != null)
            {
                _dbContext.Persons.Remove(contactDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<ContactInformation>> GetContact()
        {
            return await _dbContext.ContactInformations.ToListAsync();
        }
    }
}
