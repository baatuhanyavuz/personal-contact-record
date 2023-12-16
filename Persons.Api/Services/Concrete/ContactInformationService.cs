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

      
    }
}
