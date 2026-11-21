using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RTT.Assessment.Application.Contracts.Persistence;
using Serilog;

namespace RTT.Assessment.Application.Features.Person.Queries.GetAllPersons;

public class GetAllPersonsQueriesHandler : IRequestHandler<GetAllPersonsQueries, IEnumerable<PersonDto>>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    public GetAllPersonsQueriesHandler(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<PersonDto>> Handle(GetAllPersonsQueries request, CancellationToken cancellationToken)
    {
        try
        {
            var persons = await _personRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<PersonDto>>(persons);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error occurred while handling GetAllPersonsQueries");
            throw;
        }

    }   

}
