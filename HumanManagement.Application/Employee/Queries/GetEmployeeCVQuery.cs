using HumanManagement.Application.Response;
using HumanManagement.Domain.Employee.Contracts;
using MediatR;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Dto;

namespace HumanManagement.Application.Employee.Queries
{
    public class GetEmployeeCVQuery : IRequest<Result>
    {
        public int nid_employee { get; set; }

        public class ListRequestHandler : IRequestHandler<GetEmployeeCVQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            private readonly ILogger<ListRequestHandler> _logger;
            private readonly IExactusEmpleadoRepository exactusEmpleadoRepository;

            public ListRequestHandler(IEmployeeRepository employeeRepository, ILogger<ListRequestHandler> logger
                , IExactusEmpleadoRepository exactusEmpleadoRepository)
            {
                this._employeeRepository = employeeRepository;
                this._logger = logger;
                this.exactusEmpleadoRepository = exactusEmpleadoRepository;
            }

            public async Task<Result> Handle(GetEmployeeCVQuery query, CancellationToken cancellationToken)
            {
                var detailtEmployee = await _employeeRepository.GetEmployeeCVById(query.nid_employee);

                var filterexactusdto = new ExactusEmpleadoTablaFilterDto();
                filterexactusdto.Scheme = "E_ALL";

                filterexactusdto.TableName="U_PLANEPS";
                var listPlanEps = await exactusEmpleadoRepository.GetEmpleadoTabla(filterexactusdto);
                filterexactusdto.TableName = "AFP";
                var listAfp = await exactusEmpleadoRepository.GetEmpleadoTabla(filterexactusdto);
                filterexactusdto.TableName = "U_CIAS_SEGUROS";
                var list_vidaley = await exactusEmpleadoRepository.GetEmpleadoTabla(filterexactusdto);
                filterexactusdto.TableName = "U_PLANSEGUROPRIV";
                var list_Fesalud = await exactusEmpleadoRepository.GetEmpleadoTabla(filterexactusdto); 


                var fesalud = list_Fesalud.Find(i => i.codigo == detailtEmployee.su_plansegpri);
                var vidaley = list_vidaley.Find(i => i.codigo == detailtEmployee.su_entsegvida);
                var eps = listPlanEps.Find(i => i.codigo == detailtEmployee.su_planeps);
                var afp = listAfp.Find(i => i.codigo == (detailtEmployee.safp_code =="2" ? "02" : detailtEmployee.safp_code));


                detailtEmployee.svidaley = vidaley == null ? "" : vidaley.descripcion;
                detailtEmployee.sfesalud = fesalud == null ? "" : fesalud.descripcion;
                detailtEmployee.seps = eps == null ? "" : eps.descripcion;
                detailtEmployee.safp = afp == null ? "" : afp.descripcion;

                detailtEmployee.listaJobs = await _employeeRepository.ListJob(query.nid_employee);
                _logger.LogInformation("listaJobs: " + detailtEmployee.listaJobs);

                detailtEmployee.listaStudients = await _employeeRepository.GetListStudenEmplooyee(query.nid_employee);
                _logger.LogInformation("listaStudients: " + detailtEmployee.listaStudients);

                detailtEmployee.listaSons = await _employeeRepository.ListSon(query.nid_employee);
                _logger.LogInformation("listaSons: " + detailtEmployee.listaSons);

                return new Result
                {
                    StateCode = 200,
                    Data = detailtEmployee
                };
            }
        }
    }
}
