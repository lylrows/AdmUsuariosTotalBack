using System.Collections.Generic;
using System.Threading.Tasks;
using HumanManagement.Application.Notification.Commands.Archive;
using HumanManagement.Application.Notification.Commands.Create;
using HumanManagement.Application.Notification.Commands.Update;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Application.Notification.Queries;
using HumanManagement.Domain.Notification.QueryFilter;
using Microsoft.AspNetCore.Mvc;
using HumanManagement.Application.Helpers;
using Microsoft.AspNetCore.SignalR;
using HumanManagement.Application.Utils.Queries;
using Microsoft.AspNetCore.Authorization;

namespace HumanManagementApi.Controllers.Notification
{
    public class NotificationController : BaseApiController
    {
        protected readonly SessionManager sessionManager;

        public NotificationController(SessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }


        [HttpGet("getBandeja/{idUser}")]
        public async Task<IActionResult> GetBandeja(int idUser)
        {
            var bandeja = await mediator.Send(new GetBandejaNotificationQuery() { IdUser = idUser});
            return bandeja.Data == null ? NotFound() : (IActionResult)Ok(bandeja);
        }

        [HttpGet("getQuantityNotifications/{idUser}")]
        public async Task<IActionResult> GetQuantityNotifications(int idUser)
        {
            var bandeja = await mediator.Send(new GetQuantityNotificationsQuery() { IdUser = idUser });
            return bandeja.Data == null ? NotFound() : (IActionResult)Ok(bandeja);
        }

        [HttpPost("getbandejafilter")]
        public async Task<IActionResult> GetBandejaFilter(BandejaFilterDto dto)
        {
              var bandeja = await mediator.Send(new GetBandejaNotificationFilterQuery() {  filter= dto });
              return bandeja.Data == null ? NotFound() : (IActionResult)Ok(bandeja);
        }

        


        [HttpGet("getBandejaFavorite/{idUser}")]
        public async Task<IActionResult> GetBandejaFavorite(int idUser)
        {
            var bandeja = await mediator.Send(new GetBandejaNotificationFavoriteQuery() { IdUser = idUser });
            return bandeja.Data == null ? NotFound() : (IActionResult)Ok(bandeja);
        }

        [HttpGet("getArchived/{idUser}")]
        public async Task<IActionResult> GetArchived(int idUser)
        {
            var bandeja = await mediator.Send(new GetNotificacionesArchivadasQuery() { IdUser = idUser});
            return bandeja.Data == null ? NotFound() : (IActionResult)Ok(bandeja);
        }

        [HttpGet("getRecognition/{idUser}")]
        public async Task<IActionResult> GetRecognition(int idUser)
        {
            var bandeja = await mediator.Send(new GetListNotificationRecognitionQuery() { IdUser = idUser});
            return bandeja.Data == null ? NotFound() : (IActionResult)Ok(bandeja);
        }

        [HttpPost("add")]
        public async Task<IActionResult> add(NotificationDto notificationDto)
        {
            var result = await mediator.Send(new CreateNotificationCommand() { Notification = notificationDto });
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userDto = await mediator.Send(new GetNotificationByIdQuery() { IdNotification = id });

            return Ok(userDto);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> edit(NotificationDto notificationDto)
        {
            var result = await mediator.Send(new UpdateNotificationCommand() { Notification = notificationDto });

            return Ok(result);
        }

        [HttpPost("archive")]
        public async Task<IActionResult> archive(BandejaNotificacionDto notificationDto)
        {
            int nIdUser = sessionManager.User == null ? 1 : sessionManager.User.IdUser;

            var result = await mediator.Send(new ArchiveNotificationCommand() { Notification = notificationDto ,IdUser= nIdUser });

            return Ok(result);
        }

        [HttpPost("archivelist")]
        public async Task<IActionResult> archiveList(List<BandejaNotificacionDto> notificationDto)
        {
            var result = await mediator.Send(new ArchiveListNotificationCommand() { Notification = notificationDto });

            return Ok(result);
        }

        [HttpPost("unarchivelist")]
        public async Task<IActionResult> unarchiveList(List<BandejaNotificacionDto> notificationDto)
        {
            var result = await mediator.Send(new UnArchiveNotificationCommand() { Notification = notificationDto });

            return Ok(result);
        }

        [HttpPost("getlistpagination")]
        public async Task<IActionResult> GetListPagination(NotificationQueryFilter notificationQueryFilter)
        {
            var listNotification = await mediator.Send(new GetListNotificationPaginationQuery() { notificationQueryFilter = notificationQueryFilter });

            return Ok(listNotification);
        }

        [HttpPost("addviewed")]
        public async Task<IActionResult> addviewed(BandejaNotificacionDto notificationDto)
        {
            int nIdUser = sessionManager.User == null ? 1 : sessionManager.User.IdUser;

            var result = await mediator.Send(new AddViewedNotificationCommand() { Notification = notificationDto, IdUser = nIdUser });

            return Ok(result);
        }

        [HttpPost("addnotificationapproved")] 
        public async Task<IActionResult> addNotificationApproved([FromBody] NotificationDto notificationDto)
        {
            var result = await mediator.Send(new CreateSendNotificationSolicitudApprovedCommand() { Notification = notificationDto });
            return Ok(result);
        }

        [HttpPost("addnotificationnoteselected")]
        public async Task<IActionResult> addNotificationNotSselected([FromBody] SendNotificationNotSeltectedDto notificationDto)
        {
            var result = await mediator.Send(new CreateNotificationNotSelectedPostulantCommand() { Notification = notificationDto });
            return Ok(result);
        }

        [HttpPost("addnotificationfichapersonal")]
        [AllowAnonymous]
        public async Task<IActionResult> addNotificationFichaPersonal([FromBody] NotificationFilterFichaDto notificationDto)
        {
            var result = await mediator.Send(new CreateNotificationFichaCommand() { _filter = notificationDto });
            return Ok(result);
        }
    }
}
