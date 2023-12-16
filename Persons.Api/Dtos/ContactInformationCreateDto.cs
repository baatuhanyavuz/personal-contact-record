using Persons.Api.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Persons.Api.Dtos
{
    public class ContactInformationCreateDto
    {
        public Guid PersonID { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(255)]
        public string Location { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }
    }
}
