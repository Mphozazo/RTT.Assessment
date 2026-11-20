using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Features.Person.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(IPersonRepository personRepository , IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Domain.Person>(request);
            person.DateCreated = DateTime.UtcNow;
            person.DateUpdated = DateTime.UtcNow;
            await _personRepository.UpdateAsync(person, cancellationToken);
            return true;

        }
    }
}
