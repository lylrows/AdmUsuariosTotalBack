using FluentValidation.Results;
using HumanManagement.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanManagement.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> ValidationError { get; set; }
        public ValidationException()
        {

        }

        public ValidationException(string message)
            :base(message)
        {
            ValidationError[0] = message;
        }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
            ValidationError[0] = innerException.InnerException.Message;
        }

        public ValidationException(IList<ValidationFailure> validationError)
            : base()
        {
            ValidationError = validationError.Select(x => x.ErrorMessage).ToList();
        }
    }
}
