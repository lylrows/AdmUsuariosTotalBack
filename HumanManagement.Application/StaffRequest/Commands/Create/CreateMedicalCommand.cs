using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
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
    public class CreateMedicalCommand : IRequest<Result>
    {
        public RegisterMedicalDto payload { get; set; }
    }
    public class CreateMedicalCommandHandler : IRequestHandler<CreateMedicalCommand, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitWork;

        public CreateMedicalCommandHandler(IRequestMedicalRepository requestMedicalRepository,
                                            IBaseRepository<Domain.Notification.Model.NotificationModel> basenotify,
                                            IOptions<AppSettings> appSettings,
                                            IUnitOfWork unitWork)
        {
            this._requestMedicalRepository = requestMedicalRepository;
            _baseNotification = basenotify;
            _appSettings = appSettings.Value;
            _unitWork = unitWork;
        }
        public async Task<Result> Handle(CreateMedicalCommand request, CancellationToken cancellationToken)
        {

            var resultValidation = await _requestMedicalRepository.ValidateRegisterMedical(request.payload);
            if(!String.IsNullOrEmpty(resultValidation))
            {
                return new Result
                {
                    StateCode = Constants.StateCodeResult.VALIDATION,
                    Data = resultValidation
                };
            }
            var result = await _requestMedicalRepository.RegisterMedical(request.payload);
            if (request.payload.bisDraft == false)
            {
                var list = await _requestMedicalRepository.ListMedicalNotification();

                foreach (var item in list)
                {
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                    string fmt = File.ReadAllText(_appSettings.RegisterRequestBurial);

                    fmt = fmt.Replace("[URLEVALUATION]", "http://localhost:4200/#/humanmanagement/request-medical-config/" + result);

                    fmt = fmt.Replace("[NAME]", item.sfullname);
                    fmt = fmt.Replace("[USERNAME]", request.payload.names + ' ' + request.payload.lastName + ' ' + request.payload.motherLastName);
                    fmt = fmt.Replace("[DNI]", request.payload.dni);
                    fmt = fmt.Replace("[ROLNAME]", request.payload.charge);
                    fmt = fmt.Replace("[SOLICITUD]", "Descanso medico o Subsidio");

                    newNotification.IdArea = item.nid_area;
                    newNotification.IdPerson = request.payload.nid_person;
                    newNotification.IdReceptor = item.nid_person;
                    newNotification.Subject = "Solicitud de " + "Descanso medico o Subsidio";
                    newNotification.Body = fmt;
                    newNotification.SendDate = DateTime.Now;
                    newNotification.Active = true;

                    newNotification.Important = true;
                    newNotification.Favorite = true;

                    await _baseNotification.Add(newNotification);
                }
            }
            
            await _unitWork.Commit();
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = result
            };
        }
    }
}
