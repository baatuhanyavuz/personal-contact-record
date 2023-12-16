using Persons.Api.Dtos;
using Persons.Api.Entity;

namespace Persons.Api.Services.Abstract
{
    public interface IPersonService
    {
        Task DeletePerson(Guid personId);
        Task AddPerson(PersonCreateDto data);
        Task<List<Person>> GetPersonWithContactInfo();

        Task<List<PersonDto>> GetPerson();
    }
}
