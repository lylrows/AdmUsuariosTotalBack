using HumanManagement.Domain.EvaluationPostulant.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.EvaluationPostulant.Contracts
{
    public interface IEvaluationRatingRepository { 
    Task<List<EvaluationRatingPostulantDto>> GetEvaluationRatingPostulants(int IdEvaluation);
    Task<List<EvaluationRatingPostulantDto>> GetEvaluationRatingPostulants(int IdEvaluation, int IdPostulant); 
    }
}
