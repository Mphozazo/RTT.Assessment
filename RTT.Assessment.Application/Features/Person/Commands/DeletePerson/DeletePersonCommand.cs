using MediatR;

namespace RTT.Assessment.Application.Features.Person.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
