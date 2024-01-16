using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseDto;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.SalaryBand.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.SalaryBand.Queries
{

    public class GetAreaGroupCboQuery : IRequest<Result>
    {

        public class GetAreaGroupCboQueryHandler : IRequestHandler<GetAreaGroupCboQuery, Result>
        {
            private readonly IBaseRepository<AreaGroup> _baseAreaGroupRepository;
            public GetAreaGroupCboQueryHandler(IBaseRepository<AreaGroup> baseAreaGroupRepository)
            {
                this._baseAreaGroupRepository = baseAreaGroupRepository;
            }
            public async Task<Result> Handle(GetAreaGroupCboQuery query, CancellationToken cancellationToken)
            {
                List<DropDownListDto<int>> listreturn = new List<DropDownListDto<int>>();

                var listEntity = await _baseAreaGroupRepository.GetAll();

                
                foreach (var item in listEntity.OrderBy(i=>i.Order))
                {
                    DropDownListDto<int> dto = new DropDownListDto<int>();
                    dto.Code = item.IdAreaGroup;
                    dto.Description = item.NameGroup;
                    listreturn.Add(dto);
                }

                return new Result
                {
                    StateCode = 200,
                    Data = listreturn
                };

            }
        }
    }
}
