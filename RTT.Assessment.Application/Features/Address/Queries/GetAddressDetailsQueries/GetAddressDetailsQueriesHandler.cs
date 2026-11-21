using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using Serilog;

namespace RTT.Assessment.Application.Features.Address.Queries.GetAddressDetailsQueries
{
    public class GetAddressDetailsQueriesHandler : IRequestHandler<GetAddressDetailsQueries, IEnumerable<Contact.Queries.ContactDto>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetAddressDetailsQueriesHandler(IAddressRepository addressRepository , IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Contact.Queries.ContactDto>> Handle(GetAddressDetailsQueries request, CancellationToken cancellationToken)
        {
            try
            {
                var addresses = await _addressRepository.GetAllAsync(cancellationToken);
                var addressDtos = _mapper.Map<IEnumerable<Contact.Queries.ContactDto>>(addresses);
                return addressDtos;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while handling GetAddressDetailsQueries.");
                throw;
            }
        }
    }
}
