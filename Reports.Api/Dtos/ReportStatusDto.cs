namespace Reports.Api.Dtos
{
    public class ReportStatusDto
    {
        public Guid Id{ get; set; }
        public DateTime RequestAt { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }
}
