using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;

namespace RTT.Assessment.Application.Features.Contact.Queries.GetPersonContactDetails;

public class GetContactDetailsQueriesHandler : IRequestHandler<GetContactDetailsQueries, ContactDto>
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public GetContactDetailsQueriesHandler(IContactRepository contactRepository , IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }


    public async Task<ContactDto> Handle(GetContactDetailsQueries request, CancellationToken cancellationToken)
    {
        var contactsDetails = await _contactRepository.GetByIdAsync(request.Id, cancellationToken);

        var contactDtos = _mapper.Map<ContactDto>(contactsDetails);

        return contactDtos;

    }


}
