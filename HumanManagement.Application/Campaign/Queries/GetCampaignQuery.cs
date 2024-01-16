using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Mof.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Queries
{
    public class GetCampaignQuery : IRequest<Result>
    {
        public int IdCampaing {get;set;}
        public class GetCampaignQueryHandler : IRequestHandler<GetCampaignQuery, Result>
        {
            private readonly ICampaignRepository _campaignRepository;
            private readonly ICargoRepository cargoRepository;
            public GetCampaignQueryHandler(ICampaignRepository campaignRepository, ICargoRepository cargoRepository)
            {
                this._campaignRepository = campaignRepository;
                this.cargoRepository = cargoRepository;
            }


            public async Task<Result> Handle(GetCampaignQuery request, CancellationToken cancellationToken)
            {
                var objCampaign = await _campaignRepository.FindCampaignById(request.IdCampaing);

                var positions = await _campaignRepository.ListProficienciesByCampaignDto(request.IdCampaing);
                var list_cargos_campaign = positions.Select(i => i.IdCharge).Distinct().ToList();
                var cargos = await cargoRepository.GetListCargo();

                objCampaign.PositionList = new List<Domain.Mof.Dto.ProficiencyByChargeDto>();
                foreach (var item in list_cargos_campaign)
                {
                    try
                    {
                        var c = cargos.Where(i => i.Id == item).FirstOrDefault();
                        objCampaign.PositionList.Add(new Domain.Mof.Dto.ProficiencyByChargeDto()
                        {
                            IdCharge = item,
                            CompanyName = c.Empresa,
                            IdCompany = c.IdEmpresa,
                            NameCharge = c.NameCargo,
                            IdArea = c.IdArea,
                            NameArea = c.NameArea
                        }); ;
                    }
                    catch (Exception ex)
                    {
                        var meesage = ex;
                        //throw;
                    }
                }

                foreach (var item in objCampaign.PositionList)
                {
                    item.Proficiencies = new List<ProficiencyDetDto>();

                    foreach (var proficiency in positions.Where(i => i.IdCharge == item.IdCharge))
                    {
                          item.Proficiencies.Add(new ProficiencyDetDto()
                          {
                              Code = proficiency.IdProficiency,
                              Description = proficiency.NameProficiency,
                              Weight = proficiency.Weight??1,
                              Level = proficiency.Level??1
                          });
                    }
                }


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = objCampaign
                };
            }
        }
    }
}
