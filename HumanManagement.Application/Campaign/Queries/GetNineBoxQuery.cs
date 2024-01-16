using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Campaign.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Queries
{
   
    public class GetNineBoxQuery : IRequest<Result>
    {
        public NineBoxFilterDto dtofilter { get; set; }
        public class GetNineBoxQueryHandler : IRequestHandler<GetNineBoxQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            
            public GetNineBoxQueryHandler(ICampaignRepository campaignRepository)
            {
                this._campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetNineBoxQuery request, CancellationToken cancellationToken)
            {
                var objCampaign = await _campaignRepository.GetNineBox(request.dtofilter);


                var evaluaciones = objCampaign.Select(i => i.IdEvaluation).Distinct();

                List<NineBoxDto> listresult = new List<NineBoxDto>();

                foreach (var idevaluation in evaluaciones)
                {

                    var details = objCampaign.Where(i => i.IdEvaluation == idevaluation).ToList();

                    var gr1 = details.Where(i => i.IdGroup == 1 && i.Expectativa != 0);
                    var gr2 = details.Where(i => i.IdGroup == 2);

                    var pond_meta_1 = gr1.Sum(i => i.Expectativa * i.Peso);
                    var pond_real_1 = gr1.Sum(i => i.Realidad * i.Peso);


                    var pond_meta_2 = gr2.Sum(i => i.Expectativa * i.Peso);
                    var pond_real_2 = gr2.Sum(i => i.Realidad * i.Peso);


                    var pond_1 = pond_real_1 / pond_meta_1;
                    var pond_2 = pond_real_2 / pond_meta_2;


                    NineBoxDto newninebox = new NineBoxDto();

                    newninebox.IdEvaluation = idevaluation;
                    newninebox.ObjetivoPorc = pond_1 * 100;
                    newninebox.CompetenciaPorc = pond_2 * 100;
                    newninebox.DNI = details[0].DNI;
                    newninebox.NombreCompleto = details[0].NombreCompleto;
                    newninebox.Cargo = details[0].Cargo;
                    newninebox.Area = details[0].Area;
                    newninebox.Compania = details[0].Compania;
                    newninebox.FotoUrl = details[0].FotoUrl;
                    listresult.Add(newninebox);
                }

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = listresult
                };
            }
        }
    }
}
