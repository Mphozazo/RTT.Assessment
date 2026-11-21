using MediatR;
using RTT.Assessment.Application.Features.Contact.Shared;

namespace RTT.Assessment.Application.Features.Contact.Commands.CreateContact;

public class CreateContactCommand :BaseContactCommand,IRequest<int>{}
