using System;
using System.Globalization;

namespace HumanManagement.Application.Exceptions
{
    public class ApiException : Exception
    {
        public string ValidationError { get; set; }
        public ApiException() : base()
        {
        }

        public ApiException(string message) : base(message)
        {
            ValidationError = message;
        }

        public ApiException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
            ValidationError = message;
        }
    }
}
