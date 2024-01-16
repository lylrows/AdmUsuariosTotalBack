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

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class RegisterStaffRequestAdvancementCommand : IRequest<Result>
    {
        public StaffRequestAdvancementDto payload { get; set; }
    }

    public class RegisterStaffRequestAdvancementCommandHandler : IRequestHandler<RegisterStaffRequestAdvancementCommand, Result>
    {
        private readonly IBaseRepository<StaffRequestModel> _baseStaffRequestRepository;
        private readonly IBaseRepository<StaffRequestAdvancement> _baseStaffRequestAdvancementRepository;
        private readonly IMapper mapper;
        private readonly SessionManager sessionManager;
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitWork;
        private readonly IStaffRequestRepository _staffRequestRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        private readonly IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository;

        public RegisterStaffRequestAdvancementCommandHandler(IBaseRepository<StaffRequestModel> baseStaffRequestRepository, IBaseRepository<StaffRequestAdvancement> baseRepository,
                                                        IBaseRepository<Domain.Notification.Model.NotificationModel> basenotify,
                                                        IStaffRequestRepository staffRequestRepository,
                                                        ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                        IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository,
                                                        IMapper mapper,
                                                        IOptions<AppSettings> appSettings,
                                                        IUnitOfWork unitWork,
                                                        SessionManager sessionManager)
        {
            _baseNotification = basenotify;
            _baseStaffRequestRepository = baseStaffRequestRepository;
            _baseStaffRequestAdvancementRepository = baseRepository;
            this.mapper = mapper; 
            this.sessionManager = sessionManager;
            _appSettings = appSettings.Value;
            _unitWork = unitWork;
            _staffRequestRepository = staffRequestRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
            this.baseTypeStaffRequestRepository = baseTypeStaffRequestRepository;
        }
        public async Task<Result> Handle(RegisterStaffRequestAdvancementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.payload.StaffRequest.StaffRequestEmployee.SetDateAdmissionToDate();
                var staffRequest = mapper.Map<StaffRequestModel>(request.payload.StaffRequest);
                staffRequest.SetStatePending();
                await _baseStaffRequestRepository.Add(staffRequest);
                var typeStaffRequest = await baseTypeStaffRequestRepository.Find(staffRequest.IdTypeStaffRequest);
                var staffRequestAdvancement = new StaffRequestAdvancement();
                staffRequestAdvancement.SetIdStaffRequest(staffRequest.Id);
                staffRequestAdvancement.nid_collaborator = request.payload.nid_collaborator;
                staffRequestAdvancement.namount = request.payload.namount;
                staffRequestAdvancement.nreason = request.payload.nreason;
                staffRequestAdvancement.sdetailreason = request.payload.sdetailreason;
                staffRequestAdvancement.dateapproval = DateTime.Now;
                staffRequestAdvancement.nstate = 1;
                staffRequestAdvancement.dateapproval = DateTime.Now;
                staffRequestAdvancement.dregister = DateTime.Now;
                staffRequestAdvancement.nuserregister = 1;
                await _baseStaffRequestAdvancementRepository.Add(staffRequestAdvancement);

                var approver = await typeStaffRequestApproverRepository.GetByLevel(staffRequest.IdTypeStaffRequest, 1);
                await typeStaffRequestApproverRepository.InsertLevelRequest(staffRequest);
                var list = new List<ListIdPersonByChargerDto>();
                if (approver.IdProfile == 8)//Si es Jefe
                {
                    var lista = await _staffRequestRepository.GetListReceptorForNotificationBoss(approver.IdProfile, 0, staffRequest.IdEmployee);
                    foreach (var _item in lista)
                    {
                        var _obj = new ListIdPersonByChargerDto();
                        _obj.sfullname = _item.EvaluatorFullName;
                        _obj.nid_area = _item.IdArea;
                        _obj.nid_person = _item.IdReceptor;
                        list.Add(_obj);
                    }                    
                } else//Si es otro Perfil
                {
                    list = await _staffRequestRepository.GetPersonByCharger(approver.IdProfile);
                }

                foreach (var item in list)
                {
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                    string fmt = File.ReadAllText(_appSettings.RegisterRequestAdvacement);

                    //fmt = fmt.Replace("[URLEVALUATION]", _appSettings.URLEVALUACION);
                    fmt = fmt.Replace("[URLEVALUATION]", _appSettings.URLEVALUACION+ "?id=" + staffRequest.Id.ToString());
                    fmt = fmt.Replace("[NAME]", item.sfullname);
                    fmt = fmt.Replace("[USERNAME]", request.payload.names + ' ' + request.payload.lastName + ' ' + request.payload.motherLastName);
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
