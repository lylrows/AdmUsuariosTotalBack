using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.MsSql.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.PostJobOffer
{
    public class JobKeyWordRepository : IJobKeyWordRepository
    {
        private readonly DbContextMsSql context;
        public JobKeyWordRepository(DbContextMsSql context)
        {
            this.context = context;
        }

        public async Task DeleteByJob(int idJob)
        {
            context.RemoveRange(context.JobKeyWords.Where(x => x.IdJob == idJob));
            await context.SaveChangesAsync();
        }
        public async Task DeleteKeyWord(int id)
        {
            context.RemoveRange(context.JobKeyWords.Where(x => x.Id == id));
            await context.SaveChangesAsync();
        }

        public async Task<List<JobKeyWordDto>> GetKeyWordList(int idJob)
        {
            var result = await(from p in context.JobKeyWords
                               where p.IdJob == idJob
                               select new JobKeyWordDto
                               {
                                   Id = p.Id,
                                   IdJob = p.IdJob,
                                   KeyWord = p.KeyWord
                               }).ToListAsync();

            return result;
        }

        public async Task<List<JobKeyWordDto>> GetListByJob(int[] arrayIdPostulant)
        {
            var list = await (from n in context.tb_JobPostulant
                              join kw in context.JobKeyWords on n.Id_Job equals kw.IdJob
                              join us in context.UserPostulant on n.Id_Postulant equals us.Id
                              where arrayIdPostulant.Contains(us.IdPerson)
                              select new JobKeyWordDto
                              {
                                  IdPostulant = us.IdPerson,
                                  IdJob = n.Id_Job,
                                  KeyWord = kw.KeyWord
                              }).ToListAsync();

            return list;
        }
    }
}
