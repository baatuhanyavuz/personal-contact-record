using Persons.Api.Dtos;
using Persons.Api.Entity;

namespace Persons.Api.Services.Abstract
{
    public interface IContactInformationService
    {
        Task DeleteContact(Guid id);
        Task AddContact(ContactInformationCreateDto data);
        Task<List<ContactInformation>> GetContact();
    }
}
