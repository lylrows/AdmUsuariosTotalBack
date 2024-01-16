using AutoMapper;
using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.StaffRequest.Models;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HumanManagement.Application.StaffRequest.Commands.Update
{
    public class UpdateStaffRequestTrainingExtraCommand : IRequest<Result>
    {
        public RegisterCapacitacionExtraDto payload { get; set; }
    }

    public class UpdateStaffRequestTrainingExtraCommandHandler : IRequestHandler<UpdateStaffRequestTrainingExtraCommand, Result>
    {
        private readonly IBaseRepository<StaffRequestModel> _baseStaffRequestRepository;
        private readonly IMapper mapper;
        private readonly SessionManager sessionManager;
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitWork;
        private readonly IStaffRequestRepository _staffRequestRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository;
        public UpdateStaffRequestTrainingExtraCommandHandler(IBaseRepository<StaffRequestModel> baseStaffRequestRepository,
                                                        IBaseRepository<Domain.Notification.Model.NotificationModel> basenotify,
                                                        ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                        IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository,
                                                        IStaffRequestRepository staffRequestRepository,
                                                        IMapper mapper,
                                                        IOptions<AppSettings> appSettings,
                                                        IUnitOfWork unitWork,
                                                        SessionManager sessionManager)
        {
            _baseNotification = basenotify;
            _baseStaffRequestRepository = baseStaffRequestRepository;
            this.mapper = mapper;
            this.sessionManager = sessionManager;
            _appSettings = appSettings.Value;
            _unitWork = unitWork;
            _staffRequestRepository = staffRequestRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.baseTypeStaffRequestRepository = baseTypeStaffRequestRepository;
        }
        public async Task<Result> Handle(UpdateStaffRequestTrainingExtraCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.payload.StaffRequest.StaffRequestEmployee.SetDateAdmissionToDate();
                var staffRequest = mapper.Map<StaffRequestModel>(request.payload.StaffRequest);
                request.payload.nid_request = staffRequest.Id;
                await _staffRequestRepository.UpdateRequestCapacitacionExtra(request.payload);


                await _unitWork.Commit();
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
            catch (Exception ex)
            {
                await _unitWork.Rollback();
                throw ex;
            }
        }
    }
}
