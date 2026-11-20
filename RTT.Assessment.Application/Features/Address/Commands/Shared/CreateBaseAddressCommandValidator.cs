using FluentValidation;
using RTT.Assessment.Application.Features.Address.Commands.CreateAddress;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Features.Address.Commands.Shared
{
    internal class CreateBaseAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateBaseAddressCommandValidator()
        {
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required.")
                .MaximumLength(200).WithMessage("Street cannot exceed 200 characters.");

            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.")
                .MaximumLength(100).WithMessage("City cannot exceed 100 characters.");

            RuleFor(x => x.Province).NotEmpty().WithMessage("Province is required.")
                .MaximumLength(100).WithMessage("Province cannot exceed 100 characters.");

            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Postal Code is required.")
                .MaximumLength(10).WithMessage("Postal Code cannot exceed 10 characters.");

            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.")
                .MaximumLength(200).WithMessage("Country cannot exceed 200 characters.");

            RuleFor(x => x.AddressType).IsInEnum().WithMessage("Invalid address type.");
        }
    }
}
