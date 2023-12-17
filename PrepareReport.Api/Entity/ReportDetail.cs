using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace PrepareReport.Api.Entity
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