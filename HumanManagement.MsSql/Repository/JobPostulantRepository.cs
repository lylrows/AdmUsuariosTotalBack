using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.MsSql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
   
    public class JobPostulantRepository : IJobPostulantRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public JobPostulantRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }


        public async Task<JobPostulantDto> GetById(int nIdJob, int nIdPostulant)
        {
            var result = await (from p in context.tb_JobPostulant
                                where p.Id_Job == nIdJob && p.Id_Postulant == nIdPostulant
                                select new JobPostulantDto
                                {
                                    Id_Job = p.Id_Job,
                                    Id_Postulant= p.Id_Postulant,
                                    DateRegister = p.DateRegister.ToShortDateString()
                                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<JobPostulantLoadDto>> GetPostulantLoad(int nIdJob)
        {
            var result = await (from p in context.tb_JobPostulant
                                join u in context.UserPostulant
                                on p.Id_Postulant equals u.Id
                                join per in context.PersonPostulant
                                on u.IdPerson equals per.Id
                                join m in context.MasterTable
                                on p.ApplicationSource equals m.Id
                                where p.Id_Job == nIdJob && (p.ApplicationSource == 985 || p.ApplicationSource == 986)
                                select new JobPostulantLoadDto
                                {
                                   Postulant = string.Concat(per.FirstName, " ", per.LastName),
                                   Email = per.Email,
                                   ApplicationSource = m.DescriptionValue,
                                   DateAppliant = (DateTime)p.DateApplicant
                                }).ToListAsync();
            return result;
        }
    }
}
