using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.StaffRequest.Models;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class ApprovedTrainingNewCommand : IRequest<Result>
    {
        public ApprovedSalaryDto payload { get; set; }
    }

    public class ApprovedTrainingNewCommandHandler : IRequestHandler<ApprovedTrainingNewCommand, Result>
    {
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
        private readonly AppSettings _appSettings;
        
        private readonly IStaffRequestRepository _staffRequestRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository;
        public ApprovedTrainingNewCommandHandler(IBaseRepository<Domain.Notification.Model.NotificationModel> basenotify,
                                                        IStaffRequestRepository staffRequestRepository,
                                                        IOptions<AppSettings> appSettings,
                                                        ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                        IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository
                                                        )
        {
            _baseNotification = basenotify;
            _appSettings = appSettings.Value;
            
            _staffRequestRepository = staffRequestRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.baseTypeStaffRequestRepository = baseTypeStaffRequestRepository;
        }
        public async Task<Result> Handle(ApprovedTrainingNewCommand request, CancellationToken cancellationToken)
        {
            var typeStaffRequest = await baseTypeStaffRequestRepository.Find(request.payload.idTypeStaffRequest);
            int totalLevel = await typeStaffRequestApproverRepository.GetTotalLevels(request.payload.idTypeStaffRequest);
            var requestStatusChecker = new RequestStatusChecker(totalLevel, request.payload.nlevel);
            requestStatusChecker.SetStateApproved();
            var approver = await typeStaffRequestApproverRepository.GetByLevel(request.payload.idTypeStaffRequest, request.payload.nlevel + 1);
            
            StaffRequestApprover staffRequestApprover = new StaffRequestApprover() { 
                Id = request.payload.nid_person,
                IdStaffRequest = request.payload.nid_request,
                Comment =   request.payload.comment
            };
            await typeStaffRequestApproverRepository.AproveLevelRequest(staffRequestApprover);
            
            if (approver != null)
            {
                var list = await _staffRequestRepository.GetPersonByCharger(approver.IdProfile);
                await _staffRequestRepository.ApprovedTrainingNew(request.payload, false);
                foreach (var item in list)
                {
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                    string fmt = File.ReadAllText(_appSettings.RegisterRequestSalary);

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
            }
            else
            {
                await _staffRequestRepository.ApprovedTrainingNew(request.payload, true);

                Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                string fmt = File.ReadAllText(_appSettings.AcepteRequestSalary);

                fmt = fmt.Replace("[URLEVALUATION]", _appSettings.URLEVALUACION);
                fmt = fmt.Replace("[SOLICITUD]", typeStaffRequest.Name);

                newNotification.IdArea = request.payload.nid_area;
                newNotification.IdPerson = request.payload.nid_person;
                newNotification.IdReceptor = request.payload.nid_receptor;
                newNotification.Subject = "Solicitud de " + typeStaffRequest.Name + " aceptada";
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
