using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Person.Contracts;
using HumanManagement.Domain.Person.QueryFilter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Postulant.Queries
{
   public class GetListPostulantsInternalQuery : IRequest<Result>
    {
        public PostulantQueryFilter queryFilter { get; set; }
        public class GetListPostulantsInternalQueryHandle : IRequestHandler<GetListPostulantsInternalQuery, Result>
        {
            private readonly IPersonRepository personRepository;

            public GetListPostulantsInternalQueryHandle(IPersonRepository personRepository)
            {
                this.personRepository = personRepository;
            }
            public async Task<Result> Handle(GetListPostulantsInternalQuery request, CancellationToken cancellationToken)
            {
                var dto = await personRepository.GetListPostulant(request.queryFilter);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }

   
}
