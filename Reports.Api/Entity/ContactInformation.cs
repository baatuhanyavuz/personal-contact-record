using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json.Serialization;

namespace Reports.Api.Entity
{
    public class ContactInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Guid PersonID { get; set; }
        [JsonIgnore]
        [ForeignKey("PersonID")]
        public Person Person { get; set; }

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
    }

}
