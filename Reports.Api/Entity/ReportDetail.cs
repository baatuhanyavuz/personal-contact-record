using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reports.Api.Entity
{
    public class ReportDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [ForeignKey("ReportId")]
        public Guid ReportId { get; set; }

        public Report Reports { get; set; }

        [ForeignKey("PersonId")]
        public Guid PersonId { get; set; }
        public Person Persons { get; set; }

    }
}
