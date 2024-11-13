using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Exception
{
    public class DeluxeParfumValidationException : ApplicationException
    {

        public List<ValidationFailure> ValidationFailures { get; set; }
        public DeluxeParfumValidationException(List<ValidationFailure> validationFailures)
            : base("Validation Exception")
        {
            ValidationFailures = validationFailures;
        }

        public DeluxeParfumValidationException(string? message) : base(message)
        {
        }
    }
}
