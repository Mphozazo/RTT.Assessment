using MediatR;
using RTT.Assessment.Application.Features.Address.Queries;
using RTT.Assessment.Domain.Enums;

namespace RTT.Assessment.Application.Features.Address.Commands.CreateAddress
{
    public record CreateAddressCommand : IRequest<AddressDto>
    {
        public int PersonId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public enumAddressType AddressType { get; set; }
    
    }
}
