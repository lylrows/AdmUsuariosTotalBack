using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Notification.Contracts;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Notification.Model;
using HumanManagement.Domain.Security.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Notification.Commands.Archive
{
    public class ArchiveNotificationCommand : IRequest<Result>
    {
        public BandejaNotificacionDto Notification { get; set; }
        public int IdUser { get; set; }
    }

    public class ArchiveNotificationCommandHandler : IRequestHandler<ArchiveNotificationCommand, Result>
    {
        private readonly IBaseRepository<NotificationModel> baseNotificationRepository;
        private readonly IBaseRepository<NotificationFavorite> baseNotificationFavorite;
        private readonly INotificationRepository notificationRepository;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        public ArchiveNotificationCommandHandler(IBaseRepository<NotificationModel> baseNotificationRepository,
                                                IMapper mapper, IBaseRepository<NotificationFavorite> baseNotificationFavorite,
                                                INotificationRepository notificationRepository,
                                                IUserRepository userRepository
                                                )
        {
            this.baseNotificationRepository = baseNotificationRepository;
            this.mapper = mapper;
            this.baseNotificationFavorite = baseNotificationFavorite;
            this.notificationRepository = notificationRepository;
            this.userRepository = userRepository;
        }
        public async Task<Result> Handle(ArchiveNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = mapper.Map<NotificationModel>(request.Notification);
            await baseNotificationRepository.UpdatePartialNotIncluding(notification, x => x.DateRegister,
                                                                                     x => x.IdUserRegister);

            var currentUser =  await userRepository.GetById(request.IdUser);

            var noti_bd = await notificationRepository.GetBydId(request.Notification.Id);

            var noti_favorite = await notificationRepository.GetNotiFavoriteModel(request.Notification.Id, currentUser.IdPerson);

            if (noti_favorite != null)
            {
                noti_favorite.Active = notification.Favorite;

                await baseNotificationFavorite.Update(noti_favorite);

            }
            else
            {
                if (notification.Favorite == true) {

                    Domain.Notification.Model.NotificationFavorite newNotiFavorite = new NotificationFavorite();
                    newNotiFavorite.Id = notification.Id;
                    newNotiFavorite.IdReceptor = currentUser.IdPerson;
                    newNotiFavorite.Active = true;

                    await baseNotificationFavorite.Add(newNotiFavorite);
                }


            }

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
