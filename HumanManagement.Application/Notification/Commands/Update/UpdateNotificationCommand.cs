using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Notification.Model;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Notification.Commands.Update
{
    public class UpdateNotificationCommand : IRequest<Result>
    {
        public NotificationDto Notification { get; set; }
    }
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, Result>
    {
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly IMapper mapper;
        public UpdateNotificationCommandHandler(IBaseRepository<NotificationModel> baseNotificationRepository,
                                                IMapper mapper)
        {
            this.baseNotificationRepository = baseNotificationRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = mapper.Map<NotificationModel>(request.Notification);
            
            await baseNotificationRepository.UpdatePartialNotIncluding(notification, x => x.SendDate,
                                                                                      x=>x.IdPerson,
                                                                                      x=> x.DateRegister,
                                                                                     x => x.IdUserRegister);
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
