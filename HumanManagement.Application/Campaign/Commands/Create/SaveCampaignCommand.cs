using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Campaign.Dto;
using HumanManagement.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Commands.Create
{
    public class SaveCampaignCommand : IRequest<Result>
    {
        public SaveCampaignDto saveCampaign { get; set; }
        public int IdUsuario { get; set; }
    }

    public class SaveCampaignCommandHandler : IRequestHandler<SaveCampaignCommand, Result>
    {
        private readonly IBaseRepository<Domain.Campaign.Models.ProficiencyCharge> baseProficiencyCharge;
        private readonly IBaseRepository<Domain.Campaign.Models.Campaign> baseCampaign;
        private readonly ICampaignRepository _campaignRepository;
        
        private readonly IUnitOfWork unitOfWork;

        public SaveCampaignCommandHandler(IBaseRepository<Domain.Campaign.Models.ProficiencyCharge> baseProficiencyCharge,
                                    
                                    IUnitOfWork unitOfWork,
                                    ICampaignRepository campaignRepository,
                                    IBaseRepository<Domain.Campaign.Models.Campaign> baseCampaign
                                    )
        {
            this.baseProficiencyCharge = baseProficiencyCharge;
            this.unitOfWork = unitOfWork;
            this._campaignRepository = campaignRepository;
            this.baseCampaign = baseCampaign;
        }

        public async Task<Result> Handle(SaveCampaignCommand request, CancellationToken cancellationToken)
        {
            int nidCampaign = 0;

            if ( request.saveCampaign.nIdCampaign == 0)
            {

                Domain.Campaign.Models.Campaign newcampaign = new Domain.Campaign.Models.Campaign();

                newcampaign.NameCampaign = request.saveCampaign.sNameCampaign;
                newcampaign.Status = 1;
                newcampaign.Year = request.saveCampaign.nYear;
                newcampaign.Month = request.saveCampaign.nMonth;
                newcampaign.StartDate = DateTime.Parse(request.saveCampaign.sStartDate);
                newcampaign.EndDate = DateTime.Parse(request.saveCampaign.sEndDate);
                newcampaign.IsEvaluationGenerated = false;
                newcampaign.Active = true;
                newcampaign.DateRegister = DateTime.Now;
                newcampaign.IdUserRegister = request.IdUsuario;
                newcampaign.DateUpdate = DateTime.Now;
                newcampaign.IdUserUpdate = request.IdUsuario;

                await baseCampaign.Add( newcampaign);
                nidCampaign = newcampaign.Id_Campaign;

                await _campaignRepository.RegisterDetailCampaingLevelNineBox(nidCampaign);
            }
            else
            {
                nidCampaign = request.saveCampaign.nIdCampaign;

                var currentCampaign = await baseCampaign.Find(nidCampaign);

                if (currentCampaign == null)
                {
                    return new Result
                    {
                        StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                        MessageError = new List<string>() { "No se encontró la campaña." }
                    };
                }

                currentCampaign.NameCampaign = request.saveCampaign.sNameCampaign;
                currentCampaign.Year = request.saveCampaign.nYear;
                currentCampaign.Month = request.saveCampaign.nMonth;
                currentCampaign.StartDate = DateTime.Parse(request.saveCampaign.sStartDate);
                currentCampaign.EndDate = DateTime.Parse(request.saveCampaign.sEndDate);
                currentCampaign.DateUpdate = DateTime.Now;
                currentCampaign.IdUserUpdate = request.IdUsuario;

                await baseCampaign.Update(currentCampaign);

            }

            var list_proficiencies = await _campaignRepository.ListProficienciesByCampaign(request.saveCampaign.nIdCampaign);
            foreach (var item in list_proficiencies)
            {
                item.Active = false;
                item.DateUpdate = DateTime.Now;
                item.IdUserUpdate = request.IdUsuario;

                await baseProficiencyCharge.Update(item);
            }




            foreach (var itemparent in request.saveCampaign.lstAssignProficiencies)
            {
                foreach (var item in itemparent.ProficiencyList)
                {
                    var entity = await _campaignRepository.FindProficiencyCharge(nidCampaign, itemparent.IdCharge ,item.IdProficiency);

                    if (entity == null)
                    {
                        Domain.Campaign.Models.ProficiencyCharge newpro_charge = new Domain.Campaign.Models.ProficiencyCharge();
                        newpro_charge.IdCampaign = nidCampaign;
                        newpro_charge.IdCharge = itemparent.IdCharge;
                        newpro_charge.IdProficiency = item.IdProficiency;
                        newpro_charge.Weight = item.Weight;
                        newpro_charge.Level = item.Level;

                        newpro_charge.Active = true;
                        newpro_charge.DateRegister = DateTime.Now;
                        newpro_charge.IdUserRegister = request.IdUsuario;
                        newpro_charge.DateUpdate = DateTime.Now;
                        newpro_charge.IdUserUpdate = request.IdUsuario;
                        await baseProficiencyCharge.Add(newpro_charge);
                    }
                    else
                    {
                        entity.Weight = item.Weight;
                        entity.Level = item.Level;
                        entity.Active = item.Active;
                        entity.DateUpdate = DateTime.Now;
                        entity.IdUserUpdate = request.IdUsuario;
                        await baseProficiencyCharge.Update(entity);
                    }
                }

            }


            await unitOfWork.Commit();
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                MessageError = new List<string>() { "Se guardó la campaña de manera correcta." }

            };

        }
    }
}
