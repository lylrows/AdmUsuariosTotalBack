using HumanManagement.Application.Response;
using HumanManagement.Domain.Utils.Constracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Utils.Queries
{

    public class GetChargePositionByIdQuery : IRequest<int>
    {
        public int Id { get; set; }
        public class GetChargePositionByIdQueryHandler : IRequestHandler<GetChargePositionByIdQuery, int>
        {
            private readonly IUtilRepository _utilRepository;
            public GetChargePositionByIdQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<int> Handle(GetChargePositionByIdQuery query, CancellationToken cancellationToken)
            {
                var listCharge = await _utilRepository.GetChangePositionById(query.Id);
                
                return listCharge.nid_area;
                
            }
        }
    }
}
