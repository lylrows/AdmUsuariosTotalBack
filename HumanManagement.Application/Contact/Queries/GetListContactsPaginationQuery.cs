using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Contact.Contracts;
using HumanManagement.Domain.Contact.QueryFilter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Contact.Queries
{
    public class GetListContactsPaginationQuery : IRequest<Result>
    {


        public ContactQueryFilter contactQueryFilter { get; set; }
        public class GetListContactsPaginationQueryHandler : IRequestHandler<GetListContactsPaginationQuery, Result>
        {
            private readonly IContactRepository _contactRepository;
            public GetListContactsPaginationQueryHandler(IContactRepository contactRepository)
            {
                this._contactRepository = contactRepository;
            }
            public async Task<Result> Handle(GetListContactsPaginationQuery query, CancellationToken cancellationToken)
            {
                var resultPagination = await _contactRepository.GetListUsersPagination(query.contactQueryFilter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
