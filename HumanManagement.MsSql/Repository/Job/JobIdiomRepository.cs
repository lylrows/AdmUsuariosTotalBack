using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.MsSql.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.Job
{
    public class JobIdiomRepository : IJobIdiomRepository
    {
        private readonly DbContextMsSql context;
        public JobIdiomRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<List<JobIdiomDto>> GetIdiomList(int idJob)
        {
            var result = await (from p in context.JobIdiom
                                join idiom in context.MasterTable on p.IdIdiom equals idiom.Id
                                join level in context.MasterTable on p.IdIdiomlevel equals level.Id
                                where p.IdJob == idJob
                                select new JobIdiomDto
                                {
                                    Id = p.Id,
                                    IdIdiom = p.IdIdiom,
                                    IdIdiomlevel = p.IdIdiomlevel,
                                    Idiom = idiom.DescriptionValue,
                                    IdiomLevel = level.DescriptionValue,
                                    IdJob = p.IdJob
                                }).ToListAsync();

            return result;
        }

        public async Task DeleteByJob(int idJob)
        {
            context.RemoveRange(context.JobIdiom.Where(x => x.IdJob == idJob));
            await context.SaveChangesAsync();
        }
    }
}
