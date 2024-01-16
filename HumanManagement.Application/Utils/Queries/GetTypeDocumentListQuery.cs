using HumanManagement.Application.Response;
using HumanManagement.Domain.Utils.Constracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Utils.Queries
{
    public class GetTypeDocumentListQuery :  IRequest<Result>
    {
        public class GetListTypeDocumentQueryHandler : IRequestHandler<GetTypeDocumentListQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListTypeDocumentQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetTypeDocumentListQuery query, CancellationToken cancellationToken)
            {
                var listtypedocument = await _utilRepository.GetTypeDocuementList();
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listtypedocument }
                };
            }
           
        }
    }
}
