using Dapper;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Notification.Contracts;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Notification.QueryFilter;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HumanManagement.Domain.Notification.Model;

namespace HumanManagement.MsSql.Repository.Notification
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        private readonly DbContextMsSql context;
        public NotificationRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection,
                                    DbContextMsSql context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
            this.context = context;
        }

        public async Task<List<BandejaNotificacionDto>> GetBandejaArchivados(int IdArea)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_area", IdArea);
            var bandeja = await humanManagementReadDbConnection.QueryAsync<BandejaNotificacionDto>(
                 "sps_get_bandeja_notification_archive",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return bandeja.ToList();
        }

        public async Task<List<BandejaNotificacionDto>> GetBandejaNotificacion(int IdArea, bool bisfavorite, int nIdReceptor,int nIdProfile)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_area", IdArea);
            queryParameters.Add("@bisfavorite", bisfavorite);
            queryParameters.Add("@nidreceptor", nIdReceptor);
            queryParameters.Add("@nid_profile", nIdProfile);

            var bandeja = await humanManagementReadDbConnection.QueryAsync<BandejaNotificacionDto>(
                 "sps_get_bandeja_notification",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return bandeja.ToList();
        }

        public async Task<int> GetQuantityNotifications(int IdArea, bool bisfavorite, int nIdReceptor, int nIdUser)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_area", IdArea);
            queryParameters.Add("@bisfavorite", bisfavorite);
            queryParameters.Add("@nidreceptor", nIdReceptor);
            queryParameters.Add("@nid_user", nIdUser);
            
            var bandeja = await humanManagementReadDbConnection.QueryAsync<BandejaNotificacionDto>(
                 "sps_count_bandeja_notification",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return bandeja.ToList().FirstOrDefault().Id;
        }

        public async Task<List<BandejaNotificacionDto>> GetBandejaNotificacionFilter(int IdArea, bool bisfavorite, int nIdReceptor, BandejaFilterDto filter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_area", IdArea);
            queryParameters.Add("@bisfavorite", bisfavorite);
            queryParameters.Add("@nidreceptor", nIdReceptor);
            
            queryParameters.Add("@semisor", filter.semisor);
            queryParameters.Add("@ssubject", filter.ssubject);
            queryParameters.Add("@sstartdate", filter.sstartdate);
            queryParameters.Add("@senddate", filter.senddate);



            var bandeja = await humanManagementReadDbConnection.QueryAsync<BandejaNotificacionDto>(
                 "sps_get_bandeja_noti_filter",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return bandeja.ToList();
        }

        public async Task<List<BandejaNotificacionDto>> GetBandejaNotificacionFavorite(int IdArea, int nIdReceptor)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_area", IdArea);
            queryParameters.Add("@nidreceptor", nIdReceptor);
            var bandeja = await humanManagementReadDbConnection.QueryAsync<BandejaNotificacionDto>(
                 "sps_get_bandeja_notification_favorite",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return bandeja.ToList();
        }

        public async Task<List<BandejaNotificacionDto>> GetBandejaNotificacionRecognition(int IdUser)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_user", IdUser);
            var bandeja = await humanManagementReadDbConnection.QueryAsync<BandejaNotificacionDto>(
                 "sps_get_recognition",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return bandeja.ToList();
        }

        public async Task<List<BandejaNotificacionDto>> GetBandejaNotificacionRecognitionArchived(int IdUser)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_user", IdUser);
            var bandeja = await humanManagementReadDbConnection.QueryAsync<BandejaNotificacionDto>(
                 "sps_get_recognition_archived",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return bandeja.ToList();
        }

        public async Task<NotificationDto> GetBydId(int id)
        {
            var result = await (from n in context.Notification
                                join a in context.tb_area on n.IdArea equals a.Id into na
                                from area in na.DefaultIfEmpty()
                          where n.Id == id
                          select new NotificationDto
                          {
                              Id = n.Id,
                              IdArea = n.IdArea,
                              IdCompany = area.IdEmpresa,
                              Subject = n.Subject,
                              Body = n.Body,
                              SendDate = n.SendDate,
                              IdReceptor = n.IdReceptor
                          }).SingleOrDefaultAsync();

            return result;
        }

        public async Task<NotificationFavorite> GetNotiFavoriteModel(int nidNotification, int nIdReceptor)
        {
            var result = await (from pers in context.tb_notification_favorite
                                where pers.Id == nidNotification && pers.IdReceptor == nIdReceptor
                                select pers).SingleOrDefaultAsync();
            return result;
        }
        public async Task<NotificationViewed> GetNotiViewedModel(int nidNotification, int nIdReceptor)
        {
            var result = await (from pers in context.tb_notification_viewed
                                where pers.Id == nidNotification && pers.IdReceptor == nIdReceptor
                                select pers).SingleOrDefaultAsync();
            return result;
        }

        public async Task<ResultPaginationListDto<NotificationListDto>> GetListWithPagination(NotificationQueryFilter notificationQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidcompany", notificationQueryFilter.IdCompany);
            queryParameters.Add("@nidarea", notificationQueryFilter.IdArea);
            queryParameters.Add("@ssubject", notificationQueryFilter.Subject);
            queryParameters.Add("@ncurrentpage", notificationQueryFilter.pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", notificationQueryFilter.pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listUSer = await humanManagementReadDbConnection.QueryAsync<NotificationListDto>(
                 "sps_notification_get_list_paginated",
                 queryParameters, commandType: CommandType.StoredProcedure);

            int totalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));

            return new ResultPaginationListDto<NotificationListDto>
            {
                list = listUSer.ToList(),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / notificationQueryFilter.pagination.ItemsPerPage)
            };
        }
        
        public async Task<List<SendNotificationSolicitudApprovedDto>> GetSendNotificationSolicitudApproved(SolicitudApprovedQueryFilter solicitudApprovedQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_user", solicitudApprovedQueryFilter.IdUser);
            queryParameters.Add("@nid_company", solicitudApprovedQueryFilter.IdCompany);
            queryParameters.Add("@nid_profile", solicitudApprovedQueryFilter.IdProfile);
            queryParameters.Add("@is_option", solicitudApprovedQueryFilter.IsOption);
            queryParameters.Add("@nid_request", solicitudApprovedQueryFilter.IdRequest);

            var result = await humanManagementReadDbConnection.QueryAsync<SendNotificationSolicitudApprovedDto>(
                 "sp_send_notification_solicitud_approved",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }
    }
}
