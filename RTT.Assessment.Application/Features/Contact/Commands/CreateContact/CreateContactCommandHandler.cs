using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Exceptions;
using RTT.Assessment.Application.Features.Contact.Commands.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Features.Contact.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public CreateContactCommandHandler(IContactRepository contactRepository , IMapper mapper , IPersonRepository personRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _personRepository = personRepository;
        }
        public async Task<int> Handle(CreateContactCommand request,CancellationToken cancellationToken)
        {
            try {
                var contactValidation = new CreateBaseContactCommandValidator(_personRepository);
                var validationResult = await contactValidation.ValidateAsync(request, cancellationToken);
                if (validationResult.Errors.Any())
                    throw new BadRequestException("Invalid Contact Request", validationResult);


                var contact = _mapper.Map<Domain.Contact>(request);
                

                await _contactRepository.AddAsync(contact, cancellationToken);
                return contact.Id;
            }
            catch (Exception ex)
            {
                // log to Serilog file
                throw ;
            }   
           

        }
    }
}
