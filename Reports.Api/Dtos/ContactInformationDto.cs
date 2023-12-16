namespace Reports.Api.Dtos
{
    public class ContactInformationDto
    {
        public Guid ID { get; set; }
        public Guid PersonID { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
    }
}
