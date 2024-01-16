using HumanManagement.Domain.Evaluation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Evaluation.Contracts
{
    public interface IEvaluationRepository
    {
        Task<EvaluationHeaderDto> GetEvaluationById(int IdEvaluation);
        Task<List<EvaluationHeaderDto>> GetEvaluationByIdCampaign(int IdCampaign);
        Task<List<EvaluationDetailDto>> GetListEvaluationDetail(int IdEvaluation);
        Task<List<EvaluationMailDto>> GetEvaluationsMail(int nIdCampaign);
        Task DeleteEmployeeByCampaign(int IdEvaluation, string Comment, int idEmployee);
        Task<PrintEvaluationHeaderDto> GetPrintEvaluationById(int IdEvaluation);
        Task<List<EvaluationDetailObjetivosDto>> GetListEvaluationDetailObjetivos(int IdEvaluation);
        Task<List<EvaluationDetailCompentenciasDto>> GetListEvaluationDetailCompetencias(int IdEvaluation);
        Task<List<EvaluationDetailComentariosDto>> GetListEvaluationDetailComentarios(int IdEvaluation);
    }
}
