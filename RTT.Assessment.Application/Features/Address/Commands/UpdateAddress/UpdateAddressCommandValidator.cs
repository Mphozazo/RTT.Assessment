using FluentValidation;
using RTT.Assessment.Application.Features.Address.Commands.Shared;

namespace RTT.Assessment.Application.Features.Address.Commands.UpdateAddress;

public class UpdateAddressCommandValidator : AbstractValidator<BaseAddressCommand>
{
 
    public UpdateAddressCommandValidator()
    {
         Include(new CreateBaseAddressCommandValidator());
    }
}
