using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.MsSql.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace HumanManagement.MsSql.Repository.Job
{
    public class JobPostgradoRepository : IJobPostgradoRepository
    {
        private readonly DbContextMsSql context;
        public JobPostgradoRepository(DbContextMsSql context)
        {
            this.context = context;
        }

        public async Task<List<JobPostgradoDto>> GetPostgradoList(int idJob)
        {
            var result = await (from p in context.JobPostgrado
                                where p.idjobs == idJob
                                select new JobPostgradoDto
                                {
                                    id = int.Parse(p.Id.ToString() + "0" + p.idgrade.ToString()),
                                    idjobs = p.idjobs,
                                    idrequest = p.idrequest,
                                    idgrade = p.idgrade,
                                    scareer = p.scareer,
                                    sgrade = p.sgrade
                                }).ToListAsync();

            return result;
        }
    }
}
