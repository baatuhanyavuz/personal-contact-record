using System.ComponentModel.DataAnnotations;

namespace Persons.Api.Dtos
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
