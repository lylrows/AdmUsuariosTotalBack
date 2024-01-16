using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;

using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.MasterTable.Contracts;
using HumanManagement.Domain.Mof.Contracts;
using HumanManagement.Domain.Person.Models;
using MediatR;

using System.Collections.Generic;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using EvaluationPostulantsInternalModel = HumanManagement.Domain.EvaluationPostulantInternal.Models.EvaluationPostulantsInternal;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Command
{
    public class CreateEvaluationPostulantsInternalCommand : IRequest<Result>
    {
        public List<EvaluationPostulantDto> Dto { get; set; }
    }

    public class CreateEvaluationPostulantsInternalCommandHandle : IRequestHandler<CreateEvaluationPostulantsInternalCommand, Result>
    {
        private readonly IBaseRepository<EvaluationPostulantsInternalModel> evalutionPostulantBaseRepository;
        private readonly IBaseRepository<EvaluationVacantInternal> evalutionInternalBaseRepository;
        private readonly IBaseRepository<EvaluationPostulantInfoCurriculum> evalutionCurriculumBaseRepository;
        private readonly IBaseRepository<EvaluationProficiencyIntern> baseRepositoryEvaluationProficiency;
        private readonly IBaseRepository<EvaluationFortalezasIntern> baseRepositoryEvaluationFortalezas;
        private readonly IMofRepository mofRepository;
        private readonly IBaseRepository<JobOffersInternal> baseRepositoryJob;
        private readonly IMasterTableRepository masterTableRepository;
        private readonly IMapper mapper;
        private readonly IEvaluationPostulantInfoCurriculumRepository evaluationPostulantInfoCurriculumRepository;
        private readonly IBaseRepository<PersonModel> personbaseRepository;
        public CreateEvaluationPostulantsInternalCommandHandle(IBaseRepository<EvaluationPostulantsInternalModel> evalutionPostulantBaseRepository,
                                                               IBaseRepository<EvaluationVacantInternal> evalutionInternalBaseRepository,
                                                               IBaseRepository<EvaluationPostulantInfoCurriculum> evalutionCurriculumBaseRepository,
                                                               IMasterTableRepository masterTableRepository,
                                                               IBaseRepository<EvaluationProficiencyIntern> baseRepositoryEvaluationProficiency,
                                                               IBaseRepository<EvaluationFortalezasIntern> baseRepositoryEvaluationFortalezas,
                                                               IMofRepository mofRepository,
                                                               IBaseRepository<JobOffersInternal> baseRepositoryJob,
                                                               IEvaluationPostulantInfoCurriculumRepository evaluationPostulantInfoCurriculumRepository,
                                                               IMapper mapper,
                                                               IBaseRepository<PersonModel> personbaseRepository)
        {
            this.evalutionInternalBaseRepository = evalutionInternalBaseRepository;
            this.evalutionPostulantBaseRepository = evalutionPostulantBaseRepository;
            this.evalutionCurriculumBaseRepository = evalutionCurriculumBaseRepository;
            this.masterTableRepository = masterTableRepository;
            this.baseRepositoryEvaluationProficiency = baseRepositoryEvaluationProficiency;
            this.baseRepositoryEvaluationFortalezas = baseRepositoryEvaluationFortalezas;
            this.mofRepository = mofRepository;
            this.baseRepositoryJob = baseRepositoryJob;
            this.mapper = mapper;
            this.evaluationPostulantInfoCurriculumRepository = evaluationPostulantInfoCurriculumRepository;
            this.personbaseRepository = personbaseRepository;
        }
        public async Task<Result> Handle(CreateEvaluationPostulantsInternalCommand request, CancellationToken cancellationToken)
        {
            var entity = new EvaluationVacantInternal();
            List<string> errors = new List<string>();
            try
            {
                var details = await masterTableRepository.GetByIdFather(957);
                var evaluation = new EvaluationVacantInternalDto
                {
                    PositionRequired = request.Dto.FirstOrDefault().Position,
                    CodRequerimiento = "",
                    State = 904,
                    IdJob = request.Dto.FirstOrDefault().IdJob
                };

                var evaluationExist = await evalutionInternalBaseRepository.FindPredicate(x => x.IdJob == request.Dto.FirstOrDefault().IdJob);

                if (evaluationExist == null)
                {
                    entity = mapper.Map<EvaluationVacantInternal>(evaluation);
                    await evalutionInternalBaseRepository.Add(entity);
                    entity.CodRequerimiento = string.Format("{0:00000}", entity.Id);
                    await evalutionInternalBaseRepository.Update(entity);
                }
                else
                {
                    entity.Id = evaluationExist.Id;
                }

                var listPostulant = mapper.Map<List<EvaluationPostulantsInternalModel>>(request.Dto);

                foreach (var item in listPostulant)
                {
                    var exist = await evalutionPostulantBaseRepository.Exist(x => x.IdEvaluation == entity.Id && x.IdPostulant == item.IdPostulant);
                    if (!exist)
                    {
                        item.IdEvaluation = entity.Id;
                        await evalutionPostulantBaseRepository.Add(item);

                        foreach (var itemDet in details)
                        {
                            var entityEval = new EvaluationPostulantInfoCurriculum
                            {
                                IdDetail = itemDet.Id,
                                IdEvaluationPostulant = item.Id
                            };

                            await evalutionCurriculumBaseRepository.Add(entityEval);
                        }
                        //var _result = await evaluationPostulantInfoCurriculumRepository.SetDataInitial(item.Id); JNR
                    }
                    else
                    {
                        var person = await personbaseRepository.FindPredicate(x => x.Id == item.IdPostulant);
                        var message = $"El postulante {string.Concat(person.FirstName, " ", person.LastName)} ya esta seleccionado en la evaluación";
                        errors.Add(message);
                    }
                }

                var job = await baseRepositoryJob.FindPredicate(x => x.Id_Job == request.Dto.FirstOrDefault().IdJob);
                var proficiencies = await mofRepository.GetMofDetailProfListsByCharge(job.IdCharge);
                int i = 0;
                foreach (var item in proficiencies)
                {
                    i++;
                    foreach (var itempostulant in listPostulant)
                    {
                        var dto = new EvaluationProficiencyInternDto
                        {
                            IdPostulant = itempostulant.IdPostulant,
                            IdEvaluation = itempostulant.IdEvaluation,
                            IdProficiency = item.IdProficiency,
                            LevelJefe = null,
                            LevelRRHH = null,
                            RowGroup = i,
                            Expectative = item.Level,
                            Flag = 1
                        };

                        var entitie = mapper.Map<EvaluationProficiencyIntern>(dto);
                        await baseRepositoryEvaluationProficiency.Add(entitie);
                    }
                }


                var proficiencies_currently = await mofRepository.GetMofDetailProfListsByCharge(request.Dto.FirstOrDefault().IdPositionCurrently);
                int i2 = 0;
                foreach (var item in proficiencies_currently)
                {
                    i2++;
                    foreach (var itempostulant in listPostulant)
                    {
                        var dto = new EvaluationProficiencyInternDto
                        {
                            IdPostulant = itempostulant.IdPostulant,
                            IdEvaluation = itempostulant.IdEvaluation,
                            IdProficiency = item.IdProficiency,
                            LevelJefe = null,
                            LevelRRHH = null,
                            RowGroup = i,
                            Expectative = item.Level,
                            Flag = 2
                        };

                        var entitie = mapper.Map<EvaluationProficiencyIntern>(dto);
                        await baseRepositoryEvaluationProficiency.Add(entitie);
                    }
                }


                foreach (var item in listPostulant)
                {
                    var dto = new EvaluationFortalezasIntern
                    {
                        Id = 0,
                        IdPostulant = item.IdPostulant,
                        IdEvaluation = item.IdEvaluation,
                        SRatingjefeopportunities = null,
                        SRatingjefestrengths = null,
                        SRatingrrhhopportunities = null,
                        SRatingrrhhstrengths = null,
                    };

                    await baseRepositoryEvaluationFortalezas.Add(dto);
                }
            }
            catch (System.Exception ex)
            {
                var x = ex;
            }


            return new Result
            {
                Data = entity,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                MessageError = errors
            };
        }
    }
}