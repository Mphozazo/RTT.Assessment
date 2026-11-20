using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Features.Person.Queries.GetPersonDetails;

public class GetPersonDetailsQueriesHandler : IRequestHandler<GetPersonDetailsQueries, PersonDto>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    public GetPersonDetailsQueriesHandler(IPersonRepository personRepository , IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    public async Task<PersonDto> Handle(GetPersonDetailsQueries request, CancellationToken cancellationToken)
    {
        var person = await _personRepository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<PersonDto>(person);  
    }
}
