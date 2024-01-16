using AutoMapper;
using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Notification.Model;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Notification.Commands.Create
{
    public class CreateNotificationApprovedCommand : IRequest<Result>
    {
        public NotificationDto Notification { get; set; }
    }

    public class CreateNotificationApprovedCommandHandler : IRequestHandler<CreateNotificationApprovedCommand, Result>
    {
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly IMapper mapper;
        private readonly SessionManager sessionManager;
        public CreateNotificationApprovedCommandHandler(IBaseRepository<NotificationModel> baseNotificationRepository,
                                                IMapper mapper,
                                                SessionManager sessionManager)
        {
            this.baseNotificationRepository = baseNotificationRepository;
            this.mapper = mapper;
            this.sessionManager = sessionManager;
        }
        public async Task<Result> Handle(CreateNotificationApprovedCommand request, CancellationToken cancellationToken)
        {
            var notification = mapper.Map<NotificationModel>(request.Notification);
            notification.SendDate = DateTime.Now;
            notification.IdPerson = sessionManager.User.IdPerson;
            notification.IsApprovedRRHH = request.Notification.IsApprovedRRHH; 
            await baseNotificationRepository.Add(notification);
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
