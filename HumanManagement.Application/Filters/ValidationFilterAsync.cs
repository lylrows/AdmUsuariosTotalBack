using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using System.Linq;
using HumanManagement.Application.Response;

namespace HumanManagement.Application.Filters
{
    public class ValidationFilterAsync : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();


                Result result = new Result
                {
                    StateCode = 400,
                    MessageError = errors,
                    Data = null
                };

                context.Result = new JsonResult(result);
                return;
            }

            await next();
        }
    }
}
