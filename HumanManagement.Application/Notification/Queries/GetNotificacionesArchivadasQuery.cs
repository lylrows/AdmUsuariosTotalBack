using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.Notification.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Notification.Queries
{
    public class GetNotificacionesArchivadasQuery : IRequest<Result>
    {
        public int IdUser { get; set; }
        public class GetNotificacionesArchivadasQueryHandler : IRequestHandler<GetNotificacionesArchivadasQuery, Result>
        {
            private readonly INotificationRepository notificationRepository;
            private readonly IAreaRepository areaRepository;
            public GetNotificacionesArchivadasQueryHandler(INotificationRepository notificationRepository, IAreaRepository areaRepository)
            {
                this.notificationRepository = notificationRepository;
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetNotificacionesArchivadasQuery request, CancellationToken cancellationToken)
            {
                var idArea = await areaRepository.GetByIdUser(request.IdUser);
                var bandeja = await notificationRepository.GetBandejaArchivados(idArea);
                var recognition = await notificationRepository.GetBandejaNotificacionRecognitionArchived(request.IdUser);
                var notificaciones =  bandeja.Concat(recognition).ToList();
                notificaciones = notificaciones.Select(item => {
                    item.Message = item.Message;
                    item.Selected = item.Selected;
                    item.SendDate = item.SendDate;
                    item.Sender = item.Sender;
                    item.Subject = item.Subject;
                    item.SenderPhoto = GetAvatar(item.SenderPhoto);
                    item.IdArea = item.IdArea;
                    item.IdPerson = item.IdPerson;
                    item.RelativeSendDate = RelativeTime(item.SendDate);
                    item.Favorite = item.Favorite;
                    return item;
                }).ToList();
                return new Result
                {
                    Data = notificaciones.OrderByDescending(x => x.SendDate),
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }

            public string GetAvatar(string url)
            {
                if (url != "" && url != null)
                {
                    var fileAvatar = url;
                    var base64ImageRepresentation = "";
                    if (File.Exists(fileAvatar))
                    {
                        var imageArray = File.ReadAllBytes(fileAvatar);
                        base64ImageRepresentation = $"data:image/jpeg;base64,{Convert.ToBase64String(imageArray)}";
                    }

                    return base64ImageRepresentation;
                }
                else
                {
                    return "../../../../../assets/images/avatars/avatar.jpg";
                }
            }

            private string RelativeTime(DateTime date)
            {

                const int SECOND = 1;
                const int MINUTE = 60 * SECOND;
                const int HOUR = 60 * MINUTE;
                const int DAY = 24 * HOUR;
                const int MONTH = 30 * DAY;

                var ts = new TimeSpan(DateTime.Now.Ticks - date.Ticks);
                double delta = Math.Abs(ts.TotalSeconds);

                if (delta < 1 * MINUTE)
                    return ts.Seconds == 1 ? "hace un segundo" : "Hace " + ts.Seconds + " segundos";

                if (delta < 2 * MINUTE)
                    return "hace un minuto";

                if (delta < 45 * MINUTE)
                    return "hace " + ts.Minutes + " minutos";

                if (delta < 90 * MINUTE)
                    return "hace una hora";

                if (delta < 24 * HOUR)
                    return "hace " + ts.Hours + " horas";

                if (delta < 48 * HOUR)
                    return "ayer";

                if (delta < 30 * DAY)
                    return "hace " + ts.Days + " días";

                if (delta < 12 * MONTH)
                {
                    int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                    return months <= 1 ? "hace un mes" : "hace " + months + " meses";
                }
                else
                {
                    int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                    return years <= 1 ? "hace un año" : "hace " + years + " años";
                }
            }
        }
    }
}
