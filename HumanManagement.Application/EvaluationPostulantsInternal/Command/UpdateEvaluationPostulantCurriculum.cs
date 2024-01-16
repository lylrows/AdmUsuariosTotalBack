using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Command
{
    public class UpdateEvaluationPostulantCurriculum: IRequest<Result>
    {
        public EvaluationPostulantInfoCurriculumDto dto { get; set; }
    }

    public class UpdateEvaluationPostulantCurriculumHandle : IRequestHandler<UpdateEvaluationPostulantCurriculum, Result>
    {
        private readonly IBaseRepository<EvaluationPostulantInfoCurriculum> baseRepository;
        private readonly IMapper mapper;
        public UpdateEvaluationPostulantCurriculumHandle(IBaseRepository<EvaluationPostulantInfoCurriculum> baseRepository,
                               IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(UpdateEvaluationPostulantCurriculum request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationPostulantInfoCurriculum>(request.dto);

            await baseRepository.Update(entity);

            return new Result
            {
                Data = entity,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
