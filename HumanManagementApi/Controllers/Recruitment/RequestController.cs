using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HumanManagement.Domain.Recruitment.Dto;
using HumanManagement.CrossCutting.Utils;
using Microsoft.Extensions.Options;
using HumanManagement.Domain.Recruitment.QueryFilter;
using HumanManagement.Application.Recruitment.Queries;
using HumanManagement.Application.Recognition.Queries;
using static HumanManagement.Application.Recognition.Queries.GetPermissRecruitmenQuery;

namespace HumanManagementApi.Controllers.Recruitment
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : BaseApiController
    {
        private readonly AppSettings _appSettings;
        public RequestController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        [HttpPost("getlistpagination")]
        public async Task<IActionResult> GetListPagination([FromBody] RequestQueryFilter dto)
        {
            var result = await mediator.Send(new GetRequestQuery() { requestQueryFilter = dto });
            return result.Data == null ? NotFound() : (IActionResult)Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] RequestDto dto)
        {
            var result = await mediator.Send(new AddRequestQuery() { requestDto = dto });
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }
        [HttpGet("getemployeechargebyuser/{id}")]
        public async Task<IActionResult> GetEmployeeChargeByUser(int id)
        {
            var result = await mediator.Send(new GetEmployeeChargeQuery() { requestDto = id });
            return Ok(result);
        }
        [HttpGet("getrequestflow/{id}")]
        public async Task<IActionResult> GetRequestFlow(int id)
        {
            var result = await mediator.Send(new GetRequestFlowQuery() { requestDto = id });
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }

        [HttpGet("getrequestById/{id}")]
        public async Task<IActionResult> getrequestById(int id)
        {
            var result = await mediator.Send(new RecognitionByIdQuery() { Id = id });
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }

        [HttpGet("gestconfiguration/{IdOrigin}/{IdNivel}")]
        public async Task<IActionResult> getPermiss(int IdOrigin, int IdNivel)
        {
            var result = await mediator.Send(new GetPermissRecruitmenQuery() { IdOrigin = IdOrigin, IdNivel = IdNivel });
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }

        [HttpPost("addrequestflow")]
        public async Task<IActionResult> AddRequestFlow([FromBody] RequestFlowDto dto)
        {
            var result = await mediator.Send(new AddRequestFlowQuery() { requestDto = dto });
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] RequestUpdatedDto dto)
        {
            var result = await mediator.Send(new UpdateRequestQuery() { requestDto = dto });
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }
        [HttpPost("updatePregrado")]
        public async Task<IActionResult> UpdatePregrado([FromBody] RequestDto dto)
        {
            var result = await mediator.Send(new UpdateRequestPreQuery() { requestDto = dto });
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }
    }
}
