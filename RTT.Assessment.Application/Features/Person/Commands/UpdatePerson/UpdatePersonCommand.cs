using MediatR;

namespace RTT.Assessment.Application.Features.Person.Commands.UpdatePerson
{
    public record UpdatePersonCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public DateOnly DOB { get; set; }

    }
}
