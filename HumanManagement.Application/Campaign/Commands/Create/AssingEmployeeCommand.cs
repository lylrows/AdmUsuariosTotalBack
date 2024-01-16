using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Campaign.Dto;
using HumanManagement.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Commands.Create
{
    public class AssingEmployeeCommand : IRequest<Result>
    {
        public AssignEmployeeDto assignEmployee { get; set; }
        public int IdUsuario { get; set; }
    }

    public class AssingEmployeeCommandHandler : IRequestHandler<AssingEmployeeCommand, Result>
    {
        private readonly IBaseRepository<Domain.Campaign.Models.CampaignEmployee> baseRepository;
        private readonly ICampaignRepository _campaignRepository;
        
        private readonly IUnitOfWork unitOfWork;

        public AssingEmployeeCommandHandler(IBaseRepository<Domain.Campaign.Models.CampaignEmployee> baseRepository,
                                    IUnitOfWork unitOfWork,
                                    ICampaignRepository campaignRepository)
        {
            this.baseRepository = baseRepository;
            this.unitOfWork = unitOfWork;
            this._campaignRepository = campaignRepository;
        }
        
        public async Task<Result> Handle(AssingEmployeeCommand request, CancellationToken cancellationToken)
        {
            
            foreach (var item in request.assignEmployee.Employelist)
            {
                var entity = await _campaignRepository.FindCampaignEmployee(request.assignEmployee.IdCampaign, item.IdEmployee);

                if (entity == null)
                {
                    Domain.Campaign.Models.CampaignEmployee newcamp_employ = new Domain.Campaign.Models.CampaignEmployee();
                    newcamp_employ.IdCampaign = request.assignEmployee.IdCampaign;
                    newcamp_employ.IdEmployee = item.IdEmployee;
                    newcamp_employ.IdCharge = item.IdPosition;
                    newcamp_employ.Active = true;
                    newcamp_employ.DateRegister = DateTime.Now;
                    newcamp_employ.IdUserRegister = request.IdUsuario;
                    newcamp_employ.DateUpdate = DateTime.Now;
                    newcamp_employ.IdUserUpdate = request.IdUsuario;
                    await baseRepository.Add(newcamp_employ);
                }
                else
                {
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
                MessageError = new List<string>() { "Se asignaron los empleados de manera correcta" }

            };

        }
    }
}
