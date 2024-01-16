using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Contracts;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.EvaluationPostulant.Models;
using HumanManagement.Domain.Postulant.Person.Contracts;
using HumanManagement.Domain.Postulant.SalaryPreference.Models;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using EvaluationModel = HumanManagement.Domain.EvaluationPostulant.Models.Evaluation;

namespace HumanManagement.Application.EvaluationPostulants.Command
{
    public class GenerateEvaluationPostulantExternCommand: IRequest<Result>
    {
        public int IdEvaluationPostulant { get; set; }
    }

    public class GenerateEvaluationPostulantExternCommandHandle : IRequestHandler<GenerateEvaluationPostulantExternCommand, Result>
    {
        private readonly IBaseRepository<EvaluationPostulant> evalpostulantbaseRepository;
        private readonly IBaseRepository<EvaluationModel> evaluationbaseRepository;
        private readonly IPersonRepository personRepository;
        private readonly IEvaluationProficiencyRepository evaluationProficiencyRepository;
        private readonly IEvaluationRatingRepository evaluationRatingRepository;
        private readonly IBaseRepository<EvaluationMultitestExtern> multitestbaseRepository;
        private readonly IBaseRepository<SalaryPreferenceModel> salaryPreference;
        private readonly AppSettings _appSettings;
        private readonly IMapper mapper;
        public GenerateEvaluationPostulantExternCommandHandle(IBaseRepository<EvaluationPostulant> evalpostulantbaseRepository,
                                                              IBaseRepository<EvaluationModel> evaluationbaseRepository,
                                                              IPersonRepository personRepository,
                                                              IEvaluationProficiencyRepository evaluationProficiencyRepository,
                                                              IEvaluationRatingRepository evaluationRatingRepository,
                                                              IOptions<AppSettings> appSettings,
                                                              IBaseRepository<EvaluationMultitestExtern> multitestbaseRepository,
                                                              IBaseRepository<SalaryPreferenceModel> salaryPreference,
                                                              IMapper mapper)
        {
            this.evalpostulantbaseRepository = evalpostulantbaseRepository;
            this.evaluationbaseRepository = evaluationbaseRepository;
            this.personRepository = personRepository;
            this.evaluationProficiencyRepository = evaluationProficiencyRepository;
            this.evaluationRatingRepository = evaluationRatingRepository;
            this.multitestbaseRepository = multitestbaseRepository;
            this._appSettings = appSettings.Value;
            this.salaryPreference = salaryPreference;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(GenerateEvaluationPostulantExternCommand request, CancellationToken cancellationToken)
        {
            var dto = new InfoReportIndividualDto();

            var evaluationpostulant = await evalpostulantbaseRepository.FindPredicate(x => x.Id == request.IdEvaluationPostulant);
            var evaluation = await evaluationbaseRepository.FindPredicate(x => x.Id == evaluationpostulant.IdEvaluation);
            var person = await personRepository.GetPerson(evaluationpostulant.IdPostulant);
            var testproficiency = await evaluationProficiencyRepository.GetEvaluationProficiencies(evaluationpostulant.IdEvaluation, person.Id);
            var testrating = await evaluationRatingRepository.GetEvaluationRatingPostulants(evaluationpostulant.IdEvaluation, person.Id);
            var multitest = await multitestbaseRepository.FindPredicate(x => x.IdPostulant == evaluationpostulant.IdPostulant);
            var salary = await salaryPreference.FindPredicate(x => x.IdPerson == person.Id);
           
            var multitestDto = mapper.Map<EvaluationMultitestExternDto>(multitest);

            dto.InfoEvaluationProficiency = testproficiency;
            dto.InfoEvaluationRating = testrating;
            dto.InfoPerson = person;
            dto.PositionApplicant = evaluation.PositionRequired;
            dto.InfoEvaluationMultitest = multitestDto;
         

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

    }
}
