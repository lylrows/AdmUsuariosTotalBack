using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanManagement.Application.PostJobOffer.Commands.Create;
using HumanManagement.Application.PostJobOffer.Commands.Update;
using HumanManagement.Application.PostJobOffer.Queries;
using HumanManagement.Domain.Job.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanManagementApi.Controllers.PostJobOffer
{
    public class PostJobOfferController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> add(JobOfferDto jobDto)
        {
            var result = await mediator.Send(new CreateJobOfferCommand() { Job = jobDto });

            return Ok(result);
        }

        [HttpPost("addinternal")]
        public async Task<IActionResult> addinternal(JobOfferInternalDto jobDto)
        {
            var result = await mediator.Send(new CreateJobOfferInternalCommand() { dto = jobDto });

            return Ok(result);
        }

        [HttpGet("getbyidintern/{id}")]
        public async Task<IActionResult> GetByIdIntern(int id)
        {
            var result = await mediator.Send(new GetJobInternalByIdQuery() { IdRequest = id });

            return Ok(result);
        }


        [HttpPut("edit")]
        public async Task<IActionResult> edit(JobOfferDto jobDto)
        {
            var result = await mediator.Send(new UpdateJobOfferCommand() { Job = jobDto });

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetJobByIdQuery() { IdRequest = id });

            return Ok(result);
        }
    }
}