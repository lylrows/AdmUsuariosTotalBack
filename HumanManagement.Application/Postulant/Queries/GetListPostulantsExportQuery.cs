using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Domain.Postulant.Person.Contracts;
using HumanManagement.Domain.Postulant.Person.QueryFilter;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using HumanManagement.Domain.Postulant.Person.Models;
using HumanManagement.Domain.Postulant.WorkExperience.Contracts;

using Microsoft.Extensions.Logging;

namespace HumanManagement.Application.Postulant.Queries
{
        public class GetListPostulantsExportQuery : IRequest<Result>
        {
            public PostulantQueryFilter PostulantQueryFilter { get; set; }
            public class GetListPostulantsPaginationQueryHandler : IRequestHandler<GetListPostulantsExportQuery, Result>
            {
                private readonly IPersonRepository personRepository;
                private readonly IJobKeyWordRepository jobKeyWordRepository;
                private readonly IPersonSkillRepository personSkillRepository;
                private readonly IWorkExperienceRepository workExperienceRepository;
                private readonly ILogger<GetListPostulantsPaginationQueryHandler> _logger;
            public GetListPostulantsPaginationQueryHandler(IPersonRepository personRepository,
                                                               IJobKeyWordRepository jobKeyWordRepository,
                                                               IPersonSkillRepository personSkillRepository,
                                                               IWorkExperienceRepository workExperienceRepository,
                                                               ILogger<GetListPostulantsPaginationQueryHandler> logger)
                {
                    this.personRepository = personRepository;
                    this.jobKeyWordRepository = jobKeyWordRepository;
                    this.personSkillRepository = personSkillRepository;
                    this.workExperienceRepository = workExperienceRepository;
                    this._logger = logger;
            }

                public async Task<Result> Handle(GetListPostulantsExportQuery request, CancellationToken cancellationToken)
                {
                    var listPostulant = await personRepository.GetListPostulantExport(request.PostulantQueryFilter);

                    int[] arrarIdPostulant = listPostulant
                                    .Select(x => x.IdPostulant).ToArray();
                    int[] arrarIdPerson = listPostulant
                                     .Select(x => x.IdPerson).ToArray();

                    if (listPostulant.Count > 0)
                    {
                        var listJobKeyWords = await jobKeyWordRepository.GetKeyWordList(listPostulant.FirstOrDefault().IdJob);
                        var listPostulantSkills = await personSkillRepository.GetListSkill(arrarIdPerson);
                        var listExperiences = await workExperienceRepository.GetWorkExperiencePostulants(arrarIdPerson);

                        _logger.LogInformation(string.Format("listPostulant => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(listPostulant)));
                        _logger.LogInformation(string.Format("listJobKeyWords => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(listJobKeyWords)));
                        _logger.LogInformation(string.Format("listPostulantSkills => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(listPostulantSkills)));
                        _logger.LogInformation(string.Format("listPostulantSkills => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(listPostulantSkills)));
                        _logger.LogInformation(string.Format("request.PostulantQueryFilter => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(request.PostulantQueryFilter)));
                    GenerateListPostulant generateListPostulant = new GenerateListPostulant(listPostulant,
                                                                                                listJobKeyWords,
                                                                                                listPostulantSkills,
                                                                                                listExperiences,
                                                                                                request.PostulantQueryFilter);
                        generateListPostulant.Generate();
                        
                        listPostulant = (from lista in generateListPostulant.PostulantOrderList
                                              orderby lista.PorcentajeAsertividad descending
                                              select lista).ToList();
                    }

                return new Result
                    {
                        StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                        Data= listPostulant
                    };

               
                }
            }
        }

    
}
