using Dapper;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Job.QueryFilter;
using HumanManagement.MsSql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.Job
{
    public class JobInternalRepository : IJobInternalRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        private readonly DbContextMsSql context;

        public JobInternalRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection,
                                     DbContextMsSql context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
            this.context = context;
        }
        public async Task<ResultPaginationListDto<JobDto>> GetAllJobsInternal(JobInternalQueryFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidcompany", filter.IdEmpresa);
            queryParameters.Add("@nidgerencia", filter.IdGerencia);
            queryParameters.Add("@nidarea", filter.IdArea);
            queryParameters.Add("@nidjobtype", filter.IdJobType);
            queryParameters.Add("@ncurrentpage", filter.pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", filter.pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listContacts = await humanManagementReadDbConnection.QueryAsync<JobDto>(
                 "sps_jobsinternal_list",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<JobDto> result = new ResultPaginationListDto<JobDto>();
            result.list = listContacts.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / filter.pagination.ItemsPerPage);

            return result;
        }

        public async Task<JobDto> GetById(int nId)
        {
            var result = await (from p in context.tb_job_offers
                                join a in context.tb_AreaRecruitment
                                on p.Id_Area equals a.Id_Area
                                join e in context.tb_company
                                on p.Id_Company equals e.Id

                                join mod in context.MasterTable
                                 on p.Id_JobType equals mod.Id

                                join modwork in context.MasterTable
                                on p.Id_WorkType equals modwork.Id

                                join exp in context.MasterTable
                                on p.Id_JobLevel equals exp.Id

                                where p.Id_Job == nId

                                select new JobDto
                                {
                                    id_job = p.Id_Job,
                                    idcompany = (int)p.Id_Company,
                                    nsalary = p.Salary,
                                    sbenefits = p.Benefits,
                                    slocation = p.Location,
                                    stitle = p.Title,
                                    snoticedetails = p.NoticeDetails,
                                    sjobtype = mod.DescriptionValue,
                                    smodality = modwork.DescriptionValue,
                                    srequirements = p.Requirements,
                                    dcreationdate = p.DateRegister,
                                    sarea = a.AreaName,
                                    screationdate = p.DateRegister.ToShortDateString(),
                                    scompanyimageurl = e.ImageUrl,
                                    scompanyname = e.Descripcion
                                }).FirstOrDefaultAsync();


            return result;
        }

        public async Task<ResultPaginationListDto<JobUserDto>> GetJobsByUser(JobQueryFilter jobQueryFilter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_user", jobQueryFilter.IdUser);
            queryParameters.Add("@ncurrentpage", jobQueryFilter.pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", jobQueryFilter.pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var list = await humanManagementReadDbConnection.QueryAsync<JobUserDto>(
                 "sps_publications_job_internal_user",
                 queryParameters, commandType: CommandType.StoredProcedure);

            ResultPaginationListDto<JobUserDto> result = new ResultPaginationListDto<JobUserDto>();
            result.list = list.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / jobQueryFilter.pagination.ItemsPerPage);

            return result;
        }
    }
}
