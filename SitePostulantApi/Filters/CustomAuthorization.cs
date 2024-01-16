using Microsoft.AspNetCore.Mvc.Filters;
using SitePostulant.Application.Security.IServices;
using SitePostulant.Application.Helpers;

namespace SitePostulantApi.FIlters
{
    public class CustomAuthorization : IAuthorizationFilter
    {
        private AuthorizationFilterContext context;
        private readonly SessionManager sessionManager;
        private readonly ITokenService tokenService;
        public CustomAuthorization(SessionManager sessionManager, ITokenService tokenService)
        {
            this.sessionManager = sessionManager;
            this.tokenService = tokenService;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            this.context = context;
            ValidateUserToken();
        }

        private void ValidateUserToken()
        {
            
   
        }
    }
}
