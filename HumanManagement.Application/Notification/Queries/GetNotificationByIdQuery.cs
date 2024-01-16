using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Notification.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Notification.Queries
{
    public class GetNotificationByIdQuery : IRequest<Result>
    {
        public int IdNotification { get; set; }
        public class GetNotificationByIdQueryHandler : IRequestHandler<GetNotificationByIdQuery, Result>
        {
            private readonly INotificationRepository notificationRepository;
            public GetNotificationByIdQueryHandler(INotificationRepository notificationRepository)
            {
                this.notificationRepository = notificationRepository;
            }
            public async Task<Result> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
            {
                var notification = await notificationRepository.GetBydId(request.IdNotification);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = notification
                };
            }
        }
    }
}
