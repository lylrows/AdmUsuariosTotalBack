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

using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public JobRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }


        public async Task<JobDto> GetById(int nId)
        {
            var result = await (from p in context.tb_Job
                                join a in context.tb_AreaRecruitment
                                on p.Id_Area equals a.Id_Area
                                join modwork in context.MasterTable
                                on p.Id_WorkType equals modwork.Id
                                join c in context.tb_company
                                on p.Id_Company equals c.Id
                                where p.Id_Job == nId
                                select new JobDto
                                {
                                    id_job = p.Id_Job,
                                    nsalary = p.MaximumSalary,
                                    sbenefits = p.Benefits,
                                    slocation = p.Location,
                                    stitle = p.Title,
                                    snoticedetails = p.NoticeDetails,
                                    smodality = modwork.DescriptionValue,
                                    srequirements = p.Requirements,
                                    dcreationdate = p.DateRegister,
                                    sarea = a.AreaName,
                                    sjobtype = p.JobType,
                                    scompanyname = c.Descripcion,
                                    scompanyimageurl = c.ImageUrl,
                                    idcompany = c.Id
                                }).FirstOrDefaultAsync();
            return result;
        }
        public async Task<List<JobDto>> GetRelatedJobs(int nIdJob)
        {

            int nidArea = 0;
            if (nIdJob != 0)
                nidArea = context.tb_Job.Where(i => i.Id_Job == nIdJob).Select(i => i.Id_Area).FirstOrDefault();


            var result = await (from p in context.tb_Job
                                join a in context.tb_AreaRecruitment
                                on p.Id_Area equals a.Id_Area
                                join modwork in context.MasterTable
                                on p.Id_WorkType equals modwork.Id
                                join c in context.tb_company
                                on p.Id_Company equals c.Id
                                where p.Id_Area == (nidArea == 0 ? p.Id_Area : nidArea)
                                && p.Id_Job != nIdJob
                                orderby p.DateRegister descending
                                select new JobDto
                                {
                                    id_job = p.Id_Job,
                                    nsalary = p.Salary,
                                    sbenefits = p.Benefits,
                                    slocation = p.Location,
                                    stitle = p.Title,
                                    snoticedetails = p.NoticeDetails,
                                    smodality = modwork.DescriptionValue,
                                    srequirements = p.Requirements,
                                    dcreationdate = p.DateRegister,
                                    sarea = a.AreaName,
                                    sjobtype = p.JobType,
                                    screationdate = p.DateRegister.ToShortDateString(),
                                    scompanyname = c.Descripcion,
                                    scompanyimageurl = c.ImageUrl,
                                    idcompany = c.Id
                                }).Take(5).ToListAsync();
            return result;
        }
        public async Task<List<JobDto>> GetOtherJobs()
        {
            var result = await (from p in context.tb_Job
                                join a in context.tb_AreaRecruitment
                                on p.Id_Area equals a.Id_Area
                                join modwork in context.MasterTable
                                on p.Id_WorkType equals modwork.Id
                                join e in context.tb_company
                                on p.Id_Company equals e.Id
                                orderby p.DateRegister descending
                                select new JobDto
                                {
                                    id_job = p.Id_Job,
                                    nsalary = p.Salary,
                                    sbenefits = p.Benefits,
                                    slocation = p.Location,
                                    stitle = p.Title.ToUpper(),
                                    snoticedetails = p.NoticeDetails,
                                    smodality = modwork.DescriptionValue,
                                    srequirements = p.Requirements,
                                    dcreationdate = p.DateRegister,
                                    sarea = a.AreaName,
                                    sjobtype = p.JobType,
                                    screationdate = p.DateRegister.ToShortDateString(),
                                    scompanyname = e.Descripcion,
                                    scompanyimageurl = e.ImageUrl,
                                    idcompany = e.Id
                                }).Take(5).ToListAsync();
            return result;
        }
        public async Task<List<JobDto>> GetAllJobs(JobFilterDto filter)
        {
            DateTime fromDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            var companys = filter.Companys.Count() > 0 ? string.Join(", ", filter.Companys?.ToArray()) : string.Empty;
            var jobTypes = filter.JobTypes.Count() > 0 ? string.Join(", ", filter.JobTypes?.ToArray()) : string.Empty;
            var workTypes = filter.WorkTypes.Count() > 0 ? string.Join(", ", filter.WorkTypes?.ToArray()) : string.Empty;
            var Isdiscapacities = filter.Isdiscapacities?.Count() > 0 ? string.Join(", ", filter.Isdiscapacities?.ToArray()) : string.Empty;
            var maxTime = filter.CreationDates.Count() > 0 ?  filter.CreationDates?.Max() ?? 0 : -1;

            if ( maxTime >-1)
                fromDate = fromDate.AddDays((maxTime * -1));

            var result = await (from p in context.tb_Job
                                

                                join e in context.tb_company
                                on p.Id_Company equals e.Id

                                join mod in context.MasterTable
                                 on p.Id_JobType equals mod.Id

                                join modwork in context.MasterTable
                                on p.Id_WorkType equals modwork.Id

                                join exp in context.MasterTable
                                on p.Id_JobLevel equals exp.Id

                                where
                                (filter.JobLevel == 0 || p.Id_JobLevel == filter.JobLevel)

                                && (filter.JobTypes.Count == 0 || jobTypes.Contains(p.Id_JobType.ToString()))
                                && (filter.WorkTypes.Count == 0 || workTypes.Contains(p.Id_WorkType.ToString()))
                                && ((filter.Companys.Count() == 0 || filter.Companys.Contains(0)) || companys.Contains(p.Id_Company.ToString()))
                                && (filter.CreationDates.Count == 0 || p.DateRegister >= fromDate)
                                && (filter.Isdiscapacities.Count() == 0 || Isdiscapacities.Contains(p.IsSuitableForDisabled ? "Si" : "No"))
                                && (filter.Idcategory == 0  || p.Id_category == filter.Idcategory)

                                orderby p.DateRegister descending

                                select new JobDto
                                {
                                    id_job = p.Id_Job,
                                    nsalary = p.Salary,
                                    sbenefits = p.Benefits,
                                    slocation = p.Location,
                                    stitle = p.Title,
                                    snoticedetails = p.NoticeDetails,
                                    sjobtype = mod.DescriptionValue,
                                    smodality = modwork.DescriptionValue,
                                    srequirements = p.Requirements,
                                    dcreationdate = p.DateRegister,
                                    screationdate = p.DateRegister.ToShortDateString(),
                                    scompanyimageurl = e.ImageUrlLarge,
                                    scompanyname = e.Descripcion,
                                    isSuitableForDisabled=p.IsSuitableForDisabled
                                }).Distinct().ToListAsync();

            result = result.OrderByDescending(x => x.dcreationdate).ToList();
            return result;
        }


        public async Task<JobOfferDto> GetByIdRequest(int idRequest)
        {
            var result = await (from p in context.tb_Job
                                join a in context.tb_AreaRecruitment
                                on p.Id_Area equals a.Id_Area
                                join modwork in context.MasterTable
                                on p.Id_WorkType equals modwork.Id
                                join d in context.District on p.IdDistrict equals d.Id
                                join pro in context.Province on d.IdProvince equals pro.Id
                                join dep in context.Department on pro.IdDepartment equals dep.Id
                                where p.IdRequest == idRequest
                                select new JobOfferDto
                                {
                                    Id_Job = p.Id_Job,
                                    Salary = p.Salary,
                                    Benefits = p.Benefits,
                                    Location = p.Location,
                                    Title = p.Title,
                                    NoticeDetails = p.NoticeDetails,
                                    Id_WorkType = p.Id_WorkType,
                                    Requirements = p.Requirements,
                                    Id_Area = p.Id_Area,
                                    Id_JobType = p.Id_JobType,
                                    Id_JobLevel = p.Id_JobLevel,
                                    IdSex = p.IdSex,
                                    IdDepartment = dep.Id,
                                    IdProvince = pro.Id,
                                    IdDistrict = p.IdDistrict,
                                    IdEducationLevel = p.IdEducationLevel,
                                    IdEducationLevelSituation = p.IdEducationLevelSituation,
                                    Id_Company = p.Id_Company,
                                    IsSuitableForDisabled = p.IsSuitableForDisabled,
                                    IsPostedBumeran = p.IsPostedBumeran,
                                    IsPostedComputrabajo = p.IsPostedComputrabajo,
                                    MaximumAge = p.MaximumAge,
                                    MinimumAge = p.MinimumAge,
                                    MaximumSalary = p.MaximumSalary,
                                    MinimumSalary = p.MinimumSalary,
                                    ShowSalaryInNotice = p.ShowSalaryInNotice,
                                    IncludeKeywords = p.IncludeKeywords,
                                    Tags = p.Tags,
                                    Vacancies = p.Vacancies,
                                    WorkExperience = p.WorkExperience,
                                    FinishDate = p.FinishDate,
                                    IdCharge = p.IdCharge,
                                    IdRequest = p.IdRequest,
                                    IdApplicant = p.IdApplicant
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
                 "sps_publications_job_user",
                 queryParameters, commandType: CommandType.StoredProcedure);

            ResultPaginationListDto<JobUserDto> result = new ResultPaginationListDto<JobUserDto>();
            result.list = list.ToList();

            return result;
        }

        public async Task<JobOfferInternalDto> GetJobInternByIdRequest(int idRequest)
        {
            var result = await (from p in context.tb_job_offers
                                join a in context.tb_AreaRecruitment
                                on p.Id_Area equals a.Id_Area
                                join modwork in context.MasterTable
                                on p.Id_WorkType equals modwork.Id
                                join d in context.District on p.IdDistrict equals d.Id
                                join pro in context.Province on d.IdProvince equals pro.Id
                                join dep in context.Department on pro.IdDepartment equals dep.Id
                                where p.IdRequest == idRequest
                                select new JobOfferInternalDto
                                {
                                    Id_Job = p.Id_Job,
                                    Salary = p.Salary,
                                    Benefits = p.Benefits,
                                    Location = p.Location,
                                    Title = p.Title,
                                    NoticeDetails = p.NoticeDetails,
                                    Id_WorkType = p.Id_WorkType,
                                    Requirements = p.Requirements,
                                    Id_Area = p.Id_Area,
                                    Id_JobType = p.Id_JobType,
                                    Id_JobLevel = p.Id_JobLevel,
                                    IdSex = p.IdSex,
                                    IdDepartment = dep.Id,
                                    IdProvince = pro.Id,
                                    IdDistrict = p.IdDistrict,
                                    IdEducationLevel = p.IdEducationLevel,
                                    IdEducationLevelSituation = p.IdEducationLevelSituation,
                                    Id_Company = p.Id_Company,
                                    IsSuitableForDisabled = p.IsSuitableForDisabled,
                                    IsPostedBumeran = p.IsPostedBumeran,
                                    IsPostedComputrabajo = p.IsPostedComputrabajo,
                                    MaximumAge = p.MaximumAge,
                                    MinimumAge = p.MinimumAge,
                                    MaximumSalary = p.MaximumSalary,
                                    MinimumSalary = p.MinimumSalary,
                                    ShowSalaryInNotice = p.ShowSalaryInNotice,
                                    IncludeKeywords = p.IncludeKeywords,
                                    Tags = p.Tags,
                                    Vacancies = p.Vacancies,
                                    WorkExperience = p.WorkExperience,
                                    FinishDate = p.FinishDate,
                                    IdCharge = p.IdCharge,
                                    IdRequest = p.IdRequest,
                                    IdApplicant = p.IdApplicant
                                }).FirstOrDefaultAsync();
            return result;
        }
    }
}
