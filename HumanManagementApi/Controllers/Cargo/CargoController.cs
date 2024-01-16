using HumanManagement.Application.Cargo.Commands.Create;
using HumanManagement.Application.Cargo.Commands.Delete;
using HumanManagement.Application.Cargo.Commands.Edit;
using HumanManagement.Application.Cargo.Queries;
using HumanManagement.Domain.Cargo.Dto;
using HumanManagement.Domain.Cargo.QueryFilter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Cargo
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CargoDto dto)
        {
            var result = await mediator.Send(new CreateCargoCommand() { cargoDto = dto });
            return Ok(result);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody] CargoDto dto)
        {
            var result = await mediator.Send(new EditCargoCommand() { cargoDto = dto });
            return new OkObjectResult(result);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteCargoCommand() { Id = id });
            return new OkObjectResult(result);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] CargoQueryFilter dto)
        {
            var cargo = await mediator.Send(new GetCargoQuery() { cargoQueryFilter = dto});
            return cargo.Data == null ? NotFound() : (IActionResult)Ok(cargo);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var cargo = await mediator.Send(new GetAllCargoQuery());
            return cargo.Data == null ? NotFound() : (IActionResult)Ok(cargo);
        }

        [HttpGet("getjefe/{id}")]
        public async Task<IActionResult> GetJefeByCargo(int IdCharge)
        {
            var cargo = await mediator.Send(new GetJefeByChargeQuery() { IdCharge = IdCharge});
            return Ok(cargo);
        }
        [HttpGet("getcompetencia/{idRequest}/{idCargo}/{primeraCarga}")]
        public async Task<IActionResult> GetCompetenciasByCargo(int idRequest, int idCargo, int primeraCarga)
        {
            var cargo = await mediator.Send(new GetCompetenciaByCargo() { IdRequest = idRequest, IdCharge = idCargo, PrimeraCarga = primeraCarga });
            return Ok(cargo);
        }

        [HttpPost("addconfig")]
        public async Task<IActionResult> Add([FromBody] List<CargoCompetenciaDto> dto)
        {
            var result = await mediator.Send(new AddCargoConfigQuery() { listCargoDto = dto });
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }


        [HttpPost("getcombocargo")]
        public async Task<IActionResult> Get([FromBody] FilterCargoDto dto)
        {
            var cargo = await mediator.Send(new GetCargoComboQuery() { filter = dto });
            return cargo.Data == null ? NotFound() : (IActionResult)Ok(cargo);
        }

        [HttpPost("getchargesbycompanyarea")]
        public async Task<IActionResult> GetChargesByCompanyArea(ChargesByCompanyAreaFilter dto)
        {
            var cargo = await mediator.Send(new GetChargesByCompanyAreaQuery() { chargesByCompanyAreaFilter = dto });
            return Ok(cargo);
        }
        [HttpPost("getchargesbycompanyareav2")]
        public async Task<IActionResult> GetChargesByCompanyAreav2(ChargesByCompanyAreaFilter dto)
        {
            var cargo = await mediator.Send(new GetChargesByCompanyAreav2Query() { chargesByCompanyAreaFilter = dto });
            return Ok(cargo);
        }

        [HttpPost("getchargesbycompanyareamulti")]
        public async Task<IActionResult> GetChargesByCompanyAreaMulti(ChargesByCompanyAreaMultiFilter dto)
        {
            var cargo = await mediator.Send(new GetChargesByCompanyAreaMultiQuery() { chargesByCompanyAreaFilter = dto });
            return Ok(cargo);
        }
    }
}
