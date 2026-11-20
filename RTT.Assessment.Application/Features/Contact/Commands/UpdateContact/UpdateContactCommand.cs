using MediatR;

namespace RTT.Assessment.Application.Features.Contact.Commands.UpdateContact
{
    public record UpdateContactCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CellNumber { get; set; }
    }
}
