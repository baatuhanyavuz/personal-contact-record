namespace Reports.Api.Dtos
{
    public class PersonDto
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<ContactInformationDto> ContactInformation { get; set; }
    }
}
