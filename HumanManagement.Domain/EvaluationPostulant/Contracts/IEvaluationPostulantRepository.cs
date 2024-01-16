using HumanManagement.Domain.EvaluationPostulant.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.EvaluationPostulant.Contracts
{
    public interface IEvaluationPostulantRepository
    {
        Task<List<EvaluationPostulantDto>> GetEvaluationPostulants(int IdEvaluation);
        Task<List<EvaluationPostulantDto>> GetEvaluationPostulantsExport(int IdEvaluation);
        int GetMaxIdEvaluationByPostulant(int idPostulant);
    }
}
