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
    public class AssignProficiencyCommand : IRequest<Result>
    {
        public AssignProficiencyDto assignProficiency { get; set; }
        public int IdUsuario { get; set; }
    }


    public class AssignProficiencyCommandHandler : IRequestHandler<AssignProficiencyCommand, Result>
    {
        private readonly IBaseRepository<Domain.Campaign.Models.ProficiencyCharge> baseRepository;
        private readonly ICampaignRepository _campaignRepository;
        
        private readonly IUnitOfWork unitOfWork;

        public AssignProficiencyCommandHandler(IBaseRepository<Domain.Campaign.Models.ProficiencyCharge> baseRepository,
                                    
                                    IUnitOfWork unitOfWork,
                                    ICampaignRepository campaignRepository)
        {
            this.baseRepository = baseRepository;
            
            this.unitOfWork = unitOfWork;
            this._campaignRepository = campaignRepository;
        }

        public async Task<Result> Handle(AssignProficiencyCommand request, CancellationToken cancellationToken)
        {

            var list_proficiencies = await _campaignRepository.ListProficienciesByCampaign(request.assignProficiency.IdCampaign);
            foreach (var item in list_proficiencies)
            {
                item.Active = false;
                item.DateUpdate = DateTime.Now;
                item.IdUserUpdate = request.IdUsuario;

                await baseRepository.Update(item);
            }


            foreach (var item in request.assignProficiency.ProficiencyList)
            {
                var entity = await _campaignRepository.FindProficiencyCharge(request.assignProficiency.IdCampaign, request.assignProficiency.IdCharge , item.IdProficiency);

                if (entity == null)
                {
                    Domain.Campaign.Models.ProficiencyCharge newpro_charge = new Domain.Campaign.Models.ProficiencyCharge();
                    newpro_charge.IdCampaign = request.assignProficiency.IdCampaign;
                    newpro_charge.IdCharge = request.assignProficiency.IdCharge;
                    newpro_charge.IdProficiency = item.IdProficiency;
                    newpro_charge.Active = true;
                    newpro_charge.Weight = item.Weight;
                    newpro_charge.Level = item.Level;

                    newpro_charge.DateRegister = DateTime.Now;
                    newpro_charge.IdUserRegister = request.IdUsuario;
                    newpro_charge.DateUpdate = DateTime.Now;
                    newpro_charge.IdUserUpdate = request.IdUsuario;
                    await baseRepository.Add(newpro_charge);
                }
                else
                {
                    entity.Weight = item.Weight;
                    entity.Level = item.Level;
                    entity.Active = item.Active;
                    entity.DateUpdate = DateTime.Now;
                    entity.IdUserUpdate = request.IdUsuario;
                    await baseRepository.Update(entity);
                }

            }

            await unitOfWork.Commit();
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                MessageError = new List<string>() { "Se asignaron las competencias de manera correcta" }

            };

        }
    }
}
