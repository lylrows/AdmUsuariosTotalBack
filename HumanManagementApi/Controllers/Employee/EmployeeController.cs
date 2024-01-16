using HumanManagement.Application.Employee.Queries;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.Person.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseApiController
    {

        [HttpGet()]
        public async Task<IActionResult> getAllEmploye([FromQuery] GetFilterEmploye request)
        {
            if (request.sfullname == null)
            {
                request.sfullname = "";
            }

            if (request.sidentification == null)
            {
                request.sidentification = "";
            }

            var listemployee = await mediator.Send(new GetListEmployeeQuery() { 
                sidentification = request.sidentification, 
                sfullname = request.sfullname, 
                nid_company = request.nid_company, 
                nid_position = request.nid_position, 
                nid_state = request.nid_state,
                currentPage = request.currentPage, 
                itemsPerPage = request.itemsPerPage, 
                totalItems = request.itemsPerPage, 
                totalPages = request.itemsPerPage, 
                totalRows = request.totalRows 
            });

            return Ok(listemployee);
        }


        [HttpGet("getAllNoPagination")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var listemployee = await mediator.Send(new GetAllEmployeeQuery() { });

            return Ok(listemployee);
        }


        [HttpGet("listCompany")]
        public async Task<IActionResult> getListCompany()
        {
            var listemployee = await mediator.Send(new GetListCompanyComboQuery());

            return Ok(listemployee);
        }

        [HttpGet("listPosition/{nid_company}")]
        public async Task<IActionResult> getAllEmploye(int nid_company)
        {
            var listemployee = await mediator.Send(new GetListPositionComboQuery() { nid_company = nid_company });

            return Ok(listemployee);
        }

        [HttpGet("detailt/{nid_person}")]
        public async Task<IActionResult> GetDetailtEmployee(int nid_person)
        {
            var listemployee = await mediator.Send(new GetDetailEmployeeQuery() { nid_person = nid_person });

            return Ok(listemployee);
        }

        [HttpGet("file/{nid_employee}")]
        public async Task<IActionResult> GetEmployeeFile(int nid_employee)
        {
            var employeeFile = await mediator.Send(new GetEmployeeFileQuery() { nid_employee = nid_employee });

            return Ok(employeeFile);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto payload)
        {
            var update = await mediator.Send(new UpdateEmployeeQuery() { payload = payload });
            return Ok(update);
        }

        [HttpPost("phoneMangement")]
        public async Task<IActionResult> PhoneManagement(PhoneManagementDto payload)
        {
            var management = await mediator.Send(new PhoneManagementQuery() { payload = payload });
            return Ok(management);
        }

        [HttpGet("listadress/{nid_person}")]
        public async Task<IActionResult> GetListAdress(int nid_person)
        {
            var listadress = await mediator.Send(new GetListAddressQuery() { nid_person = nid_person });

            return Ok(listadress);
        }

        [HttpPost("management")]
        public async Task<IActionResult> ManagementAddress([FromBody] AddressManagementDto payload)
        {
            var management = await mediator.Send(new ManagementAddressQuery() { payload = payload });

            return Ok(management);
        }

        [HttpPost("studeninsert")]
        public async Task<IActionResult> InsertStudenEmployee([FromBody] EmployeeInsRequestDto payload)
        {
            var management = await mediator.Send(new InsertStudenEmployeeQuery() { payload = payload });

            return Ok(management);
        }

        [HttpPost("studenUpd")]
        public async Task<IActionResult> UpdateStudenEmployee([FromBody] EmployeeEditRequestDto payload)
        {
            var management = await mediator.Send(new UpdateStudenEmployeeQuery() { payload = payload });

            return Ok(management);
        }

        [HttpPost("studenDelete")]
        public async Task<IActionResult> DeleteStudenEmployee([FromBody] DeleteStudenEmployeeDto payload)
        {
            var management = await mediator.Send(new DeleteStudenEmployeeQuery() { nid_studen = payload.nid_education });

            return Ok(management);
        }

        [HttpGet("studenlist/{id}")]
        public async Task<IActionResult> ListStudenEmployee(int id)
        {
            var management = await mediator.Send(new GetListtStudenEmployeeQuery() { nid_employee = id });

            return Ok(management);
        }

        [HttpGet("listinstruccion")]
        public async Task<IActionResult> ListInstruccion()
        {
            var management = await mediator.Send(new ListInstruccionQuery() { });

            return Ok(management);
        }

        [HttpGet("listson/{id}")]
        public async Task<IActionResult> ListSon(int id)
        {
            var management = await mediator.Send(new ListSonQuery() { nid_employee = id });

            return Ok(management);
        }

        [HttpPost("insertson")]
        public async Task<IActionResult> InsertSon([FromBody] InsertSonDto payload)
        {
            var management = await mediator.Send(new InsetSonQuery() { payload = payload });

            return Ok(management);
        }

        [HttpPost("updateson")]
        public async Task<IActionResult> UpdateSon([FromBody] UpdateSonDto payload)
        {
            var management = await mediator.Send(new UpdateSonQuery() { payload = payload });

            return Ok(management);
        }

        [HttpPost("insertjob")]
        public async Task<IActionResult> InsertJob([FromBody] InsertJobDto payload)
        {
            var management = await mediator.Send(new InsertEmployeeJobQuery() { payload = payload });

            return Ok(management);
        }

        [HttpPost("updatejob")]
        public async Task<IActionResult> UpdateJob([FromBody] UpdateJobDto payload)
        {
            var management = await mediator.Send(new UpdateEmployeeJobQuery() { payload = payload });

            return Ok(management);
        }

        [HttpPost("deletejob")]
        public async Task<IActionResult> DeleteJob([FromBody] DeleteJobDto payload)
        {
            var management = await mediator.Send(new DeleteEmployeeJobQuery() { payload = payload });

            return Ok(management);
        }

        [HttpGet("listjob/{id}")]
        public async Task<IActionResult> ListJob(int id)
        {
            var management = await mediator.Send(new ListEmployeeJobQuery() { nid_employee = id });

            return Ok(management);
        }

        [HttpGet("listmastertable/{id}")]
        public async Task<IActionResult> ListGenericMasterTable(int id)
        {
            var management = await mediator.Send(new ListMasterTableGeneriicQuery() { id = id });

            return Ok(management);
        }

        [HttpGet("listmastertablebykey/{key}")]
        public async Task<IActionResult> ListGenericMasterTableByKey(string key)
        {
            var management = await mediator.Send(new ListMasterTableGeneriicByKeyQuery() { key = key });

            return Ok(management);
        }

        [HttpPost("updatecovidcard")]
        public async Task<IActionResult> UpdateCovidCardEmployee()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<UpdateCovidCardDto>(dtoRequest);
            var management = await mediator.Send(new UpdateCovidCardQuery() { payload = dto, file = file });

            return Ok(management);
        }

        [HttpPost("updatefirma")]
        public async Task<IActionResult> UpdateFirmaEmployee()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<UpdateCovidCardDto>(dtoRequest);
            var management = await mediator.Send(new UpdateFirmaEmployeeQuery() { payload = dto, file = file });

            return Ok(management);
        }
        
        [HttpGet("getbossdropdown/{id}")]
        public async Task<IActionResult> GetBossDropDown(int id)
        {
            var management = await mediator.Send(new GetBossDropDownQuery() { nidPosition = id });

            return Ok(management);
        }


        [HttpGet("GetMonths/{id_tipo_documento}/{nyear}")]
        public async Task<IActionResult> GetMonths(int id_tipo_documento,int nyear)
        {
            var employeeFile = await mediator.Send(new GetEmployeeGetMonthsQuery() { nid_tipo_documento = id_tipo_documento,nyear=nyear });

            return Ok(employeeFile);
        }

    }
}
