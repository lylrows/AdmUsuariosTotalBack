using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HumanManagementApi.Controllers
{
    [EnableCors("AllowCors"),Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class BaseApiController : Controller
    {
        private IMediator _mediatorInstance;
        protected IMediator mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();

    }
}
