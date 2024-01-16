using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Notification.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Notification.Commands.Archive
{
    public class ArchiveListNotificationCommand : IRequest<Result>
    {
        public List<BandejaNotificacionDto> Notification { get; set; }
    }

    public class ArchiveListNotificationCommandHandler : IRequestHandler<ArchiveListNotificationCommand, Result>
    {
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly IMapper mapper;

        public ArchiveListNotificationCommandHandler(IBaseRepository<NotificationModel> baseNotificationRepository, IMapper mapper)
        {
            this.baseNotificationRepository = baseNotificationRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(ArchiveListNotificationCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Notification)
            {
                var notification = mapper.Map<NotificationModel>(item);
                notification.Active = false;
                notification.IdUserUpdate = 1;
                notification.DateUpdate = DateTime.Now;
                await baseNotificationRepository.UpdatePartialNotIncluding(notification, x => x.DateRegister,
                                                                                         x => x.IdUserRegister);
            }
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
