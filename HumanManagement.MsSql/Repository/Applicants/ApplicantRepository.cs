using Dapper;
using HumanManagement.Domain.Applicants.Contracts;
using HumanManagement.Domain.Applicants.Dto;
using HumanManagement.Domain.Contracts;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.Applicants
{
    public class ApplicantRepository: IApplicantRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public ApplicantRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }

        public async Task<List<ListJobDto>> GetListJob(int IdUser)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_user", IdUser);

            var list = await humanManagementReadDbConnection.QueryAsync<ListJobDto>(
                 "recruitment.sp_job_list",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }

        public async Task<List<ListApplicantsDto>> GetListMyApplicants(FilterApplicants filters)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_user", filters.IdUser);
            queryParameters.Add("@order", filters.order);
            queryParameters.Add("@nid_state", filters.nid_state);

            var list = await humanManagementReadDbConnection.QueryAsync<ListApplicantsDto>(
                 "recruitment.sp_application_list",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }

        public async Task<List<ListStateApplicantsDto>> GetStateApplicants(int IdUser)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_user", IdUser);

            var list = await humanManagementReadDbConnection.QueryAsync<ListStateApplicantsDto>(
                 "recruitment.sp_postulation_state",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }
    }
}
