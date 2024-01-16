using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class CalculateTimelineCommand : IRequest<Result>
    {
        public StaffRequestLoanDto StaffRequestLoan { get; set; }

        public class CalculateTimelineCommandHandler : IRequestHandler<CalculateTimelineCommand, Result>
        {
            private readonly IStaffRequestLoanRepository staffRequestLoanRepository;
            private readonly IExactusEmpleadoRepository exactusEmpleadoRepository;
            public CalculateTimelineCommandHandler(IStaffRequestLoanRepository staffRequestLoanRepository, IExactusEmpleadoRepository exactusEmpleadoRepository)
            {
                this.staffRequestLoanRepository = staffRequestLoanRepository;
                this.exactusEmpleadoRepository = exactusEmpleadoRepository;
            }
            public async Task<Result> Handle(CalculateTimelineCommand request, CancellationToken cancellationToken)
            {
                decimal nrate = 0;
                var globalParameterExactus = await exactusEmpleadoRepository.GetExactusGlobalCCP("E_ALL");

                if (globalParameterExactus!= null)
                {
                    nrate = globalParameterExactus.tasa_anual_local;
                }

                request.StaffRequestLoan.RateExactus = nrate;

                if (request.StaffRequestLoan.bGrati)
                    request.StaffRequestLoan.CobroGratificacion = request.StaffRequestLoan.nAddGrati;

                if (request.StaffRequestLoan.bUtil)
                    request.StaffRequestLoan.CobroUtilidad = request.StaffRequestLoan.nAddUtilidad;

                var detail = await staffRequestLoanRepository.CalculateTimeLine(request.StaffRequestLoan);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = new { detail }
                };
            }
        }
    }
}
