using MediatR;
using RTT.Assessment.Application.Features.Contact.Shared;

namespace RTT.Assessment.Application.Features.Contact.Commands.UpdateContact;

public class UpdateContactCommand :BaseContactCommand ,  IRequest<Unit>{}
