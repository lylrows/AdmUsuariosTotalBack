using HumanManagement.Application.Response;
using HumanManagement.Domain.Person.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Person.Queries
{
    public class GetPersonQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, Result>
        {
            private readonly IPersonRepository _personRepository;
            public GetPersonQueryHandler(IPersonRepository personRepository)
            {
                this._personRepository = personRepository;
            }

            public async Task<Result> Handle(GetPersonQuery query, CancellationToken cancellationToken)
            {
                var person = await _personRepository.GetPerson(query.Id);
                return new Result
                {
                    StateCode = 200,
                    Data = person
                };
            }
        }
    }
}
