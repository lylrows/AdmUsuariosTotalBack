using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseDto;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Queries
{
    public class GetListCampaignComboQuery : IRequest<Result>
    {

       public class GetListCampaignComboQueryHandler : IRequestHandler<GetListCampaignComboQuery, Result>
       {
            private readonly IBaseRepository<Domain.Campaign.Models.Campaign> baseRepository;
            

            public GetListCampaignComboQueryHandler(IBaseRepository<Domain.Campaign.Models.Campaign> baseRepository)
            {
                this.baseRepository = baseRepository;
                

            }
       

            public async Task<Result> Handle(GetListCampaignComboQuery request, CancellationToken cancellationToken)
            {

                List<DropDownListDto<int>> listreturn = new List<DropDownListDto<int>>();

                var listEntity = await baseRepository.GetAll();

                foreach (var item in listEntity)
                {
                    DropDownListDto<int> dto = new DropDownListDto<int>();
                    dto.Code = item.Id_Campaign;
                    dto.Description = item.NameCampaign;
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
