using HumanManagement.Domain.Common;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Notification.Model;
using HumanManagement.Domain.Notification.QueryFilter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Notification.Contracts
{
    public interface INotificationRepository
    {
        Task<NotificationDto> GetBydId(int id);
        Task<ResultPaginationListDto<NotificationListDto>> GetListWithPagination(NotificationQueryFilter notificationQueryFilter);
        Task<List<BandejaNotificacionDto>> GetBandejaNotificacion(int IdArea, bool bisfavorite, int nIdReceptor,int nIdProfile);
        Task<int> GetQuantityNotifications(int IdArea, bool bisfavorite, int nIdReceptor, int nIdUser);
        Task<List<BandejaNotificacionDto>> GetBandejaNotificacionFilter(int IdArea, bool bisfavorite, int nIdReceptor, BandejaFilterDto filter);
        Task<List<BandejaNotificacionDto>> GetBandejaNotificacionFavorite(int IdArea, int nIdReceptor);
        Task<List<BandejaNotificacionDto>> GetBandejaArchivados(int IdArea);
        Task<List<BandejaNotificacionDto>> GetBandejaNotificacionRecognition(int IdUser);
        Task<List<BandejaNotificacionDto>> GetBandejaNotificacionRecognitionArchived(int IdUser);
        Task<NotificationFavorite> GetNotiFavoriteModel(int nidNotification, int nIdReceptor);
        Task<NotificationViewed> GetNotiViewedModel(int nidNotification, int nIdReceptor);
        Task<List<SendNotificationSolicitudApprovedDto>> GetSendNotificationSolicitudApproved(SolicitudApprovedQueryFilter solicitudApprovedQueryFilter);

    }
}
