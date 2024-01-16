using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.SalaryBand.Contracts;
using HumanManagement.Domain.SalaryBand.Dto;
using HumanManagement.Domain.SalaryBand.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.SalaryBand.Queries
{
    public class GetBudgetResumeQuery : IRequest<Result>
    {

        public BudgetFilterDto budgetFilter { get; set; }
        public class GetBudgetResumeQueryHandler : IRequestHandler<GetBudgetResumeQuery, Result>
        {
            private readonly IBudgetRepository _budgetRepository;
            private readonly IBaseRepository<AreaGroup> _baseAreaGroupRepository;
            public GetBudgetResumeQueryHandler(IBudgetRepository budgetRepository, IBaseRepository<AreaGroup> baseAreaGroupRepository)
            {
                this._budgetRepository = budgetRepository;
                this._baseAreaGroupRepository = baseAreaGroupRepository;
            }
            public async Task<Result> Handle(GetBudgetResumeQuery query, CancellationToken cancellationToken)
            {
                var listainicial = await _budgetRepository.GetBudgetList(query.budgetFilter);

                List<BudgetListDto> listreturn = new List<BudgetListDto>();

                var groups = await _baseAreaGroupRepository.GetAll();


                foreach (var item in groups.OrderBy(i => i.Order))
                {

                    BudgetListDto newGroup = new BudgetListDto();
                    newGroup.IdAreaGroup = item.IdAreaGroup;
                    newGroup.IsGroup = true;
                    newGroup.NameGroup = item.NameGroup;
                    newGroup.NameArea = item.NameGroup;
                    newGroup.CurrentAmount = listainicial.Where(i => i.IdAreaGroup == item.IdAreaGroup).Sum(i => i.CurrentAmount);
                    newGroup.PreviousAmount = listainicial.Where(i => i.IdAreaGroup == item.IdAreaGroup).Sum(i => i.PreviousAmount);
                    newGroup.PreviousExecAmount = listainicial.Where(i => i.IdAreaGroup == item.IdAreaGroup).Sum(i => i.PreviousExecAmount);
                    newGroup.PreviousExecAmount1 = listainicial.Where(i => i.IdAreaGroup == item.IdAreaGroup).Sum(i => i.PreviousExecAmount1);
                    newGroup.PreviousExecAmount2 = listainicial.Where(i => i.IdAreaGroup == item.IdAreaGroup).Sum(i => i.PreviousExecAmount2);
                    newGroup.CurrentExecAmount = listainicial.Where(i => i.IdAreaGroup == item.IdAreaGroup).Sum(i => i.CurrentExecAmount);

                    if (newGroup.PreviousExecAmount == 0)
                    {
                        newGroup.VariationPorc = 0;
                    }
                    else
                    {
                        if (query.budgetFilter.PeriodVariation == query.budgetFilter.Period - 1)
                        {
                            if (newGroup.PreviousExecAmount == 0)
                                newGroup.VariationPorc = 0;
                            else
                                newGroup.VariationPorc = (newGroup.CurrentAmount / newGroup.PreviousExecAmount) - 1;
                        }
                        else if (query.budgetFilter.PeriodVariation == query.budgetFilter.Period - 2)
                        {
                            if (newGroup.PreviousExecAmount1 ==0)
                                newGroup.VariationPorc = 0;
                            else
                                newGroup.VariationPorc = (newGroup.CurrentAmount / newGroup.PreviousExecAmount1) - 1;
                        }
                        else if (query.budgetFilter.PeriodVariation == query.budgetFilter.Period - 3)
                        {

                            if (newGroup.PreviousExecAmount2 == 0)
                                newGroup.VariationPorc = 0;
                            else
                                newGroup.VariationPorc = (newGroup.CurrentAmount / newGroup.PreviousExecAmount2) - 1;
                        }
                    }


                    if (query.budgetFilter.PeriodVariation == query.budgetFilter.Period - 1)
                    {
                        newGroup.VariationAmount = newGroup.CurrentAmount - newGroup.PreviousExecAmount;
                    }
                    else if (query.budgetFilter.PeriodVariation == query.budgetFilter.Period - 2)
                    {
                        newGroup.VariationAmount = newGroup.CurrentAmount - newGroup.PreviousExecAmount1;

                    }
                    else if (query.budgetFilter.PeriodVariation == query.budgetFilter.Period - 3)
                    {
                        newGroup.VariationAmount = newGroup.CurrentAmount - newGroup.PreviousExecAmount2;

                    }


                    listreturn.Add(newGroup);



                    foreach (var item_2 in listainicial.Where(i => i.IdAreaGroup == item.IdAreaGroup))
                    {

                        if (item_2.PreviousExecAmount == 0)
                        {
                            item_2.VariationPorc = 0;
                        }
                        else
                        {

                            if (query.budgetFilter.PeriodVariation == query.budgetFilter.Period - 1)
                            {
                                if (item_2.PreviousExecAmount == 0)
                                    item_2.VariationPorc = 0;
                                else
                                    item_2.VariationPorc = (item_2.CurrentAmount / item_2.PreviousExecAmount) - 1;
                            }
                            else if (query.budgetFilter.PeriodVariation == query.budgetFilter.Period - 2)
                            {
                                if (item_2.PreviousExecAmount1 == 0)
                                    item_2.VariationPorc = 0;
                                else
                                    item_2.VariationPorc = (item_2.CurrentAmount / item_2.PreviousExecAmount1) - 1;
                            }
                            else if (query.budgetFilter.PeriodVariation == query.budgetFilter.Period - 3)
                            {
                                if (item_2.PreviousExecAmount2 == 0)
                                    item_2.VariationPorc = 0;
                                else
                                    item_2.VariationPorc = (item_2.CurrentAmount / item_2.PreviousExecAmount2) - 1;
                            }
                        }
                        

                        if (query.budgetFilter.PeriodVariation == query.budgetFilter.Period - 1)
                        {
                            item_2.VariationAmount = item_2.CurrentAmount - item_2.PreviousExecAmount;
                        }
                        else if (query.budgetFilter.PeriodVariation == query.budgetFilter.Period - 2)
                        {
                            item_2.VariationAmount = item_2.CurrentAmount - item_2.PreviousExecAmount1;
                        }
                        else if (query.budgetFilter.PeriodVariation == query.budgetFilter.Period - 3)
                        {
                            item_2.VariationAmount = item_2.CurrentAmount - item_2.PreviousExecAmount2;
                        }



                        listreturn.Add(item_2);
                    }
                }
                foreach (var item in listreturn)
                {
                    item.VariationPorc = item.VariationPorc * 100;
                }
                if (query.budgetFilter.IdAreaGroup > 0)
                {
                    listreturn = listreturn.Where(i => i.IdAreaGroup == query.budgetFilter.IdAreaGroup).ToList();
                }




                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = listreturn
                };
            }
        }
    }
}
