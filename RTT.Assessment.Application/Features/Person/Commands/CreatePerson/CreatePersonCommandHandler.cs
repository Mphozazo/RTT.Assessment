using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Exceptions;
using Serilog;

namespace RTT.Assessment.Application.Features.Person.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // do validation on incoming request 
                var validator = new CreatePersonCommandValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (validationResult.Errors.Any())
                    throw new BadRequestException("Invalid Person Request", validationResult);


                var person = _mapper.Map<Domain.Person>(request);
                person = await _personRepository.AddAsync(person, cancellationToken);

                return person.Id;
            }
            catch (Exception ex)
            {
                 Log.Error(ex, "Error occurred while handling CreatePersonCommand");
                throw;
            }
        }
    }
}
