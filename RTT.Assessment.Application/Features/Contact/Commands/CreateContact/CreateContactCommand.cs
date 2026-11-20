using MediatR;

namespace RTT.Assessment.Application.Features.Contact.Commands.CreateContact
{
    public class CreateContactCommand : IRequest<int>
    {
        public int PersonId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CellNumber { get; set; }
    }
}
