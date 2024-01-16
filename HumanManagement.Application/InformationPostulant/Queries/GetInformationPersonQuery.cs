using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Postulant.Person.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.InformationPostulant.Queries
{
    public class GetInformationPersonQuery: IRequest<Result>
    {
        public int IdPerson { get; set; }

        public class GetInformationPersonQueryHandle : IRequestHandler<GetInformationPersonQuery, Result>
        {
            private readonly IPersonRepository personRepository;

            public GetInformationPersonQueryHandle(IPersonRepository personRepository)
            {
                this.personRepository = personRepository;
            }
            public async Task<Result> Handle(GetInformationPersonQuery request, CancellationToken cancellationToken)
            {
                var dto = await personRepository.GetPerson(request.IdPerson);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
