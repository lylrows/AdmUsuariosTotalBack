using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Notification.Model;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.PostJobOffer.Commands.Create
{
    public class CreateJobOfferInternalCommand: IRequest<Result>
    {
        public JobOfferInternalDto dto { get; set; }
    }

    public class CreateJobOfferInternalCommandHandle : IRequestHandler<CreateJobOfferInternalCommand, Result>
    {
        private readonly IBaseRepository<JobOffersInternal> baseJobRepository;
        private readonly IBaseRepository<NotificationModel> _baseNotification;
        private readonly IMapper mapper;
        private readonly AppSettings _appSettings;

        public CreateJobOfferInternalCommandHandle(IBaseRepository<JobOffersInternal> baseJobRepository, 
                                                   IMapper mapper, 
                                                   IOptions<AppSettings> appSettings,
                                                   IBaseRepository<NotificationModel> _baseNotification)
        {
            this.baseJobRepository = baseJobRepository;
            this._baseNotification = _baseNotification;
            this.mapper = mapper;
            this._appSettings = appSettings.Value;
        }
        public async Task<Result> Handle(CreateJobOfferInternalCommand request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<JobOffersInternal>(request.dto);

            if (model.Id_Job == 0)
            {
                await baseJobRepository.Add(model);

                var newNotification = new NotificationModel();
                string template = await File.ReadAllTextAsync(_appSettings.NewVacantTemplateHtml);
                template = template.Replace("[POSITION]", model.Title);
                template = template.Replace("[URL]", _appSettings.UrlJobOfferDetail + "/" + model.Id_Job);

                newNotification.IdArea = 0;
                newNotification.IdPerson = _appSettings.IdPersonRRHH;
                newNotification.IdReceptor = 0;
                newNotification.Subject = "Nueva vacante de trabajo publicada.";
                newNotification.Body = template;
                newNotification.SendDate = DateTime.Now;
                newNotification.Active = true;

                newNotification.Important = true;
                newNotification.Favorite = true;

                await _baseNotification.Add(newNotification);
            } else
            {
                await baseJobRepository.Update(model);
            }


            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                LastId = model.Id_Job,
                Data = model
            };
        }
    }
}
