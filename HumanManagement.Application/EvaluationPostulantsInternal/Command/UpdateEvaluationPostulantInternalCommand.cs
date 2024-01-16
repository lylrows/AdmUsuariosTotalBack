using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.Mof.Contracts;
using HumanManagement.Domain.Person.Contracts;
using HumanManagement.Domain.Person.Dto;
using MediatR;

using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;

using System.Threading;
using System.Threading.Tasks;
using EvaluationPostulantsInternalModel = HumanManagement.Domain.EvaluationPostulantInternal.Models.EvaluationPostulantsInternal;
using CargoModel = HumanManagement.Domain.Cargo.Models.Cargo;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Utils.Dto;

using System.Globalization;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Command
{
    public class UpdateEvaluationPostulantInternalCommand: IRequest<Result> 
    {
        public EvaluationPostulantDto dto;
        public List<FactorDto> factorDtos { get; set; }
    }

    public class UpdateEvaluationPostulantInternalCommandHandle : IRequestHandler<UpdateEvaluationPostulantInternalCommand, Result>
    {
        private readonly IBaseRepository<CargoModel> cargobaseRepository;
        private readonly IBaseRepository<EvaluationVacantInternal> evaluationbaseRepository;
        private readonly IBaseRepository<JobOffersInternal> jobbaseRepository;
        private readonly IBaseRepository<EvaluationPostulantsInternalModel> evalutionPostulantBaseRepository;
        private readonly IBaseRepository<EmployeeModel> employeeBaseRepository;
        private readonly IBaseRepository<EvaluationProficiencyIntern> baseRepositoryEvaluationProficiency;
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
        private readonly IPersonRepository personbaseRepository;
        private readonly IMailRepository mailRepository;
        private readonly IMofRepository mofRepository;
        private readonly IMapper mapper;
        private readonly AppSettings _appSettings;
        private readonly ICargoRepository cargoRepository;
        private readonly IBaseRepository<EvaluationMultitestIntern> multitestBaseRepository;

        public UpdateEvaluationPostulantInternalCommandHandle(IBaseRepository<EvaluationPostulantsInternalModel> evalutionPostulantBaseRepository,
                                                               IBaseRepository<CargoModel> cargobaseRepository,
                                                               IBaseRepository<EvaluationVacantInternal> evaluationbaseRepository,
                                                               IBaseRepository<JobOffersInternal> jobbaseRepository,
                                                               IMapper mapper,
                                                               IBaseRepository<EmployeeModel> employeeBaseRepository,
                                                               IBaseRepository<EvaluationProficiencyIntern> baseRepositoryEvaluationProficiency,
                                                               IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification,
                                                               IPersonRepository personbaseRepository,
                                                               IMofRepository mofRepository,
                                                               IMailRepository mailRepository,
                                                               IOptions<AppSettings> appSettings,
                                                               ICargoRepository cargoRepository,
                                                               IBaseRepository<EvaluationMultitestIntern> multitestBaseRepository)
        {
            this.cargobaseRepository = cargobaseRepository;
            this.evaluationbaseRepository = evaluationbaseRepository;
            this.jobbaseRepository = jobbaseRepository;
            this.evalutionPostulantBaseRepository = evalutionPostulantBaseRepository;
            this.employeeBaseRepository = employeeBaseRepository;
            this.baseRepositoryEvaluationProficiency = baseRepositoryEvaluationProficiency;
            this.personbaseRepository = personbaseRepository;
            this.mofRepository = mofRepository;
            this.mailRepository = mailRepository;
            this.mapper = mapper;
            this._appSettings = appSettings.Value;
            this._baseNotification = _baseNotification;
            this.cargoRepository = cargoRepository;
            this.multitestBaseRepository = multitestBaseRepository;
        }
        public async Task<Result> Handle(UpdateEvaluationPostulantInternalCommand request, CancellationToken cancellationToken)
        {
            if (request.factorDtos.Count > 0 && request.factorDtos != null)
            {
                var entityMulti = new EvaluationMultitestIntern 
                {
                    IdPostulant = request.dto.IdPostulant,
                    IdEvaluation = (int)request.dto.IdEvaluation,
                    ScoreIntelligence = request.factorDtos[0].Score,
                    ScoreAptitudVerbal = request.factorDtos[1].Score,
                    ScoreAptitudNumerica = request.factorDtos[2].Score,
                    ScoreAptitudEspacial = request.factorDtos[3].Score,
                    ScoreAptitudAbstracta = request.factorDtos[4].Score
                };
                await multitestBaseRepository.Add(entityMulti);
            }

            var entity = mapper.Map<EvaluationPostulantsInternalModel>(request.dto);
            var evaluation = await evaluationbaseRepository.FindPredicate(x => x.Id == entity.IdEvaluation);
            var job = await jobbaseRepository.FindPredicate(x => x.Id_Job == evaluation.IdJob);
            
            var idjefe = await cargoRepository.GetJefeByCharge(job.IdCharge);
            var listMails = await cargoRepository.GetMailsByEvaluationInternal(entity.Id);
            EmployeeModel jefe = null;
            CargoModel areaJefe = null;
            if (idjefe != 0)
            {
                jefe = await employeeBaseRepository.FindPredicate(x => x.Id == idjefe);
                if (jefe != null)
                {
                    areaJefe = await cargobaseRepository.FindPredicate(x => x.Id == jefe.IdPosition);
                }
            }

            await evalutionPostulantBaseRepository.Update(entity); 


            var person = await personbaseRepository.GetPerson(entity.IdPostulant);
            
            var _enviarMailNotification = true;
            var _asunto = string.Empty;

            string proceso = "";
            switch (entity.State)
            {
                case 908:
                    proceso = "El postulante " + string.Format(person.sfirstname + " " + person.slastname) + " ha pasado a la primera fase del proceso de selección";
                    break;

                case 909:
                    proceso = "El postulante " + string.Format(person.sfirstname + " " + person.slastname) + " ha pasado a la segunda fase del proceso de selección";
                    break;

                case 910:
                    proceso = "El postulante " + string.Format(person.sfirstname + " " + person.slastname) + " ha pasado a la tercera fase del proceso de selección";
                   

                    break;
                case 956:
                    proceso = "El postulante " + string.Format(person.sfirstname + " " + person.slastname) + " ha pasado a la cuarta fase del proceso de selección";
                   
                    break;
                case 965:
                    proceso = "El postulante " + string.Format(person.sfirstname + " " + person.slastname) + " ha pasado a la ultima fase del proceso de selección";
                    break;
                case 911:
                    await SendMailPostulantSelected(person, job.Id_Company, evaluation.Id, job.Title);
                    _enviarMailNotification = false;
                   
                    evaluation.State = 905;
                    await evaluationbaseRepository.UpdatePartial(evaluation, x => x.State);
                    proceso = "El postulante " + string.Format(person.sfirstname + " " + person.slastname) + " ha sido seleccionado al puesto requerido";
                    break;
                case 912:
                    proceso = "El postulante " + string.Format(person.sfirstname + " " + person.slastname) + " no continuara en el proceso de selección";
                    break;
            }
            if (_enviarMailNotification)
            {
              
                Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                string fmt = File.ReadAllText(_appSettings.EvalInternNotiForEvaluadorTemplateHtml);

                fmt = fmt.Replace("[EVALUATEDNAME]", string.Format(person.sfirstname + " " + person.sfirstname));
                fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluationIntern + "/" + entity.Id);

                newNotification.IdArea = job.Id_Area;
                newNotification.IdPerson = _appSettings.IdPersonRRHH;
                if (listMails != null)
                {
                    newNotification.IdReceptor = listMails.Count > 0 ? listMails[0].IdPerson : _appSettings.IdPersonRRHH;
                }
                else newNotification.IdReceptor = _appSettings.IdPersonRRHH;
                newNotification.Subject = "Evaluacion de personal interno";
                newNotification.Body = fmt;
                newNotification.SendDate = DateTime.Now;
                newNotification.Active = true;

                newNotification.Important = true;
                newNotification.Favorite = true;
                try
                {
                    await _baseNotification.Add(newNotification);
                }
                catch (Exception ex)
                {
                  
                }

              
                var mailRequest = new MailRequestDto
                {
                    Message = new MessageDto
                    {
                        Body = new BodyDto
                        {
                            Format = EnumBodyMail.Html,
                            Value = fmt
                        },
                        Subject = "Proceso de Evaluación de Personal Interno"
                    },
                    From = _appSettings.FromMailNotification,
                    FromName = _appSettings.FromNameNotification,
                    Cc = null
                };
                mailRequest.To = new List<String>();
                foreach (var _objMail in listMails)
                {
                    if (IsValidEmail(_objMail.EmailUser))
                    {
                        mailRequest.To.Add(_objMail.EmailUser);
                    }
                }
                if (mailRequest.To.Count > 0)
                {
                    bool respuestamail2 = await SendMailNotification(mailRequest);
                }
            }

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = entity
            };
        }

        public async Task<bool> SendMailNotification(MailRequestDto mailRequestDto)
        {
            return await mailRepository.SendMail(mailRequestDto);
        }

        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

     
        public async Task<bool> SendMailPostulantSelected(PersonDto person, int? idCompany, int idEvaluation, string nombre_puesto)
        {
     
            string url_background_image = _appSettings.PostulantSelectedInternaBackground;
            var arrayColorDiv = _appSettings.PostulantSelectedInternaColorDiv.Split(',');
            var arrayColorButton = _appSettings.PostulantSelectedInternaColorButton.Split(',');
            string color_div = string.Empty;
            string color_button = string.Empty;

            switch (idCompany)
            {
                case 1:
                    url_background_image = string.Format(url_background_image, "CampoFe");
                    color_div = arrayColorDiv[0];
                    color_button = arrayColorButton[0];
                    break;
                case 2:
                    url_background_image = string.Format(url_background_image, "PrestaFe");
                    color_div = arrayColorDiv[1];
                    color_button = arrayColorButton[1];
                    break;
                case 3:
                    url_background_image = string.Format(url_background_image, "FeSalud");
                    color_div = arrayColorDiv[2];
                    color_button = arrayColorButton[2];
                    break;
                case 4:
                    url_background_image = string.Format(url_background_image, "GrupoFe");
                    color_div = arrayColorDiv[3];
                    color_button = arrayColorButton[3];
                    break;
            }

            string template = await File.ReadAllTextAsync(_appSettings.PostulantSelectedInternaTemplateHtml);
            template = template.Replace("[COLOR_DIV]", color_div);
            template = template.Replace("[COLOR_BUTTON]", color_button);
            template = template.Replace("[BACKGROUND-IMAGE]", url_background_image);
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            template = template.Replace("[SELECCIONADO]", textInfo.ToTitleCase(person.sfirstname));
            template = template.Replace("[USUARIO]", string.Format("{0}_{1}", person.sfirstname.ToLower(), person.slastname.ToLower()));
            template = template.Replace("[PASSWORD]", string.Concat(person.scodperson));
            template = template.Replace("[NOMBRE_PUESTO]", nombre_puesto);
            template = template.Replace("[URL]", "");
            template = template.Replace("[RUTA_INDUCCION]", _appSettings.PostulantSelectedInternaUrlInduccion);

            var mailRequest = new MailRequestDto
            {
                Message = new MessageDto
                {
                    Body = new BodyDto
                    {
                        Format = EnumBodyMail.Html,
                        Value = template
                    },
                    Subject = "Proceso de Selección Grupo Fe"
                },
                From = _appSettings.FromMailNotification,
                FromName = _appSettings.FromNameNotification,
                To =
                {
                    person.semail
                },
                Cc = null
            };

            var result = await mailRepository.SendMail(mailRequest);

            return result;
        }
    }
}
