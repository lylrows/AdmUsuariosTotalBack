using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Evaluation.Contracts;
using HumanManagement.Domain.Evaluation.Dto;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.Security.Contracts;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Evaluation.Update
{
    public class UpdateEvaluationCommand : IRequest<Result>
    {
        public UpdateEvaluationDetailDto saveEvaluationDetail { get; set; }
        public int IdUser { get; set; }
    }

    public class UpdateEvaluationCommandHandler : IRequestHandler<UpdateEvaluationCommand, Result>
    {
        private readonly IBaseRepository<Domain.Evaluation.Models.EvaluationDetail> _baseEvDetail;
        private readonly IBaseRepository<Domain.Evaluation.Models.Evaluation> _baseEv;
        private readonly IEvaluationRepository _evrepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
        private readonly AppSettings _appSettings;
        private readonly ICampaignRepository campaignRepository;
        private readonly IMailRepository _mailRepository;


        public UpdateEvaluationCommandHandler(IBaseRepository<Domain.Evaluation.Models.EvaluationDetail> baseEvDetail,
                                    IUnitOfWork unitOfWork,
                                    IEvaluationRepository evrepository,
                                    IUserRepository userRepository,
                                    IBaseRepository<Domain.Evaluation.Models.Evaluation> baseEv,
                                    IBaseRepository<Domain.Notification.Model.NotificationModel> baseNotification,
                                    IOptions<AppSettings> appSettings,
                                    ICampaignRepository campaignRepository,
                                    IMailRepository mailRepository
            )
        {
            this._baseEvDetail = baseEvDetail;
            this.unitOfWork = unitOfWork;
            this._userRepository = userRepository;
            this._evrepository = evrepository;
            this._baseEv = baseEv;
            this._baseNotification = baseNotification;
            _appSettings = appSettings.Value;
            this.campaignRepository = campaignRepository;
            _mailRepository = mailRepository;
        }

        public async Task<Result> Handle(UpdateEvaluationCommand request, CancellationToken cancellationToken)
        {
            var header = await _evrepository.GetEvaluationById(request.saveEvaluationDetail.IdEvaluation);

            var campaign = await campaignRepository.FindCampaignById(header.IdCampaign);

            var userEvaluated = await _userRepository.GetUserByEmployeeId(header.IdEvaluated);
            var userEvaluator = await _userRepository.GetUserByEmployeeId(header.IdEvaluator ?? 0);

            #region Ternminar Edicion

            if (request.saveEvaluationDetail.IsCompleted)
            {
                

                #region Pasar a la siguiente Etapa

                #region Tiempo-0  (T-0)

                if (header.TimePart == 0 && (header.NumberAction == 0 || header.NumberAction == 1))
                {
                    #region Registrar Nuevos detalles 

                    foreach (var ev_det in request.saveEvaluationDetail.list_detail)
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
                            newEvalDetail.NumberOfAction = ev_det_db.NumberOfAction + 1;
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
                            newEvalDetail.Progress = ev_det.Progress;
                            await _baseEvDetail.Add(newEvalDetail);
                        }
                    }

                    #endregion

                    #region Actualizar Evaluación


                    var currentEvaluation = await _baseEv.Find(request.saveEvaluationDetail.IdEvaluation);

                    if (currentEvaluation == null)
                    {
                        return new Result
                        {
                            StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                            MessageError = new List<string>() { "No se encontró la campaña." }
                        };
                    }

                    currentEvaluation.NumberAction = 2;
                    currentEvaluation.DateUpdate = DateTime.Now;
                    currentEvaluation.IdUserUpdate = request.IdUser;

                    await _baseEv.Update(currentEvaluation);

                    #endregion

                    #region Notificar al Evaluador

                    if (userEvaluator != null)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                        string fmt = File.ReadAllText(_appSettings.EvalNotiForEvaluatorTemplateHtml);

                        fmt = fmt.Replace("[EVALUATORNAME]", userEvaluator.FirstName);
                        fmt = fmt.Replace("[EVALUATEDNAME]", userEvaluated.FirstName + " " + userEvaluated.LastName);
                        fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluation + "/" + header.IdEvaluation);
                        fmt = fmt.Replace("[CAMPAIGNNAME]", campaign.NameCampaign);


                        newNotification.IdArea = userEvaluator.IdArea;
                        newNotification.IdPerson = _appSettings.IdPersonRRHH;
                        newNotification.IdReceptor = userEvaluator.IdPerson;
                        newNotification.Subject = campaign.NameCampaign;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);

                    }
                    #endregion

                }
  
                else if (header.TimePart == 0 && (header.NumberAction == 2 ))
                {
                   
                    #region Registrar Nuevos detalles 

                    foreach (var ev_det in request.saveEvaluationDetail.list_detail)
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
                            newEvalDetail.NumberOfAction = ev_det_db.NumberOfAction +1;
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
                            newEvalDetail.Progress = ev_det.Progress;
                            await _baseEvDetail.Add(newEvalDetail);

                            newEvalDetail.IdEvaluationDetail = 0;
                            newEvalDetail.NumberOfAction = ev_det_db.NumberOfAction + 2;

                            await _baseEvDetail.Add(newEvalDetail);
                        }
                    }

                    #endregion

                    #region Actualizar Evaluacion

                    var currentEvaluation = await _baseEv.Find(request.saveEvaluationDetail.IdEvaluation);

                    if (currentEvaluation == null)
                    {
                        return new Result
                        {
                            StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                            MessageError = new List<string>() { "No se encontró la campaña." }
                        };
                    }

                    currentEvaluation.NumberAction = header.NumberAction + 2;

                    
                    if (header.NumberAction == 2)
                    {
                        currentEvaluation.PendingApproval = true;
                        currentEvaluation.IsApproved0 = false;
                        currentEvaluation.IsApproved2 = false;
                        currentEvaluation.Observation0 = string.Empty;
                        currentEvaluation.Observation2 = string.Empty;
                    }


                    currentEvaluation.DateUpdate = DateTime.Now;
                    currentEvaluation.IdUserUpdate = request.IdUser;

                    await _baseEv.Update(currentEvaluation);
                    #endregion

                    #region Notificar al Evaluado

                    if (userEvaluator != null)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                        string fmt = File.ReadAllText(_appSettings.EvalNotiForEvaluatedTemplateHtml);


                        fmt = fmt.Replace("[EVALUATEDNAME]", userEvaluated.FirstName);
                        fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluation + "/" + header.IdEvaluation);
                        fmt = fmt.Replace("[CAMPAIGNNAME]", campaign.NameCampaign);

                        


                        newNotification.IdArea = userEvaluated.IdArea;
                        newNotification.IdPerson = _appSettings.IdPersonRRHH;
                        newNotification.IdReceptor = userEvaluated.IdPerson;
                        newNotification.Subject = campaign.NameCampaign;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);
                      
                    }
                    #endregion


                }
                else if (header.TimePart == 0 && (header.NumberAction == 4 && request.saveEvaluationDetail.IsApproved))
                {
                    #region Actualizar Evaluación


                    var currentEvaluation = await _baseEv.Find(request.saveEvaluationDetail.IdEvaluation);

                    if (currentEvaluation == null)
                    {
                        return new Result
                        {
                            StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                            MessageError = new List<string>() { "No se encontró la campaña." }
                        };
                    }

                    currentEvaluation.PendingApproval = false;
                    currentEvaluation.IsApproved0 = true;
                    if (!string.IsNullOrEmpty(request.saveEvaluationDetail.Observation))
                    {
                        currentEvaluation.Observation0 = request.saveEvaluationDetail.Observation;
                    }
                    currentEvaluation.TimePart = 1;




                    currentEvaluation.DateUpdate = DateTime.Now;
                    currentEvaluation.IdUserUpdate = request.IdUser;

                    await _baseEv.Update(currentEvaluation);
                    #endregion

                    #region Notificar al Evaluador

                    if (userEvaluator != null)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                        string fmt = File.ReadAllText(_appSettings.EvalNotiForEvaluatorTemplateHtml);

                        fmt = fmt.Replace("[EVALUATORNAME]", userEvaluator.FirstName);
                        fmt = fmt.Replace("[EVALUATEDNAME]", userEvaluated.FirstName + " " + userEvaluated.LastName);
                        fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluation + "/" + header.IdEvaluation);
                        fmt = fmt.Replace("[CAMPAIGNNAME]", campaign.NameCampaign);


                        newNotification.IdArea = userEvaluator.IdArea;
                        newNotification.IdPerson = _appSettings.IdPersonRRHH;
                        newNotification.IdReceptor = userEvaluator.IdPerson;
                        newNotification.Subject = campaign.NameCampaign;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);

                    }
                    #endregion
                }

                #endregion

                #region Tiempo-1 (T-1)

                if (header.TimePart == 1 && header.NumberAction == 5)
                {
                   
                    #region Registrar Nuevos detalles 

                    foreach (var ev_det in request.saveEvaluationDetail.list_detail)
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
                            newEvalDetail.NumberOfAction = ev_det_db.NumberOfAction + 1;
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
                            newEvalDetail.Progress = ev_det.Progress;
                            await _baseEvDetail.Add(newEvalDetail);

                            newEvalDetail.IdEvaluationDetail = 0;
                            newEvalDetail.NumberOfAction = ev_det_db.NumberOfAction + 2;

                            await _baseEvDetail.Add(newEvalDetail);
                        }
                    }

                    #endregion

                    #region Actualizar Evaluacion

                    var currentEvaluation = await _baseEv.Find(request.saveEvaluationDetail.IdEvaluation);

                    if (currentEvaluation == null)
                    {
                        return new Result
                        {
                            StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                            MessageError = new List<string>() { "No se encontró la campaña." }
                        };
                    }

                    currentEvaluation.NumberAction = header.NumberAction + 2;
                    
                    currentEvaluation.PendingApproval = true;
                    currentEvaluation.Approved1 = false;
                    currentEvaluation.DateUpdate = DateTime.Now;
                    currentEvaluation.IdUserUpdate = request.IdUser;

                    await _baseEv.Update(currentEvaluation);
                    #endregion

                    #region Notificar al Evaluado

                    if (userEvaluator != null)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                        string fmt = File.ReadAllText(_appSettings.EvalNotiForEvaluatedTemplateHtml);


                        fmt = fmt.Replace("[EVALUATEDNAME]", userEvaluated.FirstName);
                        fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluation + "/" + header.IdEvaluation);
                        fmt = fmt.Replace("[CAMPAIGNNAME]", campaign.NameCampaign);


                        newNotification.IdArea = userEvaluated.IdArea;
                        newNotification.IdPerson = _appSettings.IdPersonRRHH;
                        newNotification.IdReceptor = userEvaluated.IdPerson;
                        newNotification.Subject = campaign.NameCampaign;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);

                        
                    }
                    #endregion

                }

                if (header.TimePart == 1 && header.NumberAction == 6)
                {

                    #region Registrar Nuevos detalles 

                    foreach (var ev_det in request.saveEvaluationDetail.list_detail)
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
                            newEvalDetail.NumberOfAction = ev_det_db.NumberOfAction + 1;
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
                            newEvalDetail.Progress = ev_det.Progress;
                            await _baseEvDetail.Add(newEvalDetail);
                        }
                    }

                    #endregion

                    #region Actualizar Evaluacion

                    var currentEvaluation = await _baseEv.Find(request.saveEvaluationDetail.IdEvaluation);

                    if (currentEvaluation == null)
                    {
                        return new Result
                        {
                            StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                            MessageError = new List<string>() { "No se encontró la campaña." }
                        };
                    }

                    currentEvaluation.NumberAction = header.NumberAction + 1;
                    
                    currentEvaluation.PendingApproval = true;
                    currentEvaluation.Approved1 = false;
                    currentEvaluation.DateUpdate = DateTime.Now;
                    currentEvaluation.IdUserUpdate = request.IdUser;

                    await _baseEv.Update(currentEvaluation);
                    #endregion

                    #region Notificar al Evaluado

                    if (userEvaluator != null)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                        string fmt = File.ReadAllText(_appSettings.EvalNotiForEvaluatedTemplateHtml);


                        fmt = fmt.Replace("[EVALUATEDNAME]", userEvaluated.FirstName);
                        fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluation + "/" + header.IdEvaluation);
                        fmt = fmt.Replace("[CAMPAIGNNAME]", campaign.NameCampaign);


                        newNotification.IdArea = userEvaluated.IdArea;
                        newNotification.IdPerson = _appSettings.IdPersonRRHH;
                        newNotification.IdReceptor = userEvaluated.IdPerson;
                        newNotification.Subject = campaign.NameCampaign;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);

                    }
                    #endregion

                }

                if (header.TimePart == 1 && header.NumberAction == 7)
                {

                    #region Actualizar Evaluacion

                    var currentEvaluation = await _baseEv.Find(request.saveEvaluationDetail.IdEvaluation);

                    if (currentEvaluation == null)
                    {
                        return new Result
                        {
                            StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                            MessageError = new List<string>() { "No se encontró la campaña." }
                        };
                    }

                    currentEvaluation.TimePart = 2;
                    currentEvaluation.PendingApproval = false;
                    currentEvaluation.Approved1 = true;
                    currentEvaluation.DateUpdate = DateTime.Now;
                    currentEvaluation.IdUserUpdate = request.IdUser;

                    if (!string.IsNullOrEmpty(request.saveEvaluationDetail.Observation))
                    {
                        currentEvaluation.Observation1 = request.saveEvaluationDetail.Observation;
                    }

                    await _baseEv.Update(currentEvaluation);
                    #endregion

                    #region Notificar al Evaluador

                    if (userEvaluator != null)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                        string fmt = File.ReadAllText(_appSettings.EvalNotiForEvaluatorTemplateHtml);

                        fmt = fmt.Replace("[EVALUATORNAME]", userEvaluator.FirstName);
                        fmt = fmt.Replace("[EVALUATEDNAME]", userEvaluated.FirstName + " " + userEvaluated.LastName);
                        fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluation + "/" + header.IdEvaluation);
                        fmt = fmt.Replace("[CAMPAIGNNAME]", campaign.NameCampaign);


                        newNotification.IdArea = userEvaluator.IdArea;
                        newNotification.IdPerson = _appSettings.IdPersonRRHH;
                        newNotification.IdReceptor = userEvaluator.IdPerson;
                        newNotification.Subject = campaign.NameCampaign;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);

                    }
                    #endregion


                   

                }

                #endregion


                #region Tiempo-2 (T-2)

                if (header.TimePart == 2 && header.NumberAction == 8)
                {

                    #region Registrar Nuevos detalles 

                    foreach (var ev_det in request.saveEvaluationDetail.list_detail)
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
                            newEvalDetail.NumberOfAction = ev_det_db.NumberOfAction + 1;
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
                            newEvalDetail.Progress = ev_det.Progress;
                            await _baseEvDetail.Add(newEvalDetail);
                        }
                    }

                    #endregion

                    #region Actualizar Evaluación


                    var currentEvaluation = await _baseEv.Find(request.saveEvaluationDetail.IdEvaluation);

                    if (currentEvaluation == null)
                    {
                        return new Result
                        {
                            StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                            MessageError = new List<string>() { "No se encontró la campaña." }
                        };
                    }

                    currentEvaluation.NumberAction = currentEvaluation.NumberAction + 1;
                    currentEvaluation.DateUpdate = DateTime.Now;
                    currentEvaluation.IdUserUpdate = request.IdUser;

                    await _baseEv.Update(currentEvaluation);

                    #endregion

                    #region Notificar al Evaluador

                    if (userEvaluator != null)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                        string fmt = File.ReadAllText(_appSettings.EvalNotiForEvaluatorTemplateHtml);

                        fmt = fmt.Replace("[EVALUATORNAME]", userEvaluator.FirstName);
                        fmt = fmt.Replace("[EVALUATEDNAME]", userEvaluated.FirstName + " " + userEvaluated.LastName);
                        fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluation + "/" + header.IdEvaluation);
                        fmt = fmt.Replace("[CAMPAIGNNAME]", campaign.NameCampaign);


                        newNotification.IdArea = userEvaluator.IdArea;
                        newNotification.IdPerson = _appSettings.IdPersonRRHH;
                        newNotification.IdReceptor = userEvaluator.IdPerson;
                        newNotification.Subject = campaign.NameCampaign;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);

                    }
                    #endregion

                }
                else if (header.TimePart == 2 && header.NumberAction == 9)
                {
                    #region Registrar Nuevos detalles 

                    foreach (var ev_det in request.saveEvaluationDetail.list_detail)
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
                            newEvalDetail.NumberOfAction = ev_det_db.NumberOfAction + 1;
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
                            newEvalDetail.Progress = ev_det.Progress;
                            await _baseEvDetail.Add(newEvalDetail);
                        }
                    }

                    #endregion

                    #region Actualizar Evaluacion

                    var currentEvaluation = await _baseEv.Find(request.saveEvaluationDetail.IdEvaluation);

                    if (currentEvaluation == null)
                    {
                        return new Result
                        {
                            StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                            MessageError = new List<string>() { "No se encontró la campaña." }
                        };
                    }

                    currentEvaluation.NumberAction = header.NumberAction + 1;
                    currentEvaluation.DateUpdate = DateTime.Now;
                    currentEvaluation.IdUserUpdate = request.IdUser;

                    await _baseEv.Update(currentEvaluation);
                    #endregion

                    #region Notificar al Evaluado

                    if (userEvaluator != null)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                        string fmt = File.ReadAllText(_appSettings.EvalNotiForEvaluatedTemplateHtml);


                        fmt = fmt.Replace("[EVALUATEDNAME]", userEvaluated.FirstName);
                        fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluation + "/" + header.IdEvaluation);
                        fmt = fmt.Replace("[CAMPAIGNNAME]", campaign.NameCampaign);


                        newNotification.IdArea = userEvaluated.IdArea;
                        newNotification.IdPerson = _appSettings.IdPersonRRHH;
                        newNotification.IdReceptor = userEvaluated.IdPerson;
                        newNotification.Subject = campaign.NameCampaign;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);

                        
                    }
                    #endregion



                }
                else if ( header.TimePart == 2 && header.NumberAction == 10 )
                {
                    #region Registrar Nuevos detalles 

                    foreach (var ev_det in request.saveEvaluationDetail.list_detail)
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
                            newEvalDetail.NumberOfAction = ev_det_db.NumberOfAction + 1;
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
                            newEvalDetail.Progress = ev_det.Progress;
                            await _baseEvDetail.Add(newEvalDetail);
                        }
                    }

                    #endregion

                    #region Actualizar Evaluacion

                    var currentEvaluation = await _baseEv.Find(request.saveEvaluationDetail.IdEvaluation);

                    if (currentEvaluation == null)
                    {
                        return new Result
                        {
                            StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                            MessageError = new List<string>() { "No se encontró la campaña." }
                        };
                    }

                    currentEvaluation.PendingApproval = true;
                    currentEvaluation.IsApproved2 = false;
                    currentEvaluation.Observation2 = string.Empty;

                    currentEvaluation.NumberAction = header.NumberAction + 1;
                    currentEvaluation.DateUpdate = DateTime.Now;
                    currentEvaluation.IdUserUpdate = request.IdUser;

                    await _baseEv.Update(currentEvaluation);
                    #endregion

                    #region Notificar al Evaluado

                    if (userEvaluator != null)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                        string fmt = File.ReadAllText(_appSettings.EvalNotiForEvaluatedTemplateHtml);


                        fmt = fmt.Replace("[EVALUATEDNAME]", userEvaluated.FirstName);
                        fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluation + "/" + header.IdEvaluation);
                        fmt = fmt.Replace("[CAMPAIGNNAME]", campaign.NameCampaign);


                        newNotification.IdArea = userEvaluated.IdArea;
                        newNotification.IdPerson = _appSettings.IdPersonRRHH;
                        newNotification.IdReceptor = userEvaluated.IdPerson;
                        newNotification.Subject = campaign.NameCampaign;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);

                        
                    }
                    #endregion
                }
                else if ( header.TimePart == 2 && header.NumberAction == 11 )
                {
                    #region Actualizar Evaluación


                    var currentEvaluation = await _baseEv.Find(request.saveEvaluationDetail.IdEvaluation);

                    if (currentEvaluation == null)
                    {
                        return new Result
                        {
                            StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                            MessageError = new List<string>() { "No se encontró la campaña." }
                        };
                    }

                    currentEvaluation.PendingApproval = false;
                    currentEvaluation.IsApproved2 = true;
                    if (!string.IsNullOrEmpty(request.saveEvaluationDetail.Observation))
                    {
                        currentEvaluation.Observation2 = request.saveEvaluationDetail.Observation;
                    }
                    
                    currentEvaluation.DateUpdate = DateTime.Now;
                    currentEvaluation.IdUserUpdate = request.IdUser;

                    await _baseEv.Update(currentEvaluation);
                    #endregion

                    #region Notificar al Evaluador

                    if (userEvaluator != null)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                        string fmt = File.ReadAllText(_appSettings.EvalNotiForEvaluatorTemplateHtml);

                        fmt = fmt.Replace("[EVALUATORNAME]", userEvaluator.FirstName);
                        fmt = fmt.Replace("[EVALUATEDNAME]", userEvaluated.FirstName + " " + userEvaluated.LastName);
                        fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluation + "/" + header.IdEvaluation);
                        fmt = fmt.Replace("[CAMPAIGNNAME]", campaign.NameCampaign);


                        newNotification.IdArea = userEvaluator.IdArea;
                        newNotification.IdPerson = _appSettings.IdPersonRRHH;
                        newNotification.IdReceptor = userEvaluator.IdPerson;
                        newNotification.Subject = campaign.NameCampaign;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);

                    }
                    #endregion
                }

                #endregion


                #endregion
            }
            else
            {

                bool bInsert = false;

                if (header.TimePart == 2 && header.NumberAction == 5)
                {

                    var ev_det_db = await _baseEvDetail.Find( request.saveEvaluationDetail.list_detail[0].IdEvaluationDetail);
                    if (ev_det_db.NumberOfAction == 4)
                    {
                        bInsert = true;
                    }
                }

                if (bInsert)
                {
                    #region Guardar como nuevos registros

                    foreach (var ev_det in request.saveEvaluationDetail.list_detail)
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
                            newEvalDetail.NumberOfAction = ev_det_db.NumberOfAction + 1;
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
                            newEvalDetail.Progress = ev_det.Progress;
                            await _baseEvDetail.Add(newEvalDetail);
                        }
                    }

                    #endregion
                }
                else
                {
                    #region Actualizar Detalle 

                    foreach (var ev_det in request.saveEvaluationDetail.list_detail)
                    {

                        var ev_det_db = await _baseEvDetail.Find(ev_det.IdEvaluationDetail);

                        if (ev_det_db != null)
                        {

                            try
                            {
                                DateTime? dDateStart = null;
                                if (!string.IsNullOrEmpty(ev_det.StartDate))
                                    dDateStart = DateTime.Parse(ev_det.StartDate);

                                DateTime? dDateEnd = null;
                                if (!string.IsNullOrEmpty(ev_det.EndDate))
                                    dDateEnd = DateTime.Parse(ev_det.EndDate);

                                ev_det_db.Qualification = ev_det.Qualification;
                                ev_det_db.ActionsToImprove = ev_det.ActionsToImprove;
                                ev_det_db.Indicator = ev_det.Indicator;
                                ev_det_db.StartDate = dDateStart;
                                ev_det_db.EndDate = dDateEnd;
                                ev_det_db.JobObjectives = ev_det.JobObjectives;
                                ev_det_db.IndicatorOrganizational = ev_det.IndicatorOrganizational;
                                ev_det_db.Goal = ev_det.Goal;
                                ev_det_db.GoalString = ev_det.GoalString;


                                ev_det_db.Weight = ev_det.Weight;
                                ev_det_db.Progress = ev_det.Progress;
                                await _baseEvDetail.Update(ev_det_db);
                            }
                            catch (Exception ex )
                            {

                                throw;
                            }

                            
                        }
                    }

                    #endregion

                }





                #endregion
            }
 

            await unitOfWork.Commit();

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                MessageError = new List<string>() { "Se guardó la evaluación de manera correcta." }

            };

        }


        private async Task<bool> SendMailEvaluation(string mailuser, string bodyhtml, string campaignname)
        {
            MailRequestDto newMailRequest = new MailRequestDto();
            newMailRequest.From = _appSettings.FromMailNotification;
            newMailRequest.FromName = _appSettings.FromNameNotification;
            newMailRequest.To = new List<string>();
            newMailRequest.To.Add(mailuser);
            newMailRequest.Cc = new List<string>();
            newMailRequest.Cc.Add(_appSettings.MailRRHH);
            newMailRequest.Message = new MessageDto();
            newMailRequest.Message.Subject = campaignname;
            newMailRequest.Message.Body = new BodyDto() { Format = EnumBodyMail.Html, Value = bodyhtml };

            var bmail = await _mailRepository.SendMail(newMailRequest);
            return bmail;

        }
    }
}
