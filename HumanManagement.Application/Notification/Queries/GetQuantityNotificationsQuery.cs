using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.Notification.Contracts;
using HumanManagement.Domain.Security.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Notification.Queries
{
    public class GetQuantityNotificationsQuery : IRequest<Result>
    {
        public int IdUser { get; set; }

        public class GetQuantityNotificationsQueryHandler : IRequestHandler<GetQuantityNotificationsQuery, Result>
        {
            private readonly INotificationRepository notificationRepository;
            private readonly IAreaRepository areaRepository;
            private readonly IUserRepository userRepository;

            public GetQuantityNotificationsQueryHandler(INotificationRepository notificationRepository, IAreaRepository areaRepository, IUserRepository userRepository)
            {
                this.notificationRepository = notificationRepository;
                this.areaRepository = areaRepository;
                this.userRepository = userRepository;
            }


            public async Task<Result> Handle(GetQuantityNotificationsQuery request, CancellationToken cancellationToken)
            {
                var idarea = await areaRepository.GetByIdUser(request.IdUser);
                var currentUser = await userRepository.GetById(request.IdUser);

                var cantidad = await notificationRepository.GetQuantityNotifications(idarea, false, currentUser.IdPerson, request.IdUser);

                return new Result
                {
                    Data = cantidad,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }





    }
}
