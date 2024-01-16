using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.EvaluationPostulant.Models;
using MediatR;
using System;
using System.Collections.Generic;

using System.Threading;
using System.Threading.Tasks;
using EvaluationModel = HumanManagement.Domain.EvaluationPostulant.Models.Evaluation;
using ProficiencyModel = HumanManagement.Domain.Proficiency.Models.Proficiency;
using System.Linq;
using HumanManagement.Domain.Mof.Contracts;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Postulant.Person.Models;

namespace HumanManagement.Application.EvaluationPostulants.Command
{
    public class CreateEvaluationPostulantCommand: IRequest<Result>
    {
        public List<EvaluationPostulantDto> Dto { get; set; }
    }

    public class CreateEvaluationPostulantCommandHandler : IRequestHandler<CreateEvaluationPostulantCommand, Result>
    {
        private readonly IBaseRepository<EvaluationModel> baseRepository;
        private readonly IBaseRepository<PersonModelPostulant> personbaseRepository;
        private readonly IBaseRepository<EvaluationPostulant> baseRepositoryPostulant;
        private readonly IBaseRepository<EvaluationProficiency> baseRepositoryEvaluationProficiency;
        private readonly IBaseRepository<EvaluationRatingPostulant> baseRepositoryEvaluationRating;
        private readonly IBaseRepository<ProficiencyModel> baseRepositoryProficiency;
        private readonly IMofRepository mofRepository;
        private readonly IBaseRepository<Job> baseRepositoryJob;
        private readonly IMapper mapper;
        public CreateEvaluationPostulantCommandHandler(IBaseRepository<EvaluationModel> baseRepository,
                                                       IBaseRepository<EvaluationPostulant> baseRepositoryPostulant,
                                                       IBaseRepository<EvaluationProficiency> baseRepositoryEvaluationProficiency,
                                                       IBaseRepository<ProficiencyModel> baseRepositoryProficiency,
                                                       IBaseRepository<EvaluationRatingPostulant> baseRepositoryEvaluationRating,
                                                       IMofRepository mofRepository,
                                                       IBaseRepository<Job> baseRepositoryJob,
                                                       IMapper mapper,
                                                       IBaseRepository<PersonModelPostulant> personbaseRepository)
        {
            this.baseRepository = baseRepository;
            this.baseRepositoryPostulant = baseRepositoryPostulant;
            this.baseRepositoryEvaluationProficiency = baseRepositoryEvaluationProficiency;
            this.baseRepositoryEvaluationRating = baseRepositoryEvaluationRating;
            this.baseRepositoryProficiency = baseRepositoryProficiency;
            this.mofRepository = mofRepository;
            this.baseRepositoryJob = baseRepositoryJob;
            this.mapper = mapper;
            this.personbaseRepository = personbaseRepository;
        }
        public async Task<Result> Handle(CreateEvaluationPostulantCommand request, CancellationToken cancellationToken)
        {
            var entity = new EvaluationModel();
            List<string> errors = new List<string>();
            try
            {
                var evaluation = new EvaluationDto
                {
                    PositionRequired = request.Dto.FirstOrDefault().Position,
                    CodRequerimiento = "",
                    State = 904,
                    IdJob = request.Dto.FirstOrDefault().IdJob
                };

                var job = await baseRepositoryJob.FindPredicate(x => x.Id_Job == request.Dto.FirstOrDefault().IdJob);
                var evaluationExist = await baseRepository.FindPredicate(x => x.IdJob == job.Id_Job);
                if (evaluationExist == null)
                {
                    entity = mapper.Map<EvaluationModel>(evaluation);

                    await baseRepository.Add(entity);

                    entity.CodRequerimiento = string.Format("{0:00000}", entity.Id);
                    await baseRepository.Update(entity);
                }
                else
                {
                    entity.Id = evaluationExist.Id;
                }

                var entityEvaluationPostulant = mapper.Map<List<EvaluationPostulant>>(request.Dto);

                foreach (var item in entityEvaluationPostulant)
                {
                    var exist = await baseRepositoryPostulant.Exist(x => x.IdEvaluation == entity.Id && x.IdPostulant == item.IdPostulant);
                    if (!exist)
                    {
                        item.IdEvaluation = entity.Id;
                        await baseRepositoryPostulant.Add(item);
                    }
                    else
                    {
                        var person = await personbaseRepository.FindPredicate(x => x.Id == item.IdPostulant);
                        var message = $"El postulante {string.Concat(person.FirstName, " ", person.LastName)} ya esta seleccionado en la evaluación";
                        errors.Add(message);
                    }
                }

                int i = 0;
                
                var proficiencies = await mofRepository.GetMofDetailProfListsByCharge(job.IdCharge);
                foreach (var item in proficiencies)
                {
                    i++;
                    foreach (var itempostulant in entityEvaluationPostulant)
                    {
                        var dto = new EvaluationProficiencyDto
                        {
                            IdPostulant = itempostulant.IdPostulant,
                            IdEvaluation = itempostulant.IdEvaluation,
                            IdProficiency = item.IdProficiency,
                            LevelClient = null,
                            LevelJefe = null,
                            LevelRRHH = null,
                            RowGroup = i,
                            Expectative = item.Level
                        };

                        var entitie = mapper.Map<EvaluationProficiency>(dto);
                        await baseRepositoryEvaluationProficiency.Add(entitie);
                    }
                }

                foreach (var item in entityEvaluationPostulant)
                {
                    var dto = new EvaluationRatingPostulant
                    {
                        Id = 0,
                        IdPostulant = item.IdPostulant,
                        IdEvaluation = item.IdEvaluation,
                        SRatingjefeopportunities = null,
                        SRatingjefestrengths = null,
                        SRatingrrhhopportunities = null,
                        SRatingrrhhstrengths = null,
                    };

                    await baseRepositoryEvaluationRating.Add(dto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = entity,
                MessageError = errors
            };
        }
    }
}
