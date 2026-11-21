using FluentValidation;
using RTT.Assessment.Application.Features.Address.Commands.Shared;

namespace RTT.Assessment.Application.Features.Address.Commands.CreateAddress;

public class CreateAddressCommandValidator : AbstractValidator<BaseAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        Include(new CreateBaseAddressCommandValidator());
    }
}
