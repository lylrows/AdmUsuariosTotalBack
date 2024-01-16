using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Recruitment.Contracts;
using HumanManagement.Domain.Recruitment.Dto;
using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.Recruitment
{
    public class RequestMailRepository : IRequestMailRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public RequestMailRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<RequestMailDto> GetRequestToSendMailToEvaluatorById(int id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", id);
            var request = await humanManagementReadDbConnection.QueryAsync<RequestMailDto>(
                 "sps_tb_request_get_data_send_mail_to_evaluator",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return request.SingleOrDefault();
        }

        public async Task<RequestMailDto> GetRequestToSendMailToApplicantById(int id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", id);
            var request = await humanManagementReadDbConnection.QueryAsync<RequestMailDto>(
                 "sps_tb_request_get_request_record_mail",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return request.SingleOrDefault();
        }

        public async Task<ResponseMailDto> GetResponseMailById(int id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", id);
            var response = await humanManagementReadDbConnection.QueryAsync<ResponseMailDto>(
                 "sps_tb_request_get_response",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return response.SingleOrDefault();
        }
    }
}
