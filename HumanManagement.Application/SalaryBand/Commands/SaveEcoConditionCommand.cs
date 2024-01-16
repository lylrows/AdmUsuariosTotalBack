using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.SalaryBand.Contracts;
using HumanManagement.Domain.SalaryBand.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.SalaryBand.Commands
{
    public class SaveEcoConditionCommand : IRequest<Result>
    {
        public SaveEconomicConditionDto newEconomicCondition { get; set; }
        public class SaveEcoConditionCommandHandler : IRequestHandler<SaveEcoConditionCommand, Result>
        {
            
            private readonly IBaseRepository<Domain.SalaryBand.Models.EconomicCondition> baseRepository;
            private readonly IEconomicConditionRepository economicRepository;
            private readonly IUnitOfWork unitOfWork;
            public SaveEcoConditionCommandHandler(
                 IUnitOfWork unitOfWork,
                IBaseRepository<Domain.SalaryBand.Models.EconomicCondition> baseRepository,
                IEconomicConditionRepository economicRepository
                )
            {
                
                this.unitOfWork = unitOfWork;
                this.baseRepository = baseRepository;
                this.economicRepository = economicRepository;
            }

            
            public async Task<Result> Handle(SaveEcoConditionCommand request, CancellationToken cancellationToken)
            {

                foreach (var cond in request.newEconomicCondition.conditions)
                {

                    var exiscond = await economicRepository.FindById(cond.IdEconomicCondition);

                    if (exiscond == null)
                    {
                        Domain.SalaryBand.Models.EconomicCondition newCondBd = new Domain.SalaryBand.Models.EconomicCondition();


                        newCondBd.IdEconomicCondition = cond.IdEconomicCondition;
                        newCondBd.Period = request.newEconomicCondition.currentPeriod;
                        newCondBd.IdCompany = cond.IdCompany;
                        newCondBd.IdEmployee = cond.IdEmployee;
                        newCondBd.BasicMonth = cond.BasicMonth;
                        newCondBd.OtherFixedMonth = cond.OtherFixedMonth;
                        newCondBd.VariableMonth = cond.VariableMonth;
                        newCondBd.Passive = cond.Passive;
                        newCondBd.OtherUnpaid = cond.OtherUnpaid;
                        newCondBd.AnnualBonus = cond.AnnualBonus;
                        newCondBd.MonthlyIncome = cond.MonthlyIncome;
                        newCondBd.AnnualCost = cond.AnnualCost;
                        newCondBd.Increase = cond.Increase;
                        newCondBd.IncreasePassive = cond.IncreasePassive;
                        newCondBd.VariationMontlyIncome = cond.VariationMontlyIncome;
                        newCondBd.VariationAnnualCost = cond.VariationAnnualCost;
                        newCondBd.Active = true;
                        newCondBd.Indicator = "P";
                        newCondBd.Month = request.newEconomicCondition.monthPeriod;


                        await baseRepository.Add(newCondBd);
                    }
                    else
                    {

                        exiscond.BasicMonth = cond.BasicMonth;
                        exiscond.OtherFixedMonth = cond.OtherFixedMonth;
                        exiscond.VariableMonth = cond.VariableMonth;
                        exiscond.Passive = cond.Passive;
                        exiscond.OtherUnpaid = cond.OtherUnpaid;
                        exiscond.AnnualBonus = cond.AnnualBonus;
                        exiscond.MonthlyIncome = cond.MonthlyIncome;
                        exiscond.AnnualCost = cond.AnnualCost;
                        exiscond.Increase = cond.Increase;
                        exiscond.IncreasePassive = cond.IncreasePassive;
                        exiscond.VariationMontlyIncome = cond.VariationMontlyIncome;
                        exiscond.VariationAnnualCost = cond.VariationAnnualCost;


                        await baseRepository.Update(exiscond);
                    }


                      var exiscondprev = await economicRepository.FindById(cond.PrevIdEconomicCondition);
                      
                      if (exiscondprev == null)
                      {
                          Domain.SalaryBand.Models.EconomicCondition newCondBd = new Domain.SalaryBand.Models.EconomicCondition();
                      
                      
                          newCondBd.IdEconomicCondition = cond.IdEconomicCondition;
                          newCondBd.Period = request.newEconomicCondition.previousPeriod;
                          newCondBd.IdCompany = cond.IdCompany;
                          newCondBd.IdEmployee = cond.IdEmployee;
                      
                          newCondBd.BasicMonth = cond.PrevBasicMonth;
                          newCondBd.OtherFixedMonth = cond.PrevOtherFixedMonth;
                          newCondBd.VariableMonth = cond.PrevVariableMonth;
                          newCondBd.Passive = cond.PrevPassive;
                          newCondBd.OtherUnpaid = cond.PrevOtherUnpaid;
                          newCondBd.AnnualBonus = cond.PrevAnnualBonus;
                          newCondBd.MonthlyIncome = cond.PrevMonthlyIncome;
                          newCondBd.AnnualCost = cond.PrevAnnualCost;
                          newCondBd.Active = true;
                          newCondBd.Indicator = "E";


                        await baseRepository.Add(newCondBd);
                      }
                      else
                      {
                      
                          exiscondprev.BasicMonth = cond.PrevBasicMonth;
                          exiscondprev.OtherFixedMonth = cond.PrevOtherFixedMonth;
                          exiscondprev.VariableMonth = cond.PrevVariableMonth;
                          exiscondprev.Passive = cond.PrevPassive;
                          exiscondprev.OtherUnpaid = cond.PrevOtherUnpaid;
                          exiscondprev.AnnualBonus = cond.PrevAnnualBonus;
                          exiscondprev.MonthlyIncome = cond.PrevMonthlyIncome;
                          exiscondprev.AnnualCost = cond.PrevAnnualCost;
                      
                      
                          await baseRepository.Update(exiscondprev);
                      }

                }

                await unitOfWork.Commit();
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    MessageError = new List<string>() { "Se guardó las condiciones económicas de manera correcta." }
                };
            }
        }
    }
}
