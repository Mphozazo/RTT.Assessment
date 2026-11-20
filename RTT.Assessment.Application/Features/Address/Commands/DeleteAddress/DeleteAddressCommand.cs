using MediatR;
using RTT.Assessment.Application.Features.Address.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Features.Address.Commands.DeleteAddress;

public class DeleteAddressCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
