using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Notification.Model;
using HumanManagement.Domain.StaffRequest.Dto;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class NotificationCreator
    {
        private string pathFileHtml;
        private string bodyText;
        private int idPersonGenerate;
        private string typeStaffRequest;
        private int typeNotification;
        private string urlStaffRequest;
        private List<NotificationReceptorDto> notificationReceptorList;
        public List<NotificationModel> Notificationlist { get; private set; }
        private readonly IHubContext<Notifications> _hubContext;

        public NotificationCreator(int idPersonGenerate, 
                                    string pathFileHtml,
                                    string urlStaffRequest,
                                    string typeStaffRequest,
                                    List<NotificationReceptorDto> notificationReceptorList,
                                    IHubContext<Notifications> hubContext)
        {
            this.idPersonGenerate = idPersonGenerate;
            this.pathFileHtml = pathFileHtml;
            this.urlStaffRequest = urlStaffRequest;
            this.typeStaffRequest = typeStaffRequest;
            this.notificationReceptorList = notificationReceptorList;
            Notificationlist = new List<NotificationModel>();
            _hubContext = hubContext;
        }

        public async Task GenerateNotification(int typeNotification)
        {
            this.typeNotification = typeNotification;
            ReadHtml();
            FillNotificationList();
            string notification = Newtonsoft.Json.JsonConvert.SerializeObject(typeNotification);
            await this._hubContext.Clients.All.SendAsync("enviar-todos", notification);
        }

        private void ReadHtml()
        {
            bodyText = File.ReadAllText(pathFileHtml);
        }
        private void FillNotificationList()
        {
            foreach (var item in notificationReceptorList)
            {
                var notification = new NotificationModel
                {
                    IdArea = item.IdArea,
                    IdPerson = idPersonGenerate,
                    IdReceptor = item.IdReceptor,
                    Subject = $"Solicitud de {typeStaffRequest}",
                    Body = GetBody(item),
                    SendDate = DateTime.Now,
                    Active = true,
                    Important = true,
                    Favorite = true
                };
                Notificationlist.Add(notification);
            }
        }

        private string GetBody(NotificationReceptorDto item)
        {
            string body = string.Empty;
            switch (typeNotification)
            {
                case 1:
                    body = GetBodyRegister(item);
                    break;
                case 2:
                    body = GetBodyAcceptOrReject(item);
                    break;
            }

            return body;
        }

        private string GetBodyRegister(NotificationReceptorDto notificationReceptorDto)
        {
            string bodyNotification = bodyText;
            bodyNotification = bodyNotification.Replace("[TYPESTAFFREQUEST]", typeStaffRequest);
            bodyNotification = bodyNotification.Replace("[EVALUATORNAME]", notificationReceptorDto.EvaluatorFullName);
            bodyNotification = bodyNotification.Replace("[USERNAME]", notificationReceptorDto.EmplyeeFullName);
            bodyNotification = bodyNotification.Replace("[DNI]", notificationReceptorDto.EmplyeeDni);
            bodyNotification = bodyNotification.Replace("[ROLNAME]", notificationReceptorDto.RolName);
            bodyNotification = bodyNotification.Replace("[URLEVALUATION]", urlStaffRequest+"?id="+ notificationReceptorDto.IdStaffRequest.ToString());

            return bodyNotification;
        }
        private string GetBodyAcceptOrReject(NotificationReceptorDto notificationReceptorDto)
        {
            string bodyNotification = bodyText;
            bodyNotification = bodyNotification.Replace("[TYPESTAFFREQUEST]", typeStaffRequest);
            bodyNotification = bodyNotification.Replace("[URLEVALUATION]", urlStaffRequest + "?id=" + notificationReceptorDto.IdStaffRequest.ToString());

            return bodyNotification;
        }
    }
}
