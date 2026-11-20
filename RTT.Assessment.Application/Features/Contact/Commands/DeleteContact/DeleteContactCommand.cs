using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Features.Contact.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
