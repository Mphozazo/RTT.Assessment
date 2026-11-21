using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Exceptions;
using RTT.Assessment.Application.Features.Address.Queries;
using RTT.Assessment.Application.Features.Contact.Queries;
using RTT.Assessment.Application.Features.Person.Queries;
using Serilog;

namespace RTT.Assessment.Application.Features.Reports
{
    public class GeneratePersonReportCommndHandler : IRequestHandler<GeneratePersonReportCommnd, PersonReportDto>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IPersonRepository _personRepository;

        public GeneratePersonReportCommndHandler(IMapper mapper, IAddressRepository addressRepository , IContactRepository contactRepository , IPersonRepository personRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _contactRepository = contactRepository;
            _personRepository = personRepository;
        }
        public async Task<PersonReportDto> Handle(GeneratePersonReportCommnd request, CancellationToken cancellationToken)
        {
            try
            {
                var person = _personRepository.GetByIdAsync(request.PersonId, cancellationToken).Result;
                if (person == null)
                    throw new NotFoundException($"Person with ID {request.PersonId} not found.");

                // compile all related Person Information including Address and Contact details into a PersonReportDto
                var addresses = _addressRepository.GetPersonAddressesDetailsAsync(request.PersonId, cancellationToken).Result;
                var contacts = _contactRepository.GetPersonContactDetailsAsync(request.PersonId, cancellationToken).Result;
                var personReportDto = new PersonReportDto
                {
                    PersonId = person.Id,
                    personDto = _mapper.Map<PersonDto>(person),
                    addressDtos = _mapper.Map<IEnumerable<Address.Queries.AddressDto>>(addresses),
                    contactDtos = _mapper.Map<IEnumerable<Contact.Queries.ContactDto>>(contacts)
                };


                return personReportDto;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while handling GeneratePersonReportCommnd");
                throw;
            }
           

        }
    }
}
