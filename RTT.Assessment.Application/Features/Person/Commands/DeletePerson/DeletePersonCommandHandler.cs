using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Exceptions;

namespace RTT.Assessment.Application.Features.Person.Commands.DeletePerson;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Unit>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public DeletePersonCommandHandler(IPersonRepository personRepository , IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;   
    }

    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _personRepository.GetByIdAsync(request.Id, cancellationToken);

        if (person == null)
            throw new NotFoundException(nameof(Person), request.Id);

        await _personRepository.DeleteAsync(person, cancellationToken);
        return Unit.Value;
    }
}
