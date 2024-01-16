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
    public class JobPregradoInternaRepository : IJobPregradoInternaRepository
    {
        private readonly DbContextMsSql context;
        public JobPregradoInternaRepository(DbContextMsSql context)
        {
            this.context = context;
        }

        public async Task<List<JobPregradoInternaDto>> GetPregradoList(int idJob)
        {
            var result = await (from p in context.JobPregradoInterna
                                join pre in context.MasterTable on p.idgrade equals pre.Id
                                where p.idjobs == idJob
                                select new JobPregradoInternaDto
                                {
                                    id = int.Parse(p.Id.ToString() +"0"+ pre.Id.ToString()),
                                    idjobs = p.idjobs,
                                    idrequest = p.idrequest,
                                    idgrade = pre.Id,
                                    scareer = p.scareer,
                                    sgrade = pre.DescriptionValue
                                }).ToListAsync();

            return result;
        }
    }
}
