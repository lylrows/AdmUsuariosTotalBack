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
    public class ReportGraficStatusMedicalQuery : IRequest<Result>
    {
        public ReportGraficFilter payload { get; set; }
    }
    public class ReportGraficStatusMedicalQueryHandler : IRequestHandler<ReportGraficStatusMedicalQuery, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public ReportGraficStatusMedicalQueryHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(ReportGraficStatusMedicalQuery request, CancellationToken cancellationToken)
        {

            var days = await _requestMedicalRepository.ReportGraficByStatus(request.payload.ddateinit, request.payload.ddateend);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = days
            };
        }
    }
}
