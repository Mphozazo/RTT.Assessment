using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;

namespace RTT.Assessment.Application.Features.Contact.Queries.GetPersonContactDetails
{
    public class GetPersonContactQueriesHandler : IRequestHandler<GetPersonContactQueries, IEnumerable<ContactDto>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetPersonContactQueriesHandler(IContactRepository contactRepository , IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDto>> Handle(GetPersonContactQueries request, CancellationToken cancellationToken)
        {
            var personContacts = await _contactRepository.GetPersonContactDetailsAsync(request.PersonId, cancellationToken);

            var personContactDtos = _mapper.Map<IEnumerable<ContactDto>>(personContacts);

            return personContactDtos;
        }
    }
}
