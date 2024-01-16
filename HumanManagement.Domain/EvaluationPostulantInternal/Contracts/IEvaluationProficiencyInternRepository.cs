using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Contracts
{
    public interface IEvaluationProficiencyInternRepository
    {
        Task<List<EvaluationProficiencyInternDto>> GetEvaluationProficiencies(int IdEvaluation, int IdPostulant, int Flag);

        Task<List<EvaluationProficiencyInternDto>> GetEvaluationProficiencies(int IdEvaluation, int Flag);
    }
}
