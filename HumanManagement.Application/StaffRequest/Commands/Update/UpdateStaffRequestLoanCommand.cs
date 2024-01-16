using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Notification.Model;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.StaffRequest.Models;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Update
{
    public class UpdateStaffRequestLoanCommand : IRequest<Result>
    {
        public StaffRequestLoanDto StaffRequestLoan { get; set; }
    }
    public class UpdateStaffRequestLoanCommandHandler : IRequestHandler<UpdateStaffRequestLoanCommand, Result>
    {
        private readonly IBaseRepository<StaffRequestModel> baseStaffRequestRepository;
        private readonly IBaseRepository<StaffRequestLoan> baseStaffRequestLoanRepository;
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly IExactusEmpleadoRepository exactusEmpleadoRepository;
        public UpdateStaffRequestLoanCommandHandler(IBaseRepository<StaffRequestModel> baseStaffRequestRepository,
                                                    IBaseRepository<StaffRequestLoan> baseStaffRequestLoanRepository,
                                                    IBaseRepository<NotificationModel> baseNotificationRepository,
                                                    ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                    IStaffRequestRepository staffRequestRepository,
                                                    IMapper mapper,
                                                    IOptions<AppSettings> appSettings, IExactusEmpleadoRepository exactusEmpleadoRepository)
        {
            this.baseStaffRequestRepository = baseStaffRequestRepository;
            this.baseStaffRequestLoanRepository = baseStaffRequestLoanRepository;
            this.baseNotificationRepository = baseNotificationRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
            this.exactusEmpleadoRepository = exactusEmpleadoRepository;
        } 
        public async Task<Result> Handle(UpdateStaffRequestLoanCommand request, CancellationToken cancellationToken)
        {
            var staffRequest = mapper.Map<StaffRequestModel>(request.StaffRequestLoan.StaffRequest);
            staffRequest.DateUpdate = System.DateTime.Now;
            await baseStaffRequestRepository.UpdatePartial(staffRequest,
                x => x.DateUpdate,
                x => x.monthPay,
                x => x.yearPay);
            var staffRequestLoan = mapper.Map<StaffRequestLoan>(request.StaffRequestLoan);
            await baseStaffRequestLoanRepository.UpdatePartial(staffRequestLoan,
                x => x.Amount,
                x => x.AmountMonthlyFee,
                x => x.Balance,
                x => x.CobroUtilidad,
                x => x.CobroGratificacion,
                x => x.DetailReasonLoan,
                x => x.IdTypeLoan,
                x => x.NumberFee,
                x => x.NumberFee,
                x => x.DateLoan,
                x =>x.bUtil,
                x=>x.bGrati,
                x=>x.nAddGrati,
                x=>x.nAddUtilidad
                );


            decimal nrate = 0;
            var globalParameterExactus = await exactusEmpleadoRepository.GetExactusGlobalCCP("E_ALL");

            if (globalParameterExactus != null)
            {
                nrate = globalParameterExactus.tasa_anual_local;
            }

            request.StaffRequestLoan.RateExactus = nrate;

            await typeStaffRequestApproverRepository.InsertLoanDetail(request.StaffRequestLoan, staffRequest.Id);
          
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
