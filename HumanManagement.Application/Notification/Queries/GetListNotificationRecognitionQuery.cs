using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
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
    public class GetListNotificationRecognitionQuery : IRequest<Result>
    {
        public int IdUser { get; set; }
        public class GetBandejaNotificationRecognitionQueryHandler : IRequestHandler<GetListNotificationRecognitionQuery, Result>
        {
            private readonly INotificationRepository notificationRepository;

            public GetBandejaNotificationRecognitionQueryHandler(INotificationRepository notificationRepository)
            {
                this.notificationRepository = notificationRepository;
            }
            public async Task<Result> Handle(GetListNotificationRecognitionQuery request, CancellationToken cancellationToken)
            {
                var bandeja = await notificationRepository.GetBandejaNotificacionRecognition(request.IdUser);
                bandeja = bandeja.Select(item => {
                    item.Message = item.Message;
                    item.Selected = item.Selected;
                    item.SendDate = item.SendDate;
                    item.Sender = item.Sender;
                    item.Subject = item.Subject;
                    item.SenderPhoto = GetAvatar(item.SenderPhoto);
                    return item;
                }).ToList();
                return new Result
                {
                    Data = bandeja,
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
        }
    }
}
