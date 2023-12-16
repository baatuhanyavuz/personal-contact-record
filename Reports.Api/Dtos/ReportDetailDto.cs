namespace Reports.Api.Dtos
{
    public class ReportDetailDto
    {
        public Guid ID { get; set; }
        public Guid ReportId { get; set; }
        public Guid PersonId { get; set; }
        public PersonDto Person { get; set; }
    }
}
