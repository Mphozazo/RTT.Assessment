using MediatR;

namespace RTT.Assessment.Application.Features.Contact.Queries.GetPersonContactDetails
{
    public class GetPersonContactQueries : IRequest<IEnumerable<ContactDto>>
    {
        public int PersonId { get; set; }
    }
}
