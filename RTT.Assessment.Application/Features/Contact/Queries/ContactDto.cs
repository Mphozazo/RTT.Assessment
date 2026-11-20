using RTT.Assessment.Application.Features.Person.Queries;
namespace RTT.Assessment.Application.Features.Contact.Queries
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int PersonId { get; set; }
       public string? CellNumber { get; set; }
    }
}
