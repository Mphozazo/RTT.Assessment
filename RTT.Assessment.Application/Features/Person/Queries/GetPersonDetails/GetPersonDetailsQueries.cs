using MediatR;

namespace RTT.Assessment.Application.Features.Person.Queries.GetPersonDetails;

public record GetPersonDetailsQueries: IRequest<PersonDto>
{
    public int Id { get; set; }

}
