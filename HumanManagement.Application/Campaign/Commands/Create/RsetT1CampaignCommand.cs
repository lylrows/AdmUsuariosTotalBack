using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Evaluation.Contracts;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Commands.Create
{
    public class RsetT1CampaignCommand : IRequest<Result>
    {
        public int IdCampaign { get; set; }
    }

    public class RsetT1CampaignCommandHandler : IRequestHandler<RsetT1CampaignCommand, Result>
    {

        private readonly IBaseRepository<Domain.Campaign.Models.Campaign> _baseCampaign;
        private readonly IBaseRepository<Domain.Evaluation.Models.Evaluation> _baseEv;
        private readonly IBaseRepository<Domain.Evaluation.Models.EvaluationDetail> _baseEvDetail;
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork unitOfWork;

        public RsetT1CampaignCommandHandler(IBaseRepository<Domain.Campaign.Models.Campaign> baseCampaign, IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork, IEvaluationRepository evaluationRepository, IBaseRepository<Domain.Evaluation.Models.EvaluationDetail> baseEvDetail, IBaseRepository<Domain.Evaluation.Models.Evaluation> baseEv)
        {
            this._baseCampaign = baseCampaign;
            _appSettings = appSettings.Value;
            this.unitOfWork = unitOfWork;
            _evaluationRepository = evaluationRepository;
            _baseEvDetail = baseEvDetail;
            _baseEv = baseEv;
        }

        public async Task<Result> Handle(RsetT1CampaignCommand request, CancellationToken cancellationToken)
        {
            var currentCampaign = await _baseCampaign.Find(request.IdCampaign);

            if (currentCampaign == null)
            {
                return new Result
                {
                    StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                    MessageError = new List<string>() { "No se encontró la campaña." }
                };
            }

            var header = await _evaluationRepository.GetEvaluationByIdCampaign(request.IdCampaign);

            if (header != null)
            {

                foreach (var item in header)
                {
                    var details = await _evaluationRepository.GetListEvaluationDetail(item.IdEvaluation);
                    if (details != null)
                    {
                        foreach (var ev_det in details)
                        {
                            if (ev_det.NumberAction == 7)
                            {
                                var ev_det_db = await _baseEvDetail.Find(ev_det.IdEvaluationDetail);

                                if (ev_det_db != null)
                                {

                                    Domain.Evaluation.Models.EvaluationDetail newEvalDetail = new Domain.Evaluation.Models.EvaluationDetail();

                                    DateTime? dDateStart = null;
                                    if (!string.IsNullOrEmpty(ev_det.StartDate))
                                        dDateStart = DateTime.Parse(ev_det.StartDate);

                                    DateTime? dDateEnd = null;
                                    if (!string.IsNullOrEmpty(ev_det.EndDate))
                                        dDateEnd = DateTime.Parse(ev_det.EndDate);


                                    newEvalDetail.IdEvaluation = ev_det_db.IdEvaluation;
                                    newEvalDetail.IdGroup = ev_det_db.IdGroup;
                                    newEvalDetail.IdProficiency = ev_det_db.IdProficiency;
                                    newEvalDetail.IdProficiencyLevel = ev_det_db.IdProficiencyLevel;
                                    newEvalDetail.NumberOfAction = ev_det_db.NumberOfAction + 3;
                                    newEvalDetail.Active = true;


                                    newEvalDetail.Qualification = ev_det.Qualification;
                                    newEvalDetail.ActionsToImprove = ev_det.ActionsToImprove;
                                    newEvalDetail.Indicator = ev_det.Indicator;
                                    newEvalDetail.StartDate = dDateStart;
                                    newEvalDetail.EndDate = dDateEnd;
                                    newEvalDetail.JobObjectives = ev_det.JobObjectives;
                                    newEvalDetail.IndicatorOrganizational = ev_det.IndicatorOrganizational;
                                    newEvalDetail.Goal = ev_det.Goal;
                                    newEvalDetail.GoalString = ev_det.GoalString;
                                    newEvalDetail.Weight = ev_det.Weight;
                                    await _baseEvDetail.Add(newEvalDetail);
                                }
                            }
                        }
                    }

                    var currentEvaluation = await _baseEv.Find(item.IdEvaluation);
                    currentEvaluation.NumberAction = currentEvaluation.NumberAction==7?10: currentEvaluation.NumberAction+1;

                    await _baseEv.Update(currentEvaluation);

                    currentCampaign.Status = 3;
                    currentCampaign.IsResetT1 = true;
                    await _baseCampaign.Update(currentCampaign);

                    await unitOfWork.Commit();
                }


            }

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                MessageError = new List<string>() { "La campaña se reinicio correcta." }

            };


        }
    }
}
