using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.EvaluationPostulant.Models;
using HumanManagement.Domain.Postulant.Person.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulants.Queries
{
    public class GetEvaluationTestQuery: IRequest<Result>
    {
        public int IdEvaluationPostulant { get; set; }

        public class GetEvaluationTestQueryHandle : IRequestHandler<GetEvaluationTestQuery, Result>
        {
            private readonly IBaseRepository<EvaluationExternTest> baseRepository;
            private readonly IBaseRepository<PersonModelPostulant> personBaseRepository;
            private readonly IBaseRepository<EvaluationPostulant> evaluationPostulantBaseRepository;
            private readonly IMapper mapper;
            public GetEvaluationTestQueryHandle(IBaseRepository<EvaluationExternTest> baseRepository, IMapper mapper, IBaseRepository<PersonModelPostulant> personBaseRepository,
                                                IBaseRepository<EvaluationPostulant> evaluationPostulantBaseRepository)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
                this.personBaseRepository = personBaseRepository;
                this.evaluationPostulantBaseRepository = evaluationPostulantBaseRepository;
            }
            public async Task<Result> Handle(GetEvaluationTestQuery request, CancellationToken cancellationToken)
            {
                var list = await baseRepository.FindAllPredicate(x => x.IdEvaluationPostulant == request.IdEvaluationPostulant);
                var dtoList = mapper.Map<List<EvaluationExternTestDto>>(list);

                foreach (var item in dtoList)
                {
                    var empleado = await evaluationPostulantBaseRepository.FindPredicate(x => x.Id == item.IdEvaluationPostulant);
                    var person = await personBaseRepository.FindPredicate(x => x.Id == empleado.IdPostulant);

                    item.FullNamePostulant = string.Concat(person.FirstName + " " + person.LastName);
                }


                return new Result
                {
                    Data = dtoList,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
