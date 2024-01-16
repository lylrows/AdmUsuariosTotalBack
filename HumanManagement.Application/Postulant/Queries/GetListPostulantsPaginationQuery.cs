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

namespace HumanManagement.Application.Postulant.Queries
{
    public class GetListPostulantsPaginationQuery : IRequest<Result> 
    {
        public PostulantQueryFilter PostulantQueryFilter { get; set; }
        public class GetListPostulantsPaginationQueryHandler : IRequestHandler<GetListPostulantsPaginationQuery, Result>
        {
            private readonly IPersonRepository personRepository;
            private readonly IJobKeyWordRepository jobKeyWordRepository;
            private readonly IPersonSkillRepository personSkillRepository;
            private readonly IWorkExperienceRepository workExperienceRepository;
            public GetListPostulantsPaginationQueryHandler(IPersonRepository personRepository,
                                                           IJobKeyWordRepository jobKeyWordRepository,
                                                           IPersonSkillRepository personSkillRepository,
                                                           IWorkExperienceRepository workExperienceRepository)
            {
                this.personRepository = personRepository;
                this.jobKeyWordRepository = jobKeyWordRepository;
                this.personSkillRepository = personSkillRepository;
                this.workExperienceRepository = workExperienceRepository;
            }

            public async Task<Result> Handle(GetListPostulantsPaginationQuery request, CancellationToken cancellationToken)
            { 
                var listPostulant = await personRepository.GetListPostulant(request.PostulantQueryFilter);
                int[] arrarIdPostulant = listPostulant.list
                                    .Select(x => x.IdPostulant).ToArray();
                int[] arrarIdPerson = listPostulant.list
                                 .Select(x => x.IdPerson).ToArray();

                if (listPostulant.list.Count > 0)
                {
                    var listJobKeyWords = await jobKeyWordRepository.GetKeyWordList(listPostulant.list.FirstOrDefault().IdJob);
                    var listPostulantSkills = await personSkillRepository.GetListSkill(arrarIdPerson);
                    var listExperiences = await workExperienceRepository.GetWorkExperiencePostulants(arrarIdPerson);

                    GenerateListPostulant generateListPostulant = new GenerateListPostulant(listPostulant.list,
                                                                                            listJobKeyWords,
                                                                                            listPostulantSkills,
                                                                                            listExperiences,
                                                                                            request.PostulantQueryFilter);
                    generateListPostulant.Generate();
                    
                    listPostulant.list = (from lista in generateListPostulant.PostulantOrderList
                                          orderby lista.PorcentajeAsertividad descending
                                          select lista).ToList();
                }
              
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = listPostulant
                };
            }
        }
    }
}
