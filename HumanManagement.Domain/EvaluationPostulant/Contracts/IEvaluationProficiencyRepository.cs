using HumanManagement.Domain.EvaluationPostulant.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.EvaluationPostulant.Contracts
{
    public interface IEvaluationProficiencyRepository
    {
        Task<List<EvaluationProficiencyDto>> GetEvaluationProficiencies(int IdEvaluation, int IdPostulant);
        Task<List<EvaluationProficiencyDto>> GetEvaluationProficiencies(int IdEvaluation);
    }
}
