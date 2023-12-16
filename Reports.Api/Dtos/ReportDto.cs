namespace Reports.Api.Dtos
{
    public class ReportDto
    {
        public Guid ID { get; set; }
        public DateTime RequestedDate { get; set; }
        public string Location { get; set; }
        public string ReportStatus { get; set; }
        public List<ReportDetailDto> ReportDetails { get; set; }
        public int RegisteredPersonCount { get; set; }
        public int RegisteredPhoneNumberCount { get; set; }
    }
}
