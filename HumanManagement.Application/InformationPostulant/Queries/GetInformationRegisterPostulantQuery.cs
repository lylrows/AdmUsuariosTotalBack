using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.InformationPostulant.Contracts;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.Domain.InformationPostulant.Models;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Postulant.Disability.Models;
using HumanManagement.Domain.Postulant.Education.Contracts;
using HumanManagement.Domain.Postulant.Languages.Contracts;
using HumanManagement.Domain.Postulant.WorkExperience.Contracts;
using HumanManagement.Domain.Utils.Constracts;
using HumanManagement.Domain.Postulant.Person.Contracts;
using HumanManagement.Domain.Utils.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EvaluationModel = HumanManagement.Domain.EvaluationPostulant.Models.Evaluation;

namespace HumanManagement.Application.InformationPostulant.Queries
{
    public class GetInformationRegisterPostulantQuery: IRequest<Result>
    {
        public int IdPerson { get; set; }
        public int IdEvaluation { get; set; }

        public class GetInformationRegisterPostulantQueryHandle : IRequestHandler<GetInformationRegisterPostulantQuery, Result>
        {
            private readonly IBaseRepository<InformationAditionalModel> baseRepositoryAdicional;
            private readonly IInformationEducationRepository informationEducationRepository;
            private readonly IInformationFamilyRepository informationFamilyRepository;
            
              private readonly IBaseRepository<InformationWorkModel> baseRepositoryWork;
              private readonly IBaseRepository<InformationLangModel> baseRepositoryLang;
              private readonly IBaseRepository<InformationComputerSkillsModel> baseRepositorySkills;
            
            private readonly IMapper mapper;
            private readonly IEducationPostulantRepository educationPostulantRepository;
            private readonly ILanguagesPostulantRepository languagePostulantRepository;
            private readonly IWorkExperienceRepository workExperienceRepository;
            private readonly IBaseRepository<InformationExtraModel> baseRepositoryExtra;
            private readonly IBaseRepository<EvaluationModel> evaluationbaseRepository;
            private readonly IBaseRepository<Job> jobbaseRepository;
            private readonly IBaseRepository<InformationEducationModel> baseRepositoryEducation;
            private readonly IUtilRepository _utilRepository;
            private readonly IBaseRepository<DisabilityModel> baseDisabilityRepository;
            private readonly IEmpresaRepository _empresaRepository;
            private readonly IPersonRepository _personRepository;
            public GetInformationRegisterPostulantQueryHandle(IInformationEducationRepository informationEducationRepository,
                IBaseRepository<InformationAditionalModel> baseRepositoryAdicional,
                IInformationFamilyRepository informationFamilyRepository,
                                                      IBaseRepository<InformationWorkModel> baseRepositoryWork,
                                                      IBaseRepository<InformationLangModel> baseRepositoryLang,
                                                      IBaseRepository<InformationComputerSkillsModel> baseRepositorySkills,
                                                      IMapper mapper,
                                                      IEducationPostulantRepository educationPostulantRepository,
                                                      ILanguagesPostulantRepository languagePostulantRepository,
                                                      IWorkExperienceRepository workExperienceRepository,
                                                      IBaseRepository<InformationExtraModel> baseRepositoryExtra,
                                                      IBaseRepository<EvaluationModel> evaluationbaseRepository,
                                                      IBaseRepository<Job> jobbaseRepository,
                                                      IBaseRepository<InformationEducationModel> baseRepositoryEducation,
                                                      IUtilRepository utilRepository,
                                                      IBaseRepository<DisabilityModel> baseDisabilityRepository,
                                                      IEmpresaRepository _empresaRepository,
                                                      IPersonRepository  personRepository
                                                      )
            {
                this.informationEducationRepository = informationEducationRepository;
                this.informationFamilyRepository = informationFamilyRepository;
                this.baseRepositoryAdicional = baseRepositoryAdicional;
                this.baseRepositoryWork = baseRepositoryWork;
                this.baseRepositoryLang = baseRepositoryLang;
                this.baseRepositorySkills = baseRepositorySkills;
                this.mapper = mapper;
                this.educationPostulantRepository = educationPostulantRepository;
                this.languagePostulantRepository = languagePostulantRepository;
                this.workExperienceRepository = workExperienceRepository;
                this.baseRepositoryExtra = baseRepositoryExtra;
                this.evaluationbaseRepository = evaluationbaseRepository;
                this.jobbaseRepository = jobbaseRepository;
                this.baseRepositoryEducation = baseRepositoryEducation;
                this._utilRepository = utilRepository;
                this.baseDisabilityRepository = baseDisabilityRepository;
                this._empresaRepository = _empresaRepository;
                _personRepository = personRepository;
            }
            public async Task<Result> Handle(GetInformationRegisterPostulantQuery request, CancellationToken cancellationToken)
            {
                var dto = new InformationPostulantAllDto();

                try 
                {
                    dto.InformationFamilyDtos = await informationFamilyRepository.GetInformationFamily(request.IdPerson, request.IdEvaluation);
                    
                    foreach (var item in dto.InformationFamilyDtos)
                    {
                        var param = new InformationFilesDto();
                        param.nidinformationextra = item.IdPostulant;
                        param.nidreferences = item.Id;
                        param.stypeFile = "DOCUMENTO_COPIA_DNI";
                        param.ntypefile = 1;
                        item.InformationFile = await _utilRepository.GetInformationFilesByReference(param);
                    }

                    var listInfo = await informationEducationRepository.GetInformationEducation(request.IdPerson, request.IdEvaluation);
                    dto.InformationEducationDtos = listInfo.OrderByDescending(x => x.DateStart).ToList();
                    foreach (var item in dto.InformationEducationDtos)
                    {
                        var param = new InformationFilesDto();
                        param.nidinformationextra = item.IdPostulant;
                        param.nidreferences = item.Id;
                        param.stypeFile = "DOCUMENTO_SUSTENTO";
                        param.ntypefile = 2;
                        item.InformationFile = await _utilRepository.GetInformationFilesByReference(param);
                    }

                    var entityLang = await baseRepositoryLang.FindAllPredicate(x => x.IdPostulant == request.IdPerson);
                    dto.InformationLangDtos = mapper.Map<List<InformationLangDto>>(entityLang);

                    var reference = new InformationReferenceDto();
                    reference = await _utilRepository.GetObjectivePostulantByperson(request.IdPerson);

                    var entityWork = await baseRepositoryWork.FindAllPredicate(x => x.IdPostulant == request.IdPerson && x.IdEvaluation == request.IdEvaluation);
                    dto.InformationWorkDtos = mapper.Map<List<InformationWorkDto>>(entityWork.OrderByDescending(x => x.DateStart).ToList());
                    foreach (var item in dto.InformationWorkDtos)
                    {
                        if(item.Reference == null || item.Reference == "")
                        {
                            item.Reference = reference.sdescription;
                        }

                        var param = new InformationFilesDto();
                        param.nidinformationextra = item.IdPostulant;
                        param.nidreferences = item.Id;
                        param.stypeFile = "DOCUMENTO_SUSTENTO_WORK";
                        param.ntypefile = 5;
                        item.InformationFile = await _utilRepository.GetInformationFilesByReference(param);
                    }

                    foreach (var item in dto.InformationWorkDtos)
                    {
                        string sFechaInicio = "";
                        string sFechaFin = "";

                       var  registro =   entityWork.Find(i => i.Id == item.Id);

                        if (registro != null)
                        {

                            if (registro.DateStart != null) {
                                sFechaInicio = registro.DateStart.Value.ToString("yyyy-MM-dd");
                            }
                            if (registro.DateFinish != null)
                            {
                                sFechaFin = registro.DateFinish.Value.ToString("yyyy-MM-dd");
                            }

                            item.DateStart = sFechaInicio;
                            item.DateFinish = sFechaFin;
                        }
                    }

                    #region Cambios Maximo


                    #region Datos de Estudios
                    if (dto.InformationEducationDtos.Count == 0)
                    {
                        var educationSitePostulant = await educationPostulantRepository.GetEducationByPostulant(request.IdPerson);
                        dto.InformationEducationDtos = new List<InformationEducationDto>();
                        foreach (var item in educationSitePostulant)
                        {
                            InformationEducationDto newEducation = new InformationEducationDto();
                            
                            if (item.IdInstitution == 0)
                            {
                                newEducation.StudyCenter = item.OtherInstitution;
                            }
                            else
                            {
                                newEducation.StudyCenter = item.Institution;
                            }
                                                                         
                            newEducation.Carrer = item.Carreer;
                            newEducation.IdInstruction = item.IdTypeStudy;
                            newEducation.CurrentCycle = item.IdState;
                            newEducation.IdEvaluation = request.IdEvaluation;
                            newEducation.IdPostulant = item.IdPerson;
                            DateTime _dateStart = Convert.ToDateTime(string.Format("01/{0}/{1}", Functions.MonthByDescription(item.MonthStart), item.YearStart));
                            DateTime _dateEnd;
                            if (item.Present == true) _dateEnd = DateTime.Now;
                            else
                            {
                                _dateEnd = Convert.ToDateTime(string.Format("01/{0}/{1}", Functions.MonthByDescription(item.MonthEnd), item.YearEnd));
                                _dateEnd = _dateEnd.AddMonths(1);
                                _dateEnd = _dateEnd.AddDays(-1);
                            }
                            newEducation.DateStart = _dateStart.ToString("yyyy-MM-dd");
                            newEducation.DateFinish = _dateEnd.ToString("yyyy-MM-dd");
                            dto.InformationEducationDtos.Add(newEducation);
                        }

                        foreach (var item in dto.InformationEducationDtos)
                        {
                            var entity = mapper.Map<InformationEducationModel>(item);
                            if (entity.Id == 0)
                            {
                                await baseRepositoryEducation.Add(entity);
                                item.Id = entity.Id;

                            }
                        }



                    }
                    #endregion

                    #region Datos de Familiares
                    if (dto.InformationFamilyDtos.Count == 0)
                    {


                    }
                    #endregion

                    #region Datos de Idiomas
                    if (dto.InformationLangDtos.Count == 0)
                    {

                    
                        var languages = await languagePostulantRepository.GetLanguagePostulant(request.IdPerson);

                        dto.InformationLangDtos = new List<InformationLangDto>();

                        foreach (var item in languages)
                        {
                            InformationLangDto languageDto = new InformationLangDto();

                            languageDto.IdOralLevel = item.IdOralLeven??0;
                            languageDto.IdWrittenLevel = item.IdWrittenLeven ?? 0;
                            languageDto.IdLanguage = item.IdLanguagePostulant ?? 0;
                            languageDto.IdPostulant = item.IdPerson;


                            dto.InformationLangDtos.Add(languageDto);
                        }


                        foreach (var item in dto.InformationLangDtos)
                        {
                            var entity = mapper.Map<InformationLangModel>(item);
                            if (entity.Id == 0)
                            {
                                await baseRepositoryLang.Add(entity);
                                item.Id = entity.Id;

                            }
                        }



                    }
                    #endregion


                    #region Experiencia

                    if (dto.InformationWorkDtos.Count == 0)
                    {
                        
                        var empleoslist = await workExperienceRepository.GetWorkExperience(request.IdPerson);
                        
                       
                        dto.InformationWorkDtos = new List<InformationWorkDto>();
                        foreach (var item in empleoslist)
                        {
                            InformationWorkDto empleodto = new InformationWorkDto();

                            
                            empleodto.Company = item.Company;
                            empleodto.MainFunction = item.DescriptionResponsabilities;
                            empleodto.LastPosition = item.Stand;
                            empleodto.IdPostulant = item.IdPerson;
                            empleodto.IdEvaluation = request.IdEvaluation;
                            empleodto.Salary = Convert.ToDecimal(item.Salary);
                            empleodto.Reference = reference.sdescription;
                            DateTime _dateStart = Convert.ToDateTime(string.Format("01/{0}/{1}", Functions.MonthByDescription(item.MonthStart), item.YearStart));
                            DateTime _dateEnd;
                            if (item.Present == true) _dateEnd = DateTime.Now;
                            else
                            {
                                _dateEnd = Convert.ToDateTime(string.Format("01/{0}/{1}", Functions.MonthByDescription(item.MonthEnd), item.YearEnd));
                                _dateEnd = _dateEnd.AddMonths(1);
                                _dateEnd = _dateEnd.AddDays(-1);
                            }
                            empleodto.DateStart = _dateStart.ToString("yyyy-MM-dd");
                            empleodto.DateFinish = _dateEnd.ToString("yyyy-MM-dd");
                            dto.InformationWorkDtos.Add(empleodto);

                        }
                        foreach (var item in dto.InformationWorkDtos)
                        {
                            var entity = mapper.Map<InformationWorkModel>(item);
                            entity.IdEvaluation = request.IdEvaluation;
                            if (entity.Id == 0)
                            {
                                await baseRepositoryWork.Add(entity);
                                item.Id = entity.Id;

                            }
                        }

                    }


                    #endregion

                    #endregion

                    var entitySkills = await baseRepositorySkills.FindAllPredicate(x => x.IdPostulant == request.IdPerson && x.IdEvaluation == request.IdEvaluation && x.Active);
                    dto.InformationComputerSkillsDtos = mapper.Map<List<InformationComputerSkillsDto>>(entitySkills);
                    if (entitySkills.Count == 0)
                    {
                        var _skills = await _utilRepository.GetSkillsPostulant(request.IdPerson, request.IdEvaluation);
                        dto.InformationComputerSkillsDtos = _skills;
                    }

                    var entityAditional = await baseRepositoryAdicional.FindPredicate(x => x.IdPostulant == request.IdPerson && x.IdEvaluation == request.IdEvaluation);
                    dto.InformationAditionalDtos = mapper.Map<InformationAditionalDto>(entityAditional);

                    var entityExtra = await baseRepositoryExtra.FindPredicate(x => x.IdPostulant == request.IdPerson && x.IdEvaluation == request.IdEvaluation);
                    
                    dto.InformationExtraDto = mapper.Map<InformationExtraDto>(entityExtra);
                    if(dto.InformationExtraDto != null)
                    {
                        if (dto.InformationExtraDto.IncomeCountryDate != null)
                        {
                            dto.InformationExtraDto.IncomeCountryDate = Convert.ToDateTime(dto.InformationExtraDto.IncomeCountryDate).ToShortDateString();
                        }
                    }
                   

                    #region "lista de documentos"
                    if (entityExtra != null)
                    {
                        var _filter = new FilterListaArchivos()
                        {
                            nidinformationextra = entityExtra.Id,
                            nidreferences = request.IdPerson,
                            ntipo_archivo = 3,
                            stipo_archivo = ""
                        };
                        var listaArchivos = await _utilRepository.GetInformationFiles(_filter);
                        dto.listaDocumentos = listaArchivos;
                    } else
                    {
                        var _info = await baseDisabilityRepository.FindAllPredicate(x => x.IdPerson == request.IdPerson && x.Active == true);
                        if (_info != null)
                        {
                            if (_info.Count > 0)
                            {
                                var _document = new ArchivosPostulante();
                                _document.filename = _info[0].CertificateFileName;
                                _document.ruta_archivo = string.Format("{0}{1}", _info[0].CertificateFolder, _info[0].CertificateFileName);
                                _document.tipo_archivo = "DOCUMENTO_DISCAPACIDAD";
                                dto.listaDocumentos = new List<ArchivosPostulante>();
                                dto.listaDocumentos.Add(_document);
                            }
                        }
                        var _extra = new InformationExtraDto();
                        _extra.HasDisability = true;
                        _extra.Disclaimer = true;
                       
                        var person = await _personRepository.GetPerson(request.IdPerson);
                        _extra.IdDocumentType = person.IdTypeDocument;
                        dto.InformationExtraDto = _extra;
                    }
                    #endregion
                    #region "lista Documentos Adicionales Postulante"
                    var listaDocumentosAdicionales = await _utilRepository.GetDocumentosAdicionales(request.IdEvaluation, request.IdPerson);
                    dto.listaDocumentosAdicionales = listaDocumentosAdicionales;
                    #endregion

                    if (request.IdEvaluation != 0)
                    {
                        var evaluation = await evaluationbaseRepository.FindPredicate(x => x.Id == request.IdEvaluation);
                        var job = await jobbaseRepository.FindPredicate(x => x.Id_Job == evaluation.IdJob);
                        var _company = await _empresaRepository.GetAll();
                        if (dto.InformationExtraDto != null) {
                            dto.InformationExtraDto.Company = job.Id_Company.ToString();
                            dto.InformationExtraDto.RucNumber = _company.Find(x => x.Id == job.Id_Company).Ruc;
                        }
                    }

                }
                catch (Exception ex)
                {
                    var result = ex;
                }

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = dto
                };
            }
        }
    }
}
