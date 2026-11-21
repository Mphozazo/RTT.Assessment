using MediatR;

namespace RTT.Assessment.Application.Features.Address.Queries.GetAddressDetailsQueries;

public class GetAddressDetailsQueries : IRequest<IEnumerable<Contact.Queries.ContactDto>>
{
}
