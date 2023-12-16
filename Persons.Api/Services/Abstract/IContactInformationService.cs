using Persons.Api.Dtos;
using Persons.Api.Entity;

namespace Persons.Api.Services.Abstract
{
    public interface IContactInformationService
    {  
        Task AddContact(ContactInformationCreateDto data);
    }
}
