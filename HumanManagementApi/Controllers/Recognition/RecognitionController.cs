using HumanManagement.Application.Recognition.Commands.Create;
using HumanManagement.Application.Recognition.Queries;
using HumanManagement.Domain.Recognition.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Recognition
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecognitionController : BaseApiController
    {
        [HttpGet("{Id}/{IdUser}")]
        public async Task<IActionResult> getListRecognition(int Id, int IdUser)
        {
            var list = await mediator.Send(new GetListRecognitionQuery() { Id = Id, IdUser = IdUser });

            return Ok(list);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> changestate(int Id)
        {
            var recognition = await mediator.Send(new ChangeStateRecognitionQuery() { Id = Id });

            return Ok(recognition);
        }

        [HttpPut("delete/{Id}")]
        public async Task<IActionResult> delete(int Id)
        {
            var recognition = await mediator.Send(new DeleteRecognitionQuery() { Id = Id });

            return Ok(recognition);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateRecognitionDto dto)
        {
           try
            {
                var objReturn = await mediator.Send(new CreateRecognitionCommand() { newRecognition = dto });
                return Ok(objReturn);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
