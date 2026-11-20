using MediatR;

namespace RTT.Assessment.Application.Features.Contact.Queries.GetPersonContactDetails
{
    public class GetContactDetailsQueries : IRequest<ContactDto>
    {
        public int Id { get; set; }
    }
}
