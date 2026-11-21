using MediatR;

namespace RTT.Assessment.Application.Features.Address.Queries.GetAllAddressQueries;

public class GetAllAddressQueries : IRequest<IEnumerable<AddressDto>>
{
    public int? Id { get; set; }

}
