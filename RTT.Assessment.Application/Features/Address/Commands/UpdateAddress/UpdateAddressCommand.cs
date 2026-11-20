using MediatR;
using RTT.Assessment.Application.Features.Address.Queries;
using RTT.Assessment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Features.Address.Commands.UpdateAddress;

public class UpdateAddressCommand : IRequest<AddressDto>
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string ZipCode { get; set; }
    public enumAddressType AddressType { get; set; }

}