using RTT.Assessment.Domain.Enums;
using System.Text.Json.Serialization;

namespace RTT.Assessment.Application.Features.Address.Commands.Shared;

public abstract class BaseAddressCommand
{
    public int Id { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public enumAddressType AddressType { get; set; }
    [JsonIgnore]
    public DateTime? DateCreated { get; set; }
    [JsonIgnore]
    public DateTime? DateUpdated { get; set; }
    [JsonIgnore]
    public int PersonId { get; set; }
}
