using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HumanManagement.Domain.InformationPostulant.Dto;
using Dapper;
using HumanManagement.Domain.Contracts;
using System.Data;

namespace HumanManagement.MsSql.Repository.EvaluationPostulantInternal
{
    public class EvaluationPostulantsInternalRepository: IEvaluationPostulantsInternalRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection _humanManagementReadDbConnection;
        public EvaluationPostulantsInternalRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            _humanManagementReadDbConnection = humanManagementReadDbConnection;
        }

        public async Task<List<EvaluationPostulantDto>> GetEvaluationPostulants(int IdEvaluation)
        {
            
            var tempphone = (from p in context.Phone where p.IdPerson == 0 select p.phone).FirstOrDefault();


            var dtos = await (from p in context.tb_evaluation_postulants_internal
                              join m in context.MasterTable on p.State equals m.Id
                              join pe in context.Person on p.IdPostulant equals pe.Id
                              
                              where p.IdEvaluation == IdEvaluation
                              select new EvaluationPostulantDto
                              {
                                  Id = p.Id,
                                  FullNamePostulant = string.Concat(pe.FirstName, " ", pe.SecondName, " ", pe.LastName, " ", pe.MotherLastName),
                                  IdPostulant = p.IdPostulant,
                                  EmailPostulant = pe.Email,
                                  IdEvaluation = p.IdEvaluation,
                                  PhoneNumberPostulant = (from phone in context.Phone where phone.IdPerson == pe.Id select phone.phone).FirstOrDefault(),
                                  DescripcionState = m.DescriptionValue,
                                  State = p.State
                              }).ToListAsync();
            return dtos;
        }

        public async Task<List<EvaluationPostulantDto>> GetEvaluationPostulantsExport(int IdEvaluation)
        {
            var tempphone = from p in context.Phone group p by p.phone into phone select phone.FirstOrDefault();

            var dtos = await (from p in context.tb_evaluation_postulants_internal
                              join m in context.MasterTable on p.State equals m.Id
                              join pe in context.Person on p.IdPostulant equals pe.Id
                              join phone in context.Phone on pe.Id equals phone.IdPerson
                              where p.IdEvaluation == IdEvaluation
                              select new EvaluationPostulantDto
                              {
                                  Id = p.Id,
                                  FullNamePostulant = string.Concat(pe.FirstName, " ", pe.LastName),
                                  IdPostulant = p.IdPostulant,
                                  EmailPostulant = pe.Email,
                                  IdEvaluation = p.IdEvaluation,
                                  PhoneNumberPostulant = phone.phone,
                                  DescripcionState = m.DescriptionValue,
                                  State = p.State
                              }).ToListAsync();
            return dtos;
        }

        public async Task<List<InformationPostulantDto>> GetEvaluationPostulantsAll(FilterParamDto filter)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@ntypefilter", filter.ntypefilter);
                queryParameters.Add("@typedocument", filter.typedocument);
                queryParameters.Add("@documentnumber", filter.numberdocumen);
                queryParameters.Add("@fullname", filter.fullname);
                queryParameters.Add("@nstate", filter.nstate);
                var lstFiles = await _humanManagementReadDbConnection.QueryAsync<InformationPostulantDto>(
                    "sps_recruitment_person_list", queryParameters,
                    commandType: CommandType.StoredProcedure);
                return lstFiles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
