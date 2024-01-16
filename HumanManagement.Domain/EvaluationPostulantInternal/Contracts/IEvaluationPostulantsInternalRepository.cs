using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.Domain.InformationPostulant.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Contracts
{
    public interface IEvaluationPostulantsInternalRepository
    {
        Task<List<EvaluationPostulantDto>> GetEvaluationPostulants(int IdEvaluation);
        Task<List<EvaluationPostulantDto>> GetEvaluationPostulantsExport(int IdEvaluation);
        Task<List<InformationPostulantDto>> GetEvaluationPostulantsAll(FilterParamDto filter);
    }
}
