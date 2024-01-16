using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Contracts
{
    public interface IEvaluationInternalRepository
    {
        Task<EvaluationQueryDto> GetEvaluation(int IdEvaluation);
        Task<List<EvaluationInternListDto>> GetEvaluationList(int IdJob);
        Task<Boolean> DeletePositionPostulant(int IdEvaluationPostulant);
        Task<Boolean> InsertPositionPostulant(PositionCompany positionCompany);
        Task<List<PositionCompany>> GetPositionPostulant(int IdEvaluationPostulant);
    }
}
