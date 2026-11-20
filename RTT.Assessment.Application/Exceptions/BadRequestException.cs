using FluentValidation.Results;
using Microsoft.IdentityModel.Tokens.Experimental;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Exceptions;

public class BadRequestException : Exception
{
    public IDictionary<string, string[]> validationErrorsDictionary { get; set; }


    public List<ValidationFailure> validationErrorsList { get; set; }
    public BadRequestException(string message, ValidationResult errors) : base(message)
    {
        validationErrorsDictionary = errors.ToDictionary();
    }

    public BadRequestException(string message, List<ValidationFailure> errors) : this(message, new ValidationResult())
    {
        validationErrorsList = new List<ValidationFailure>();
        foreach (var error in errors)
           validationErrorsList.Add(error);
    }
}
