using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.EvaluationPostulant.Models;
using HumanManagement.Domain.InformationPostulant.Models;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.MasterTable.Contracts;
using HumanManagement.Domain.Postulant.Languages.Contracts;
using HumanManagement.Domain.Postulant.Person.Contracts;
using HumanManagement.Domain.Postulant.Person.Dto;

using HumanManagement.Domain.Postulant.WorkExperience.Contracts;

using MediatR;

using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;

using System.Threading;
using System.Threading.Tasks;
using EvaluationModel = HumanManagement.Domain.EvaluationPostulant.Models.Evaluation;
using CargoModel = HumanManagement.Domain.Cargo.Models.Cargo;
using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Utils.Dto;
using System.Globalization;
using System.Text.RegularExpressions;

namespace HumanManagement.Application.EvaluationPostulants.Command
{
    public class UpdateEvaluationPostulantCommand: IRequest<Result>
    {

        public EvaluationPostulantDto dto;
        public List<FactorDto> factorDtos { get; set; } 
    }

    public class UpdateEvaluationPostulantCommandHandler : IRequestHandler<UpdateEvaluationPostulantCommand, Result>
    {
        private readonly IBaseRepository<EvaluationPostulant> baseRepository;
        private readonly IBaseRepository<CargoModel> cargobaseRepository;
        private readonly IBaseRepository<EvaluationModel> evaluationbaseRepository;
        private readonly IBaseRepository<Job> jobbaseRepository;
        private readonly IPersonRepository personbaseRepository;
        private readonly IMapper mapper;
        private readonly IMailRepository mailRepository;
        private readonly AppSettings _appSettings;
        private readonly IMasterTableRepository masterTableRepository;
        private readonly IBaseRepository<InformationFamilyModel> FamilybaseRepository;
        private readonly IBaseRepository<InformationEducationModel> EducationbaseRepository;
        private readonly IBaseRepository<InformationWorkModel> WorkbaseRepository;
        private readonly IBaseRepository<InformationLangModel> LangbaseRepository;
        private readonly IBaseRepository<InformationComputerSkillsModel> SkillsbaseRepository;
        private readonly ILanguagesPostulantRepository languagesPostulantRepository;
        private readonly IWorkExperienceRepository workExperienceRepository;
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
        private readonly IBaseRepository<EmployeeModel> employeebaseRepository;
        private readonly ICargoRepository cargoRepository;
        private readonly IBaseRepository<EvaluationMultitestExtern> multitestBaseRepository;


        public UpdateEvaluationPostulantCommandHandler(IBaseRepository<EvaluationPostulant> baseRepository,
                                                       IBaseRepository<CargoModel> cargobaseRepository,
                                                       IBaseRepository<EvaluationModel> evaluationbaseRepository,
                                                       IBaseRepository<Job> jobbaseRepository,
                                                       IMapper mapper,
                                                       IOptions<AppSettings> appSettings,
                                                       IMailRepository mailRepository,
                                                       IPersonRepository personbaseRepository,
                                                       IMasterTableRepository masterTableRepository,
                                                       IBaseRepository<InformationFamilyModel> FamilybaseRepository,
                                                       IBaseRepository<InformationEducationModel> EducationbaseRepository,
                                                       IBaseRepository<InformationWorkModel> WorkbaseRepository,
                                                       ILanguagesPostulantRepository languagesPostulantRepository,
                                                       IBaseRepository<InformationLangModel> LangbaseRepository,
                                                       IWorkExperienceRepository workExperienceRepository,
                                                       IBaseRepository<InformationComputerSkillsModel> SkillsbaseRepository,
                                                       IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification,
                                                       IBaseRepository<EmployeeModel> employeebaseRepository,
                                                       ICargoRepository cargoRepository,
                                                       IBaseRepository<EvaluationMultitestExtern> multitestBaseRepository)
        {
            this.baseRepository = baseRepository;
            this.cargobaseRepository = cargobaseRepository;
            this.evaluationbaseRepository = evaluationbaseRepository; 
            this.jobbaseRepository = jobbaseRepository;
            this.mapper = mapper;
            this.personbaseRepository = personbaseRepository;
            this.mailRepository = mailRepository;
            this._appSettings = appSettings.Value;
            this.masterTableRepository = masterTableRepository;
            this.FamilybaseRepository = FamilybaseRepository;
            this.EducationbaseRepository = EducationbaseRepository;
            this.WorkbaseRepository = WorkbaseRepository;
            this.languagesPostulantRepository = languagesPostulantRepository;
            this.LangbaseRepository = LangbaseRepository;
            this.workExperienceRepository = workExperienceRepository;
            this.SkillsbaseRepository = SkillsbaseRepository;
            this._baseNotification = _baseNotification;
            this.employeebaseRepository = employeebaseRepository;
            this.cargoRepository = cargoRepository;
            this.multitestBaseRepository = multitestBaseRepository;
        }
        public async Task<Result> Handle(UpdateEvaluationPostulantCommand request, CancellationToken cancellationToken)
        {
            if (request.factorDtos.Count > 0 && request.factorDtos != null)
            {
                var entityMulti = new EvaluationMultitestExtern
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

            var entity = mapper.Map<EvaluationPostulant>(request.dto);

            await baseRepository.Update(entity);
            var person = await personbaseRepository.GetPerson(entity.IdPostulant);
            var evaluation = await evaluationbaseRepository.FindPredicate(x => x.Id == entity.IdEvaluation);
            var job = await jobbaseRepository.FindPredicate(x => x.Id_Job == evaluation.IdJob);
            var applicant = await employeebaseRepository.FindPredicate(x => x.Id == job.IdApplicant);
            var area = await cargobaseRepository.FindPredicate(x => x.Id == applicant.IdPosition);

            /* jefe */
            var idjefe = await cargoRepository.GetJefeByCharge(job.IdCharge);
            var listMails = await cargoRepository.GetMailsByEvaluation(entity.Id);
            EmployeeModel jefe = null;
            CargoModel areaJefe = null;
            if (idjefe != 0)
            {
                jefe = await employeebaseRepository.FindPredicate(x => x.Id == idjefe);
                if (jefe != null)
                {
                    areaJefe = await cargobaseRepository.FindPredicate(x => x.Id == jefe.IdPosition);
                }
            }
            
            string proceso = "";
            switch (entity.State)
            {
                case 908:
                    proceso = "El postulante " + string.Format(person.FirstName + " " + person.LastName) + " ha pasado a la primera fase del proceso de selección";
                    break;

                case 909:
                    proceso = "El postulante " + string.Format(person.FirstName + " " + person.LastName) + " ha pasado a la segunda fase del proceso de selección";
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                    string fmt = File.ReadAllText(_appSettings.EvalExternNotiForEvaluadorTemplateHtml);

                    fmt = fmt.Replace("[EVALUATEDNAME]", string.Format(person.FirstName + " " + person.LastName));
                    fmt = fmt.Replace("[URLEVALUATION]", _appSettings.UrlEvaluationExtern + "/" + entity.Id);


                    newNotification.IdArea = job.Id_Area;
                    newNotification.IdPerson = _appSettings.IdPersonRRHH;
                    if (listMails != null)
                    {
                        newNotification.IdReceptor = listMails.Count > 0 ? listMails[0].IdPerson : applicant.IdPerson;
                    } else newNotification.IdReceptor = applicant.IdPerson;
                    newNotification.Subject = "Evaluacion de personal externo";
                    newNotification.Body = fmt;
                    newNotification.SendDate = DateTime.Now;
                    newNotification.Active = true;

                    newNotification.Important = true;
                    newNotification.Favorite = true;

                    await _baseNotification.Add(newNotification);

                    var mailRequestNoti = new MailRequestDto
                    {
                        Message = new MessageDto
                        {
                            Body = new BodyDto
                            {
                                Format = EnumBodyMail.Html,
                                Value = fmt
                            },
                            Subject = "Proceso de Evaluación de Personal Externo"
                        },
                        From = _appSettings.FromMailNotification,
                        FromName = _appSettings.FromNameNotification,
                        Cc = null
                    };
                    mailRequestNoti.To = new List<String>();
                    foreach(var _objMail in listMails)
                    {
                        if (IsValidEmail(_objMail.EmailUser))
                        {
                            mailRequestNoti.To.Add(_objMail.EmailUser);
                        }
                    }
                    if (mailRequestNoti.To.Count > 0)
                    {
                        bool respuestamail = await SendMailNotification(mailRequestNoti);
                    }
                    break;

                case 910:
                    proceso = "El postulante " + string.Format(person.FirstName + " " + person.LastName) + " ha pasado a la tercera fase del proceso de selección";
                    if (jefe != null)
                    {
                        Domain.Notification.Model.NotificationModel newNotification2 = new Domain.Notification.Model.NotificationModel();

                        string fmt2 = File.ReadAllText(_appSettings.EvalExternNotiForEvaluadorTemplateHtml);

                        fmt2 = fmt2.Replace("[EVALUATEDNAME]", string.Format(person.FirstName + " " + person.LastName));
                        fmt2 = fmt2.Replace("[URLEVALUATION]", _appSettings.UrlEvaluationExtern + "/" + entity.Id);


                        newNotification2.IdArea = job.Id_Area;
                        newNotification2.IdPerson = _appSettings.IdPersonRRHH;
                        if (listMails != null)
                        {
                            newNotification2.IdReceptor = listMails.Count > 0 ? listMails[0].IdPerson : applicant.IdPerson;
                        }
                        else newNotification2.IdReceptor = applicant.IdPerson;
                        newNotification2.Subject = "Evaluacion de personal externo";
                        newNotification2.Body = fmt2;
                        newNotification2.SendDate = DateTime.Now;
                        newNotification2.Active = true;

                        newNotification2.Important = true;
                        newNotification2.Favorite = true;

                        await _baseNotification.Add(newNotification2);

                        var mailRequestNoti2 = new MailRequestDto
                        {
                            Message = new MessageDto
                            {
                                Body = new BodyDto
                                {
                                    Format = EnumBodyMail.Html,
                                    Value = fmt2
                                },
                                Subject = "Proceso de Evaluación de Personal Externo"
                            },
                            From = _appSettings.FromMailNotification,
                            FromName = _appSettings.FromNameNotification,
                            Cc = null
                        };
                        mailRequestNoti2.To = new List<String>();
                        foreach (var _objMail in listMails)
                        {
                            if (IsValidEmail(_objMail.EmailUser))
                            {
                                mailRequestNoti2.To.Add(_objMail.EmailUser);
                            }
                        }
                        if (mailRequestNoti2.To.Count > 0)
                        {
                            bool respuestamail = await SendMailNotification(mailRequestNoti2);
                        }
                    }   
                    break;
                case 965:
                
                    break;
                case 911:
                    await GenerateTablesInformation(entity);
                    await SendMailPostulantSelected(person, job.Id_Company, evaluation.Id);
                    proceso = "El postulante " + string.Format(person.FirstName + " " + person.LastName) + " ha sido seleccionado al puesto requerido";
                    evaluation.State = 905;
                    await evaluationbaseRepository.UpdatePartial(evaluation, x => x.State);
                    break;
                case 912:
                    proceso = "El postulante " + string.Format(person.FirstName + " " + person.LastName) + " no continuará en el proceso de selección";
                    break;

            }

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = entity
            };
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

        public async Task<bool> GenerateTablesInformation(EvaluationPostulant entity)
        {
            int[] works = new int[] { 1,2,3};

            

            foreach (var item in works)
            {
                var entityWork = new InformationWorkModel
                {
                    Id = 0,
                    IdPostulant = entity.IdPostulant,
                };

                await WorkbaseRepository.Add(entityWork);             
            }

            return true;

        }

        public async Task<bool> SendMailNotification(MailRequestDto mailRequestDto)
        {
            return await mailRepository.SendMail(mailRequestDto);
        }

        public async Task<bool> SendMailPostulantSelected(PersonDto person, int? idCompany, int idEvaluation)
        {
         
            string url_background_image = _appSettings.PostulantSelectedExternaBackground;
            var arrayColorDiv = _appSettings.PostulantSelectedExternaColorDiv.Split(',');
            var arrayColorButton = _appSettings.PostulantSelectedExternaColorButton.Split(',');
            string color_div = string.Empty;
            string color_button = string.Empty;
            
            switch(idCompany)
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

            string template = await File.ReadAllTextAsync(_appSettings.PostulantSelectedExternaTemplateHtml);
            template = template.Replace("[COLOR_DIV]", color_div);
            template = template.Replace("[COLOR_BUTTON]", color_button);
            template = template.Replace("[BACKGROUND-IMAGE]", url_background_image);
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            template = template.Replace("[SELECCIONADO]", textInfo.ToTitleCase(person.FirstName)); 
            template = template.Replace("[USUARIO]", string.Format("{0}_{1}", Regex.Replace(person.FirstName.ToLower().Trim(), @"\s", ""), Regex.Replace(person.LastName.ToLower().Trim(), @"\s", "")));
            template = template.Replace("[PASSWORD]", string.Concat(person.DocumentNumber));
            
            template = template.Replace("[URL]", string.Format(_appSettings.UrlFichaDatosPostulante, person.Id, idEvaluation));
            template = template.Replace("[RUTA_INDUCCION]", _appSettings.PostulantSelectedExternaUrlInduccion);

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
                    person.Email
                },
                Cc = null
            };

            var result = await mailRepository.SendMail(mailRequest);

            return result;
        }
    }
}
