using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class ReportGraficEtapaMedicalQuery : IRequest<Result>
    {
        public ReportGraficFilter payload { get; set; }
    }
    public class ReportGraficEtapaMedicalQueryHandler : IRequestHandler<ReportGraficEtapaMedicalQuery, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public ReportGraficEtapaMedicalQueryHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(ReportGraficEtapaMedicalQuery request, CancellationToken cancellationToken)
        {

            var days = await _requestMedicalRepository.ReportGraficByEtapa(request.payload.ddateinit, request.payload.ddateend);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = days
            };
        }
    }
}
