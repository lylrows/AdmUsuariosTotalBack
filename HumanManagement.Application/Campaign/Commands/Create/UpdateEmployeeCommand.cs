using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Campaign.Dto;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Evaluation.Contracts;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Commands.Create
{
    public class UpdateEmployeeCommand : IRequest<Result>
    {
        public DeleteEmployee evaluationQueryFilter { get; set; }
        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result>
        {
            private readonly IEvaluationRepository _campaignRepository;
            private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
            private readonly AppSettings _appSettings;
            private readonly IUnitOfWork _unitWork;
            public UpdateEmployeeCommandHandler(IEvaluationRepository campaignRepository,
                IBaseRepository<Domain.Notification.Model.NotificationModel> basenotify,
                                                        IOptions<AppSettings> appSettings,
                                                        IUnitOfWork unitWork)
            {
                this._campaignRepository = campaignRepository;
                _baseNotification = basenotify;
                _appSettings = appSettings.Value;
                _unitWork = unitWork;
            }


            public async Task<Result> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                 await _campaignRepository.DeleteEmployeeByCampaign(request.evaluationQueryFilter.IdEvaluation, request.evaluationQueryFilter.comment, request.evaluationQueryFilter.EmpleadoId);

                Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                string fmt = File.ReadAllText(_appSettings.DeleteEmployeeByCampaign);

                fmt = fmt.Replace("[NAME]", request.evaluationQueryFilter.Name);
                fmt = fmt.Replace("[CAMPAIGN]", request.evaluationQueryFilter.Campaign);
                fmt = fmt.Replace("[COMMENT]", request.evaluationQueryFilter.comment);

                newNotification.IdArea = request.evaluationQueryFilter.AreaId;
                newNotification.IdPerson = request.evaluationQueryFilter.EmisorId;
                newNotification.IdReceptor = request.evaluationQueryFilter.ReceptorId;
                newNotification.Subject = "CAMPAÑA " + request.evaluationQueryFilter.Campaign;
                newNotification.Body = fmt;
                newNotification.SendDate = DateTime.Now;
                newNotification.Active = true;

                newNotification.Important = true;
                newNotification.Favorite = true;

                await _baseNotification.Add(newNotification);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = "Empleado Eliminado correctamente"
                };
            }
        }
    }
}
