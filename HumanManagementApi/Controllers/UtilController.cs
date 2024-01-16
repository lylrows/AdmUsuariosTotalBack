using HumanManagement.Application.HMExactus.Queries;
using HumanManagement.Application.Multitest;
using HumanManagement.Application.Response;
using HumanManagement.Application.Utils.Queries;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Utils.Dto;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilController : BaseApiController
    {
        private readonly AppSettings _appSettings;
        public UtilController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [HttpGet("departament")]
        public async Task<IActionResult> GetDepartament()
        {
            var departament = await mediator.Send(new GetListDepartamentQuery());

            return Ok(departament);
        }

        [HttpGet("province/{Id}")]
        public async Task<IActionResult> GetProvince(int Id)
        {
            var province = await mediator.Send(new GetListProvinceQuery() { Id = Id });

            return Ok(province);
        }

        [HttpGet("district/{Id}")]
        public async Task<IActionResult> GetDistrict(int Id)
        {
            var district = await mediator.Send(new GetListDistrictQuery() { Id = Id });

            return Ok(district);
        }

        [HttpGet("sex")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSex()
        {
            var departament = await mediator.Send(new GetListSexQuery());

            return Ok(departament);
        } 
        
        [HttpGet("gettypedocument")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTypeDocument()
        {
            var departament = await mediator.Send(new GetTypeDocumentListQuery());

            return Ok(departament);
        }

        [HttpGet("nacionality")]
        [AllowAnonymous]
        public async Task<IActionResult> GetNacionality()
        {
            var departament = await mediator.Send(new GetListNacionalityQuery());

            return Ok(departament);
        }

        [HttpGet("civil")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCivilState()
        {
            var departament = await mediator.Send(new GetListCivilStateQuery());

            return Ok(departament);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var departament = await mediator.Send(new GetListActiveQuery());

            return Ok(departament);
        }

        [HttpGet("constcenter/{Id}")]
        public async Task<IActionResult> GetCostCenter(int Id)
        {
            var listconcenter = await mediator.Send(new GetListCostCenterQuery() { Id = Id });

            return Ok(listconcenter);
        }

        [HttpGet("area")]
        public async Task<IActionResult> GetArea()
        {
            var area = await mediator.Send(new GetListAreaQuery());

            return Ok(area);
        }

        [HttpGet("state")]
        public async Task<IActionResult> GetStateEmployee()
        {
            var state = await mediator.Send(new GetListStateQuery());

            return Ok(state);
        }

        [HttpGet("payroll")]
        public async Task<IActionResult> GetPayroll()
        {
            var payroll = await mediator.Send(new GetListPayrollQuery());

            return Ok(payroll);
        }

        [HttpGet("charger")]
        public async Task<IActionResult> GetCharger()
        {
            var payroll = await mediator.Send(new GetListChargerQuery());

            return Ok(payroll);
        }

        [HttpPost("getInfoMultitest")]
        public async Task<IActionResult> GeyInfoMultitest(MultitestDto dto)
        {
            var urMultitest = _appSettings.ApiMultitest;
            var result = await mediator.Send(new GetInfoMultitestQuery() { dto = dto, _urlMultitest = urMultitest });

            return Ok(result);
        }

        [HttpGet("getCategoryEmployment")]
        public async Task<IActionResult> GetCategoryEmployment()
        {
            var departament = await mediator.Send(new GetListCategoryEmployment());

            return Ok(departament);
        }

        [HttpGet("getexactusactiontype")]
        public async Task<IActionResult> GetExactusActionType()
        {
            var departament = await mediator.Send(new GetHMExactusActionTypeQuery());

            return Ok(departament);
        }

        [HttpGet("getexactusfamilytype")]
        [AllowAnonymous]
        public async Task<IActionResult> GetExactusFamilyType()
        {
            var departament = await mediator.Send(new GetHMExactusFamilyTypeQuery());

            return Ok(departament);
        }
        

        [HttpGet("getexactusabsencetype")]
        public async Task<IActionResult> GetExactusAbsenceType()
        {
            var departament = await mediator.Send(new GetHMExactusAbsenceTypeQuery());

            return Ok(departament);
        }

        [HttpGet("charge/{Id}")]
        public async Task<IActionResult> GetChargeByPosition(int Id)
        {
            var district = await mediator.Send(new GetChargePositionByIdQuery() { Id = Id });

            return Ok(district);
        }
        

        [HttpPost("getexactusemptable")]
        public async Task<IActionResult> GetExactusEmpTable(ExactusEmpleadoTablaFilterDto dto)
        {
            var result = await mediator.Send(new GetHMExactusEmpleadoTablaQuery() { filterDto = dto });

            return Ok(result);
        }
        [HttpPost("downloadbypath")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadByPath(FileDownloadDto dto)
        {
            
            byte[] bytes = System.IO.File.ReadAllBytes(dto.path_file);
            var _result = new Result
            {
                Data = bytes,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
            return Ok(_result);
        }
    }
}
