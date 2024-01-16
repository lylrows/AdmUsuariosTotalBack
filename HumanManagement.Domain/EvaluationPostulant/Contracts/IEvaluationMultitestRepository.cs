using HumanManagement.Domain.EvaluationPostulant.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.EvaluationPostulant.Contracts
{
    public interface IEvaluationMultitestRepository
    {
        Task<List<EvaluationMultitestExternDto>> GetEvaluationMultitest(int IdEvaluation);
    }
}
