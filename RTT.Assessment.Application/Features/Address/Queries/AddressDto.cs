using RTT.Assessment.Application.Features.Person.Queries;
using RTT.Assessment.Domain.Enums;

namespace RTT.Assessment.Application.Features.Address.Queries;

public class AddressDto
{
    public int Id { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public int PersonId { get; set; }
    public enumAddressType AddressType { get; set; }

}
