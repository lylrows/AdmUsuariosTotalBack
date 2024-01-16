using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.Notification.Contracts;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Security.Contracts;
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
    
    public class GetBandejaNotificationFilterQuery : IRequest<Result>
    {
        
        public BandejaFilterDto filter { get; set; }
        public class GetBandejaNotificationFilterQueryHandler : IRequestHandler<GetBandejaNotificationFilterQuery, Result>
        {
            private readonly INotificationRepository notificationRepository;
            private readonly IAreaRepository areaRepository;
            private readonly IUserRepository userRepository;
            public GetBandejaNotificationFilterQueryHandler(INotificationRepository notificationRepository, IAreaRepository areaRepository,
                IUserRepository userRepository)
            {
                this.notificationRepository = notificationRepository;
                this.areaRepository = areaRepository;
                this.userRepository = userRepository;
            }
            public async Task<Result> Handle(GetBandejaNotificationFilterQuery request, CancellationToken cancellationToken)
            {
                var idarea = await areaRepository.GetByIdUser(request.filter.niduser);
                var currentUser = await userRepository.GetById(request.filter.niduser);

                request.filter.sstartdate = DateTime.Parse(request.filter.sstartdate).ToShortDateString();
                request.filter.senddate = DateTime.Parse(request.filter.senddate).ToShortDateString();

                var bandeja = await notificationRepository.GetBandejaNotificacionFilter(idarea, false, currentUser.IdPerson,request.filter);

                List<BandejaNotificacionDto> listaFiltrada = new List<BandejaNotificacionDto>();

                foreach (var item in bandeja)
                {
                    if (item.IdUserReceptor != null)
                    {
                        if (item.IdUserReceptor == request.filter.niduser)
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
                    item.Message = item.Message;
                    item.Selected = item.Selected;
                    item.SendDate = item.SendDate;
                    item.Sender = item.Sender;
                    item.Subject = item.Subject;
                    item.SenderPhoto = GetAvatar(item.SenderPhoto);
                    item.IdArea = item.IdArea;
                    item.IdPerson = item.IdPerson;
                    item.Important = item.Important;
                    item.Favorite = item.Favorite;
                    item.Active = item.Active;
                    item.RelativeSendDate = RelativeTime(item.SendDate);
                    item.Viewed = item.Viewed;
                    return item;
                }).ToList();
                return new Result
                {
                    Data = bandeja.OrderByDescending(x => x.SendDate),
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
