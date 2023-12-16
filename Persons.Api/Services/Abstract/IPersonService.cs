using Persons.Api.Dtos;

namespace Persons.Api.Services.Abstract
{
    public interface IPersonService
    {
        Task AddPerson(PersonCreateDto data);
        Task<List<PersonDto>> GetPerson();
        Task DeletePerson(Guid personId);
    }
}
