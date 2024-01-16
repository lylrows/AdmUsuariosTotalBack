using HumanManagement.Application.Security.Queries;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Security.Dto;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace HumanManagementApi.FIlters
{
    public class CustomAuthorization : IAuthorizationFilter
    {
        private AuthorizationFilterContext context;
        private readonly SessionManager sessionManager;
        public CustomAuthorization(SessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            this.context = context;
            ValidateUserToken();
        }

        private void ValidateUserToken()
        {
            var request = context.HttpContext.Request;
            var headers = request.Headers;
            StringValues value = string.Empty;
            if (headers.TryGetValue("Authorization", out value))
            {
                if (value.ToString().Length > Constants.Token.INDEX_START_OF_TOKEN)
                {
                    TokenUserQueryDto tokenUserQueryDto = new TokenUserQueryDto
                    {
                        Token = value.ToString().Substring(7, value.ToString().Length - 7),
                        ApiRoute = request.Path.Value
                    };
                    IMediator mediatorToken = context.HttpContext.RequestServices.GetService<IMediator>();
                    bool isValidToken = mediatorToken.Send(new GetValidTokenQuery() { TokenUserQuery = tokenUserQueryDto }).Result;
                    if (!isValidToken)
                    {
                        context.HttpContext.Response.StatusCode = Constants.StateCodeResult.UNAUTHORIZED_ACCESS;
                        Result result = new Result
                        {
                            StateCode = Constants.StateCodeResult.UNAUTHORIZED_ACCESS,
                            MessageError = { "Acceso no Autorizado" }
                        };
                        context.Result = new JsonResult(result);
                    }
                    var user = mediatorToken.Send(new GetUserByTokenQuery() { Token = tokenUserQueryDto.Token }).Result;
                    sessionManager.User = user;
                }
            }
        }
    }
}
