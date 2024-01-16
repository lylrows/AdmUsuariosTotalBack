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

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class ApprovedAdvacementRequestCommand : IRequest<Result>
    {
        public ApprovedAdvacementDto payload { get; set; }
    }

    public class ApprovedAdvacementRequestCommandHandler : IRequestHandler<ApprovedAdvacementRequestCommand, Result>
    {
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitWork;
        private readonly IStaffRequestRepository _staffRequestRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository;
        private readonly IBaseRepository<StaffRequestModel> baseStaffRequestRepository;
        public ApprovedAdvacementRequestCommandHandler(IBaseRepository<Domain.Notification.Model.NotificationModel> basenotify,
                                                        IStaffRequestRepository staffRequestRepository,
                                                        IBaseRepository<StaffRequestModel> baseStaffRequestRepository,
                                                        IOptions<AppSettings> appSettings,
                                                        ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                        IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository,
                                                        IUnitOfWork unitWork)
        {
            _baseNotification = basenotify;
            this.baseStaffRequestRepository = baseStaffRequestRepository;
            _appSettings = appSettings.Value;
            _unitWork = unitWork;
            _staffRequestRepository = staffRequestRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.baseTypeStaffRequestRepository = baseTypeStaffRequestRepository;
        }
        public async Task<Result> Handle(ApprovedAdvacementRequestCommand request, CancellationToken cancellationToken)
        { 
            var typeStaffRequest = await baseTypeStaffRequestRepository.Find(request.payload.idTypeStaffRequest);
            int totalLevel = await typeStaffRequestApproverRepository.GetTotalLevels(request.payload.idTypeStaffRequest);
            var requestStatusChecker = new RequestStatusChecker(totalLevel, request.payload.nlevel);
            var staffRequest = new StaffRequestModel
            {
                Id = request.payload.nid_request
            };
            requestStatusChecker.SetStateApproved();
            staffRequest.SetComment(request.payload.comment);
            await baseStaffRequestRepository.UpdatePartial(staffRequest, x => x.Comment);
            var approver = await typeStaffRequestApproverRepository.GetByLevel(request.payload.idTypeStaffRequest, request.payload.nlevel + 1);
            StaffRequestApprover staffRequestApprover = new StaffRequestApprover()
            {
                Id = request.payload.nid_person,
                IdStaffRequest = request.payload.nid_request,
                Comment = request.payload.comment
            };
            await typeStaffRequestApproverRepository.AproveLevelRequest(staffRequestApprover);

            if (approver != null)
            {

                var list = await _staffRequestRepository.GetPersonByCharger(approver.IdProfile);
                await _staffRequestRepository.ApprovedAdvacement(request.payload, false);

                foreach (var item in list)
                {
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                    string fmt = File.ReadAllText(_appSettings.RegisterRequestAdvacement);

                    fmt = fmt.Replace("[URLEVALUATION]", _appSettings.URLEVALUACION);
                    fmt = fmt.Replace("[NAME]", item.sfullname);
                    fmt = fmt.Replace("[USERNAME]", request.payload.names);
                    fmt = fmt.Replace("[DNI]", request.payload.dni);
                    fmt = fmt.Replace("[ROLNAME]", request.payload.charge);
                    fmt = fmt.Replace("[SOLICITUD]", typeStaffRequest.Name);

                    newNotification.IdArea = item.nid_area;
                    newNotification.IdPerson = request.payload.nid_person; 
                    newNotification.IdReceptor = item.nid_person;
                    newNotification.Subject = "Solicitud de " + typeStaffRequest.Name;
                    newNotification.Body = fmt;
                    newNotification.SendDate = DateTime.Now;
                    newNotification.Active = true;

                    newNotification.Important = true;
                    newNotification.Favorite = true;

                    await _baseNotification.Add(newNotification);
                }

            } else
            {
                await _staffRequestRepository.ApprovedAdvacement(request.payload, true);

                Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                string fmt = File.ReadAllText(_appSettings.AceptRequestAdvacement);

                fmt = fmt.Replace("[URLEVALUATION]", _appSettings.URLEVALUACION);
                fmt = fmt.Replace("[SOLICITUD]", typeStaffRequest.Name);

                newNotification.IdArea = request.payload.nid_area;
                newNotification.IdPerson = request.payload.nid_person;
                newNotification.IdReceptor = request.payload.nid_receptor;
                newNotification.Subject = "Solicitud de "+ typeStaffRequest.Name + " aceptada";
                newNotification.Body = fmt;
                newNotification.SendDate = DateTime.Now;
                newNotification.Active = true;

                newNotification.Important = true;
                newNotification.Favorite = true;

                await _baseNotification.Add(newNotification);
            }


            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
