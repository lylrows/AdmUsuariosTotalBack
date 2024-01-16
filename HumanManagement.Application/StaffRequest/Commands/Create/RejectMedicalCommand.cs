using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
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
    public class RejectMedicalCommand : IRequest<Result>
    {
        public RejectMedicalDto payload { get; set; }
    }
    public class RejectMedicalCommandHandler : IRequestHandler<RejectMedicalCommand, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitWork;

        public RejectMedicalCommandHandler(IRequestMedicalRepository requestMedicalRepository,
                                         IBaseRepository<Domain.Notification.Model.NotificationModel> basenotify,
                                            IOptions<AppSettings> appSettings,
                                            IUnitOfWork unitWork)
        {
            this._requestMedicalRepository = requestMedicalRepository;
            _baseNotification = basenotify;
            _appSettings = appSettings.Value;
            _unitWork = unitWork;
        }
        public async Task<Result> Handle(RejectMedicalCommand request, CancellationToken cancellationToken)
        {
            await _requestMedicalRepository.RejectedMedical(request.payload);

            Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

            string fmt = File.ReadAllText(_appSettings.RejectMedical);

            fmt = fmt.Replace("[URLEVALUATION]", "http://localhost:4200/#/humanmanagement/request-medical-config/" + request.payload.nid_medical);
            fmt = fmt.Replace("[NAME]", request.payload.sfullname);

            newNotification.IdArea = request.payload.idArea;
            newNotification.IdPerson = request.payload.emisorId;
            newNotification.IdReceptor = request.payload.receptorId;
            newNotification.Subject = "Solicitud de Descanso medico o Subsidio Rechazada";
            newNotification.Body = fmt;
            newNotification.SendDate = DateTime.Now;
            newNotification.Active = true;

            newNotification.Important = true;
            newNotification.Favorite = true;

            await _baseNotification.Add(newNotification);

           

            
            await _unitWork.Commit();
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
