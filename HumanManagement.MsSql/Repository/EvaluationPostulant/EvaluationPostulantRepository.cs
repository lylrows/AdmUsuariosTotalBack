using HumanManagement.Domain.EvaluationPostulant.Contracts;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.EvaluationPostulant
{
    public class EvaluationPostulantRepository : IEvaluationPostulantRepository
    {
        private readonly DbContextMsSql context;
        public EvaluationPostulantRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<List<EvaluationPostulantDto>> GetEvaluationPostulants(int IdEvaluation)
        {
            var dtos = await (from p in context.tb_evaluation_postulants
                              join m in context.MasterTable on p.State equals m.Id
                              join pe in context.PersonPostulant on p.IdPostulant equals pe.Id
                              where p.IdEvaluation == IdEvaluation
                              select new EvaluationPostulantDto
                              {
                                  Id = p.Id,
                                  FullNamePostulant = string.Concat(pe.FirstName, " ", pe.SecondName, " ",pe.LastName, " ", pe.MotherLastName),
                                  IdPostulant = p.IdPostulant,
                                  EmailPostulant = pe.Email,
                                  IdEvaluation = p.IdEvaluation,
                                  PhoneNumberPostulant = pe.CellPhone,
                                  DescripcionState = m.DescriptionValue,
                                  State = p.State,
                                  bisonexactus = pe.bisonexactus
                              }).ToListAsync();
            return dtos;
        }

        public async Task<List<EvaluationPostulantDto>> GetEvaluationPostulantsExport(int IdEvaluation)
        {
            var dtos = await (from p in context.tb_evaluation_postulants
                              join m in context.MasterTable on p.State equals m.Id
                              join pe in context.PersonPostulant on p.IdPostulant equals pe.Id
                              where p.IdEvaluation == IdEvaluation
                              select new EvaluationPostulantDto
                              {
                                  Id = p.Id,
                                  FullNamePostulant = string.Concat(pe.FirstName, " ", pe.LastName),
                                  IdPostulant = p.IdPostulant,
                                  EmailPostulant = pe.Email,
                                  IdEvaluation = p.IdEvaluation,
                                  PhoneNumberPostulant = pe.CellPhone,
                                  DescripcionState = m.DescriptionValue,
                                  State = p.State,
                                  bisonexactus = pe.bisonexactus
                              }).ToListAsync();
            return dtos;
        }

        public int GetMaxIdEvaluationByPostulant(int idPostulant)
        {
            var maxId = context.tb_evaluation_postulants.Where(x => x.IdPostulant == idPostulant).Select(p => p.IdEvaluation).DefaultIfEmpty().ToList().Max();
            return maxId;
        }
    }
}
