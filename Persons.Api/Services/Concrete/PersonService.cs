using Microsoft.EntityFrameworkCore;
using Persons.Api.Context;
using Persons.Api.Dtos;
using Persons.Api.Entity;
using Persons.Api.Services.Abstract;

namespace Persons.Api.Services.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _dbContext;
        public PersonService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPerson(PersonCreateDto data)
        {
            Person person = new Person()
            {
                Company = data.Company,
                FirstName = data.FirstName,
                LastName = data.LastName
            };

            _dbContext.Persons.Add(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePerson(Guid personId)
        {
            var personDelete = await _dbContext.Persons.FindAsync(personId);

            if (personDelete != null)
            {
                _dbContext.Persons.Remove(personDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<PersonDto>> GetPerson()
        {
            var personDto = await _dbContext.Persons
                .Select(r => new PersonDto
                {
                    Company = r.Company,
                    FirstName = r.FirstName,
                    LastName = r.LastName
                })
                .ToListAsync();

            return personDto;
        }

        public async Task<List<Person>> GetPersonWithContactInfo()
        {
            return await _dbContext.Persons
              .Include(p => p.ContactInformation)
              .ToListAsync();
        }
    }
}