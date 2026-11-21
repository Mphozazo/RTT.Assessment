using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;

namespace RTT.Assessment.Application.Features.Contact.Queries.GetAllContact;

public class GetAllContactQueriesHandler : IRequestHandler<GetAllContactQueries, IEnumerable<ContactDto>>
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public GetAllContactQueriesHandler(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper  ;
    }
    public async Task<IEnumerable<ContactDto>> Handle(GetAllContactQueries request, CancellationToken cancellationToken)
    {
        var contacts = await _contactRepository.GetAllAsync( cancellationToken );

        var contactDtos = _mapper.Map<IEnumerable<ContactDto>>(contacts);

        return contactDtos;

    }
}
