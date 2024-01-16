using HumanManagement.CrossCutting.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SitePostulant.Application.Exceptions;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SitePostulant.Application.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> logger;
        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var stackTrace = new StackTrace(context.Exception);
            var frame = stackTrace.GetFrame(0);
            logger.LogError(context.Exception,
                            GetMethodName(frame.GetMethod()),
                            GetClassName(frame.GetMethod()));
            Result result = null;
            if (context.Exception is ValidationException)
            {
                result = SetValidationException(context);
            }
            else if (context.Exception is ApiException)
            {
                var ex = context.Exception as ApiException;
                result = new Result
                {
                    StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                    MessageError = new List<string>()
                    {
                        ex.Message
                    }
                };
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                var ex = context.Exception as UnauthorizedAccessException;
                
                result = new Result
                {
                    StateCode = Constants.StateCodeResult.UNAUTHORIZED_ACCESS,
                    MessageError = new List<string>()
                    {
                        ex.Message
                    }
                };
            }
            else {
                var ex = context.Exception as Exception;
                result = new Result
                {
                    StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                    MessageError = new List<string>()
                    {
                        ex.Message
                    }
                };
            }

            context.Result = new JsonResult(result);
        }

        private Result SetValidationException(ExceptionContext context)
        {
            var ex = context.Exception as ValidationException;
            return new Result
            {
                StateCode = Constants.StateCodeResult.BAD_REQUEST,
                MessageError = ex.ValidationError
            };
        }

        private string GetMethodName(System.Reflection.MethodBase method)
        {
            string _methodName = method.DeclaringType != null ? method.DeclaringType.FullName : string.Empty;

            if (_methodName.Contains(">") || _methodName.Contains("<"))
            {
                _methodName = _methodName.Split('<', '>')[1];
            }
            else
            {
                _methodName = method.Name;
            }

            return _methodName;
        }

        private string GetClassName(System.Reflection.MethodBase method)
        {
            string className = method.DeclaringType != null ? method.DeclaringType.FullName : string.Empty;

            if (className.Contains(">") || className.Contains("<"))
            {
                className = className.Split('+')[0];
            }
            return className;
        }
    }
}
