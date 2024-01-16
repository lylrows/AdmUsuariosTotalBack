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
    public class RejectStaffBurialCommand : IRequest<Result>
    {
        public RejectSalaryDto payload { get; set; }
    }

    public class RejectStaffBurialCommandHandler : IRequestHandler<RejectStaffBurialCommand, Result>
    {
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitWork;
        private readonly IStaffRequestRepository _staffRequestRepository;
        private readonly IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository;
        public RejectStaffBurialCommandHandler(IBaseRepository<Domain.Notification.Model.NotificationModel> basenotify,
                                                        IStaffRequestRepository staffRequestRepository,
                                                        IOptions<AppSettings> appSettings,
                                                        IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository,
                                                        IUnitOfWork unitWork)
        {
            _baseNotification = basenotify;
            _appSettings = appSettings.Value;
            _unitWork = unitWork;
            _staffRequestRepository = staffRequestRepository;
            this.baseTypeStaffRequestRepository = baseTypeStaffRequestRepository;
        }
        public async Task<Result> Handle(RejectStaffBurialCommand request, CancellationToken cancellationToken)
        {
            var typeStaffRequest = await baseTypeStaffRequestRepository.Find(request.payload.idTypeStaffRequest);
            await _staffRequestRepository.RejectBurial(request.payload);

            Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

            string fmt = File.ReadAllText(_appSettings.RejectRequestBurial);
            fmt = fmt.Replace("[SOLICITUD]", typeStaffRequest.Name);

            newNotification.IdArea = request.payload.nid_area;
            newNotification.IdPerson = request.payload.nid_person;
            newNotification.IdReceptor = request.payload.nid_receptor;
            newNotification.Subject = "Solicitud de " + typeStaffRequest.Name + " rechazada";
            newNotification.Body = fmt;
            newNotification.SendDate = DateTime.Now;
            newNotification.Active = true;

            newNotification.Important = true;
            newNotification.Favorite = true;

            await _baseNotification.Add(newNotification);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
