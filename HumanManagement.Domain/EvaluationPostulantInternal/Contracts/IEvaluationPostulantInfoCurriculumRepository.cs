using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Contracts
{
    public interface IEvaluationPostulantInfoCurriculumRepository
    {
        Task<List<EvaluationPostulantInfoCurriculumDto>> GetList(int IdEvaluation);
        Task<bool> SetDataInitial(int IdEvaluationPostulant);
    }
}
