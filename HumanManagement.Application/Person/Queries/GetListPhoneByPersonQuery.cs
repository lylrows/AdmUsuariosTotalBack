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
    public class GetListPhoneByPersonQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public class GetListPhoneByPersonQueryHandler : IRequestHandler<GetListPhoneByPersonQuery, Result>
        {
            private readonly IPersonRepository _personRepository;
            public GetListPhoneByPersonQueryHandler(IPersonRepository personRepository)
            {
                this._personRepository = personRepository;
            }

            public async Task<Result> Handle(GetListPhoneByPersonQuery query, CancellationToken cancellationToken)
            {
                var listphone = await _personRepository.GetListPhone(query.Id);
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listphone }
                };
            }
        }
    }
}
