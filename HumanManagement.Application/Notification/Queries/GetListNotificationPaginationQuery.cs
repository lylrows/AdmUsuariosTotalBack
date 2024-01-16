using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Notification.Contracts;
using HumanManagement.Domain.Notification.QueryFilter;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Notification.Queries
{
    public class GetListNotificationPaginationQuery : IRequest<Result>
    {
        public NotificationQueryFilter notificationQueryFilter { get; set; }
        public class GetListNotificationPaginationQueryHandler : IRequestHandler<GetListNotificationPaginationQuery, Result>
        {
            private readonly INotificationRepository notificationRepository;
            public GetListNotificationPaginationQueryHandler(INotificationRepository notificationRepository)
            {
                this.notificationRepository = notificationRepository;
            }
            public async Task<Result> Handle(GetListNotificationPaginationQuery request, CancellationToken cancellationToken)
            {
                var list = await notificationRepository.GetListWithPagination(request.notificationQueryFilter);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = list
                };
            }
        }
    }
}
