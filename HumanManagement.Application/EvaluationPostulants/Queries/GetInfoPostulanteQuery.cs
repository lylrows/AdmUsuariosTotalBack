using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.EvaluationPostulant.Models;
using HumanManagement.Domain.Postulant.Languages.Contracts;
using HumanManagement.Domain.Postulant.Person.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using HumanManagement.Domain.Postulant.Skills.Contracts;
using HumanManagement.Domain.Postulant.Education.Contracts;
using HumanManagement.Domain.Postulant.SalaryPreference.Contracts;
using HumanManagement.Domain.Postulant.SalaryPreference.Models;
using System.IO;
using MasterTableModel = HumanManagement.Domain.MasterTable.Models.MasterTable;
using EvalutionModel = HumanManagement.Domain.EvaluationPostulant.Models.Evaluation;
using HumanManagement.Domain.Job.Models;

namespace HumanManagement.Application.EvaluationPostulants.Queries
{
    public class GetInfoPostulanteQuery: IRequest<Result>
    {
        public int IdEvaluationPostulant { get; set; }
        public class GetInfoPostulanteQueryHandler : IRequestHandler<GetInfoPostulanteQuery, Result>
        {
            private readonly IBaseRepository<EvaluationPostulant> baseRepository;
            private readonly IPersonRepository personRepository;
            private readonly ILanguagesPostulantRepository languagePostulantRepository;
            private readonly ISkillsPostulantRepository skillsPostulantRepository;
            private readonly IEducationPostulantRepository educationPostulantRepository;
            private readonly IBaseRepository<SalaryPreferenceModel> baseRepositorySalary;
            private readonly IBaseRepository<MasterTableModel> masterTableBaseRepository;
            private readonly IBaseRepository<EvalutionModel> evaluationBaseRepository;
            private readonly IBaseRepository<JobPostulant> jobPostulant;
            public GetInfoPostulanteQueryHandler(IBaseRepository<EvaluationPostulant> baseRepository,
                                                 IPersonRepository personRepository,
                                                 ILanguagesPostulantRepository languagePostulantRepository,
                                                 ISkillsPostulantRepository skillsPostulantRepository,
                                                 IEducationPostulantRepository educationPostulantRepository,
                                                 IBaseRepository<SalaryPreferenceModel> baseRepositorySalary,
                                                 IBaseRepository<MasterTableModel> masterTableBaseRepository,
                                                 IBaseRepository<EvalutionModel> evaluationBaseRepository,
                                                 IBaseRepository<JobPostulant> jobPostulant)
            {
                this.baseRepository = baseRepository;
                this.personRepository = personRepository;
                this.languagePostulantRepository = languagePostulantRepository;
                this.skillsPostulantRepository = skillsPostulantRepository;
                this.educationPostulantRepository = educationPostulantRepository;
                this.baseRepositorySalary = baseRepositorySalary;
                this.masterTableBaseRepository = masterTableBaseRepository;
                this.evaluationBaseRepository = evaluationBaseRepository;
                this.jobPostulant = jobPostulant;
            }
            public async Task<Result> Handle(GetInfoPostulanteQuery request, CancellationToken cancellationToken)
            {
                var dto = new PostulantInfoDto();

                try
                {
                    var infoevaluation = await baseRepository.FindPredicate(x => x.Id == request.IdEvaluationPostulant);
                    dto.Approved = infoevaluation.Approved;
                    dto.IdEvaluation = infoevaluation.IdEvaluation;


                    /* obtener id process */
                    var evaluation = await evaluationBaseRepository.FindPredicate(x => x.Id == dto.IdEvaluation);
                    dto.Process = evaluation.Process;

                    var entityMastertable = await masterTableBaseRepository.FindPredicate(x => x.Id == infoevaluation.State);
                    dto.StateEvaluation = entityMastertable.DescriptionValue;

                    var lang = await languagePostulantRepository.GetLanguagePostulant(infoevaluation.IdPostulant);
                    if (lang != null)
                    {
                        var arrLang = lang.Select(p => p.DescripcionLang).ToArray();
                        dto.Idiomas = string.Join(",", arrLang);
                    }

                    var skills = await skillsPostulantRepository.GetSkillsByPostulant(infoevaluation.IdPostulant);
                    if (skills != null)
                    {
                        var arrSkills = skills.Select(p => p.DescriptionSkill).ToArray();
                        dto.Skills = string.Join(",", arrSkills);
                    }

                    var study = await educationPostulantRepository.GetEducationByPostulant(infoevaluation.IdPostulant);

                    if (study.Count > 0)
                    {
                        dto.Carreer = study.FirstOrDefault().Carreer;
                        dto.StateEstudy = study.FirstOrDefault().DescriptionTypeStudy;
                    }

                    var salary = await baseRepositorySalary.FindPredicate(x => x.IdPerson == infoevaluation.IdPostulant);

                    if (salary != null)
                    {
                        dto.SueldoPretendido = salary.Monto;
                    }

                    dto.InformationPersonal = await personRepository.GetPerson(infoevaluation.IdPostulant);
                    if (dto.InformationPersonal != null)
                    {
                        var file = dto.InformationPersonal.Img;
                        if (File.Exists(file))
                        {
                            var buffer = File.ReadAllBytes(file);
                            dto.InformationPersonal.Img = $"data:image/jpeg;base64,{Convert.ToBase64String(buffer)}";
                        }
                    }

                    var infoJob = await jobPostulant.FindPredicate(x => x.Id_Postulant == dto.InformationPersonal.IdUser);
                    dto.IdJob = infoJob.Id_Job;

                    if (dto.InformationPersonal.Img != null)
                    {
                        var file = dto.InformationPersonal.Img;
                        if (File.Exists(file))
                        {
                            var buffer = File.ReadAllBytes(file);
                            dto.InformationPersonal.Img = $"data:image/jpeg;base64,{Convert.ToBase64String(buffer)}";
                        }
                    }

                    if (dto.InformationPersonal.CvFolder != null)
                    {
                        var file = dto.InformationPersonal.CvFolder;
                        if (File.Exists(file))
                        {
                            var buffer = File.ReadAllBytes(file);
                            dto.InformationPersonal.CvFile = buffer;
                            dto.InformationPersonal.ContentType = Path.GetExtension(dto.InformationPersonal.CvName);
                        }
                    }

                    if (infoevaluation.FolderFileCompetencias != null)
                    {
                        var file = infoevaluation.FolderFileCompetencias;
                        if (File.Exists(file))
                        {
                            dto.FileCompetencias = new FileDto();
                            var buffer = File.ReadAllBytes(file);
                            dto.FileCompetencias.File = buffer;
                            dto.FileCompetencias.ContentType = Path.GetExtension(infoevaluation.NameFileCompetencias);
                            dto.FileCompetencias.NameFile = infoevaluation.NameFileCompetencias;
                        }
                    }

                    if (infoevaluation.FolderFileMultitest != null)
                    {
                        var file = infoevaluation.FolderFileMultitest;
                        if (File.Exists(file))
                        {
                            dto.FileMultitest = new FileDto();
                            var buffer = File.ReadAllBytes(file);
                            dto.FileMultitest.File = buffer;
                            dto.FileMultitest.ContentType = Path.GetExtension(infoevaluation.FolderFileMultitest);
                            dto.FileMultitest.NameFile = infoevaluation.NameFileMultitest;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
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
