
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Notification.Contracts;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Notification.Model;
using HumanManagement.Domain.Security.Contracts;
using MediatR;

using System.Collections.Generic;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Notification.Commands.Update
{
  

    public class AddViewedNotificationCommand : IRequest<Result>
    {
        public BandejaNotificacionDto Notification { get; set; }
        public int IdUser { get; set; }
    }

    public class AddViewedNotificationCommandHandler : IRequestHandler<AddViewedNotificationCommand, Result>
    {
        
        
        private readonly IBaseRepository<NotificationViewed> baseNotificationViewed;
        private readonly INotificationRepository notificationRepository;
  
        private readonly IUserRepository userRepository;
        private readonly IAreaRepository areaRepository;
        public AddViewedNotificationCommandHandler(
                                        
                                                
                                                INotificationRepository notificationRepository,
                                                IUserRepository userRepository,
                                                IBaseRepository<NotificationViewed> baseNotificationViewed,
                                                IAreaRepository areaRepository
                                                )
        {
            
            this.notificationRepository = notificationRepository;
            this.userRepository = userRepository;
            this.baseNotificationViewed = baseNotificationViewed;
            this.areaRepository = areaRepository;
        }
        public async Task<Result> Handle(AddViewedNotificationCommand request, CancellationToken cancellationToken)
        {

            var idarea = await areaRepository.GetByIdUser(request.IdUser);

            var currentUser = await userRepository.GetById(request.IdUser);

            var noti_viewed = await notificationRepository.GetNotiViewedModel(request.Notification.Id, currentUser.IdPerson);

            if (noti_viewed == null)
            {
                NotificationViewed newNotiViewedBD= new NotificationViewed();
                newNotiViewedBD.Id = request.Notification.Id;
                newNotiViewedBD.IdReceptor = currentUser.IdPerson;
                newNotiViewedBD.Active = true;

                await baseNotificationViewed.Add(newNotiViewedBD);

            }
            
            var bandeja = await notificationRepository.GetBandejaNotificacion(idarea, false, currentUser.IdPerson,currentUser.IdProfile);

            List<BandejaNotificacionDto> listaFiltrada = new List<BandejaNotificacionDto>();

            foreach (var item in bandeja)
            {
                if (item.IdUserReceptor != null)
                {
                    if (item.IdUserReceptor == request.IdUser)
                    {
                        listaFiltrada.Add(item);
                    }
                }
                else
                {
                    listaFiltrada.Add(item);
                }
            }



            bandeja = listaFiltrada.Select(item => {
                item.Viewed = item.Viewed;
                return item;
            }).ToList();


            int ncountNotViewed =  bandeja.Where(i => i.Viewed == false).Count();

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = new
                {
                    NoViewedMessages = ncountNotViewed
                }
                
            };
        }
    }
}
