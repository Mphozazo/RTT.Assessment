using FluentValidation;

namespace RTT.Assessment.Application.Features.Address.Commands.UpdateAddress
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        //Todo Use the CreateBaseAddressCommandValidator to validate the common properties
        public UpdateAddressCommandValidator()
        {
            // Include(new CreateBaseAddressCommandValidator());
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required.")
                .MaximumLength(200).WithMessage("Street cannot exceed 200 characters.");

            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.")
                .MaximumLength(100).WithMessage("City cannot exceed 100 characters.");

            RuleFor(x => x.Province).NotEmpty().WithMessage("Province is required.")
                .MaximumLength(100).WithMessage("Province cannot exceed 100 characters.");

            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("Zip Code is required.")
                .MaximumLength(5).WithMessage("Zip Code cannot exceed 5 characters.");

            RuleFor(x => x.AddressType).IsInEnum().WithMessage("Invalid address type.");
        }
    }
}
