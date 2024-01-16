using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Contracts
{
    public interface IEvaluationFortalezasInternRepository
    {
        Task<List<EvaluationFortalezasInternDto>> GetEvaluationFortalezasPostulants(int IdEvaluation, int IdPostulant);

        Task<List<EvaluationFortalezasInternDto>> GetEvaluationFortalezasPostulants(int IdEvaluation);
    }
}
