using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using AutoMapper;
using Serilog;

namespace RTT.Assessment.Application.Features.Address.Queries.GetAllAddressQueries;

public class GetAllAddressQueriesHandler : IRequestHandler<GetAllAddressQueries, IEnumerable<AddressDto>>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;

    public GetAllAddressQueriesHandler(IAddressRepository addressRepository , IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AddressDto>> Handle(GetAllAddressQueries request, CancellationToken cancellationToken)
    {
        try
        {
            var addresses = await _addressRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<AddressDto>>(addresses);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while handling GetAllAddressQueries.");
            throw;
        }

    }
}
