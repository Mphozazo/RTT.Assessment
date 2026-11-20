using MediatR;

namespace RTT.Assessment.Application.Features.Person.Queries.GetAllPersons
{
    public record GetAllPersonsQueries : IRequest<IEnumerable<PersonDto>>
    {
    }
}
