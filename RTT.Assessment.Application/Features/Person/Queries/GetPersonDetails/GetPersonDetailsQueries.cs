using MediatR;

namespace RTT.Assessment.Application.Features.Person.Queries.GetPersonDetails;

public record GetPersonDetailsQueries(int Id) : IRequest<PersonDto>
{

}
