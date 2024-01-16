using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetVacationsDaysQuery : IRequest<Result>
    {
        public string scode_employee { get; set; }
        public int idcompany { get; set; }
    }

    public class GetVacationsDaysQueryHandler : IRequestHandler<GetVacationsDaysQuery, Result>
    {
        private readonly IExactusMedicalRequestRepository _exactusMedicalRequestRepository;
        private readonly IBaseRepository<HumanManagement.Domain.Empresa.Models.Empresa> baseEmpresaRepository;
        public GetVacationsDaysQueryHandler(IExactusMedicalRequestRepository exactusMedicalRequestRepository,
                                            IBaseRepository<HumanManagement.Domain.Empresa.Models.Empresa> baseEmpresaRepository)
        {
            this._exactusMedicalRequestRepository = exactusMedicalRequestRepository;
            this.baseEmpresaRepository = baseEmpresaRepository;
        }

        public async Task<Result> Handle(GetVacationsDaysQuery query, CancellationToken cancellationToken)
        {
            var companyModel = await baseEmpresaRepository.Find(query.idcompany);
            var _days = await _exactusMedicalRequestRepository.GetVacationsDays(query.scode_employee, companyModel.Schema);
            return new Result
            {
                StateCode = 200,
                Data = _days
            };
        }
    }
}
