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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class CreateStaffRequestSalaryCommand : IRequest<Result>
    {
        public RegisterRequestSalary payload { get; set; }
        public IFormFile file { get; set; }
        public IFormFile fileFicha { get; set; }
    }

    public class CreateStaffRequestSalaryCommandHandler : IRequestHandler<CreateStaffRequestSalaryCommand, Result>
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

        public CreateStaffRequestSalaryCommandHandler(IBaseRepository<StaffRequestModel> baseStaffRequestRepository,
                                                        IBaseRepository<Domain.Notification.Model.NotificationModel> basenotify,
                                                        IStaffRequestRepository staffRequestRepository,
                                                        IMapper mapper,
                                                        IOptions<AppSettings> appSettings,
                                                        ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository,
                                                        IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository,
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
        public async Task<Result> Handle(CreateStaffRequestSalaryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.payload.StaffRequest.StaffRequestEmployee.SetDateAdmissionToDate();
                var staffRequest = mapper.Map<StaffRequestModel>(request.payload.StaffRequest);
                staffRequest.SetStatePending();
                await _baseStaffRequestRepository.Add(staffRequest);
                request.payload.nid_request = staffRequest.Id;
                await _staffRequestRepository.RegisterRequestSalary(request.payload, request.file, request.fileFicha);
                var approver = await typeStaffRequestApproverRepository.GetByLevel(staffRequest.IdTypeStaffRequest, 1);
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
                }
                else//Si es otro Perfil
                {
                    list = await _staffRequestRepository.GetPersonByCharger(approver.IdProfile);
                }
                var typeStaffRequest = await baseTypeStaffRequestRepository.Find(staffRequest.IdTypeStaffRequest);
                await typeStaffRequestApproverRepository.InsertLevelRequest(staffRequest);

                foreach (var item in list)
                {
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                    string fmt = File.ReadAllText(_appSettings.RegisterRequestSalary);

                    //fmt = fmt.Replace("[URLEVALUATION]", _appSettings.URLEVALUACION);
                    fmt = fmt.Replace("[URLEVALUATION]", _appSettings.URLEVALUACION+"?id="+ staffRequest.Id.ToString());
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
