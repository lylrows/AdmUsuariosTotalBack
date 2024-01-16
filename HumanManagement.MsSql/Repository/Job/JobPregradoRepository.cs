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
    public class JobPregradoRepository : IJobPregradoRepository
    {
        private readonly DbContextMsSql context;
        public JobPregradoRepository(DbContextMsSql context)
        {
            this.context = context;
        }

        public async Task<List<JobPregradoDto>> GetPregradoList(int idJob)
        {
            var result = await (from p in context.JobPregrado
                                join pre in context.MasterTable on p.idgrade equals pre.Id
                                where p.idjobs == idJob
                                select new JobPregradoDto
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
