using HumanManagement.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanManagement.Domain.Postulant.Person.Contracts;
using System.Threading;
using HumanManagement.CrossCutting.Utils;

namespace HumanManagement.Application.InformationPostulant.Queries
{
 
    public class GetInformationExactusQuery : IRequest<Result>
    {
        public int IdPerson { get; set; }

        public class GetInformationExactusQueryHandle : IRequestHandler<GetInformationExactusQuery, Result>
        {
            private readonly IPersonRepository personRepository;

            public GetInformationExactusQueryHandle(IPersonRepository personRepository)
            {
                this.personRepository = personRepository;
            }
            public async Task<Result> Handle(GetInformationExactusQuery request, CancellationToken cancellationToken)
            {
                var dto = await personRepository.GetPersonDataExactus(request.IdPerson);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
