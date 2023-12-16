using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reports.Api.Entity
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public DateTime RequestedDate { get; set; }
        public string Location { get; set; }
        public string ReportStatus { get; set; }
        public int RegisteredPersonCount { get; set; }
        public int RegisteredPhoneNumberCount { get; set; }
        public virtual ICollection<ReportDetail> ReportDetails { get; set; }
    }
}
