using MediatR;

namespace RTT.Assessment.Application.Features.Contact.Queries.GetAllContact
{
    public record GetAllContactQueries : IRequest<IEnumerable<ContactDto>>
    {
    }
}
