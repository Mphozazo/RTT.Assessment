using MediatR;

namespace RTT.Assessment.Application.Features.Person.Commands.CreatePerson;

public class CreatePersonCommand : IRequest<int>
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Age { get; set; }
    public DateOnly DOB { get; set; }

}
