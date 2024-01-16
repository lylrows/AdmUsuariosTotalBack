using HumanManagement.Domain.EvaluationPostulant.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.EvaluationPostulant.Contracts
{
    public interface IEvaluationRepository
    {
        Task<EvaluationQueryDto> GetEvaluation(int IdEvaluation);

        Task<List<EvaluationListDto>> GetEvaluationList(int IdJob);
    }
}
