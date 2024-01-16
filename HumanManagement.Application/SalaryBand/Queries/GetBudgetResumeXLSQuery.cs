using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.SalaryBand.Contracts;
using HumanManagement.Domain.SalaryBand.Dto;
using HumanManagement.Domain.SalaryBand.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.SalaryBand.Queries
{
    
    public class GetBudgetResumeXLSQuery : IRequest<Result>
    {

        public BudgetFilterDto budgetFilter { get; set; }
        public class GetBudgetResumeXLSQueryHandler : IRequestHandler<GetBudgetResumeXLSQuery, Result>
        {
            private readonly IBudgetRepository _budgetRepository;
            private readonly IBaseRepository<AreaGroup> _baseAreaGroupRepository;
            public GetBudgetResumeXLSQueryHandler(IBudgetRepository budgetRepository, IBaseRepository<AreaGroup> baseAreaGroupRepository)
            {
                this._budgetRepository = budgetRepository;
                this._baseAreaGroupRepository = baseAreaGroupRepository;
            }
            public async Task<Result> Handle(GetBudgetResumeXLSQuery query, CancellationToken cancellationToken)
            {
                var listainicial = await _budgetRepository.GetBudgetList(query.budgetFilter);

                List<BudgetListDto> listreturn = new List<BudgetListDto>();

                var groups = await _baseAreaGroupRepository.GetAll();

                int currentPeriod = query.budgetFilter.Period;
                int previousPeriod = query.budgetFilter.Period - 1;



                foreach (var item in groups.OrderBy(i => i.Order))
                {

                    BudgetListDto newGroup = new BudgetListDto();
                    newGroup.IdAreaGroup = item.IdAreaGroup;
                    newGroup.IsGroup = true;
                    newGroup.NameGroup = item.NameGroup;
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
                            if (newGroup.PreviousExecAmount1 == 0)
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


                DataTable dt = new DataTable();
                dt.TableName = "Informe";
                dt.Columns.Add("AREA");
                dt.Columns.Add($"EJECUTADO {previousPeriod -2}");
                dt.Columns.Add($"EJECUTADO {previousPeriod -1}");
                dt.Columns.Add($"EJECUTADO {previousPeriod}");
                dt.Columns.Add($"EJECUTADO {currentPeriod}");
                dt.Columns.Add($"PRESUPUESTO {previousPeriod}");
                dt.Columns.Add($"PRESUPUESTO {currentPeriod}");
                dt.Columns.Add($"VAR P{currentPeriod} vs E{query.budgetFilter.PeriodVariation} %");
                dt.Columns.Add($"VAR P{currentPeriod} vs E{query.budgetFilter.PeriodVariation} S/.");
                dt.Columns.Add($"ISGROUP");
                string randmname = "Resumen de Presupuesto "+ currentPeriod+" " + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss") + ".xlsx";
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", randmname);


                decimal totalPreviousExecAmount2=0;
                decimal totalPreviousExecAmount1=0;
                decimal totalPreviousExecAmount =0;
                decimal totalCurrentExecAmount  =0;
                decimal totalPreviousAmount     =0;
                decimal totalCurrentAmount      =0;
                decimal totalVariationPorc      =0;
                decimal totalVariationAmount    = 0;

                foreach (var item in listreturn)
                {
                    DataRow row = dt.NewRow();

                    row[0] = item.IsGroup == true ? item.NameGroup : item.NameArea;
                    row[1] = String.Format("{0:n}", item.PreviousExecAmount2);
                    row[2] = String.Format("{0:n}", item.PreviousExecAmount1);
                    row[3] = String.Format("{0:n}", item.PreviousExecAmount);
                    row[4] = String.Format("{0:n}", item.CurrentExecAmount); 
                    row[5] = String.Format("{0:n}", item.PreviousAmount); 
                    row[6] = String.Format("{0:n}", item.CurrentAmount); 
                    row[7] = String.Format("{0:n}", (item.VariationPorc * 100)) + " %"; 
                    row[8] = String.Format("{0:n}", item.VariationAmount); 
                    row[9] = item.IsGroup == true ? "1" : "0";


                    totalPreviousExecAmount2+=item.PreviousExecAmount2  ;
                    totalPreviousExecAmount1+=item.PreviousExecAmount1 ;
                    totalPreviousExecAmount +=item.PreviousExecAmount   ;
                    totalCurrentExecAmount  +=item.CurrentExecAmount    ;
                    totalPreviousAmount     +=item.PreviousAmount       ;
                    totalCurrentAmount      +=item.CurrentAmount        ;
                    totalVariationPorc      +=item.VariationPorc  *100      ;
                    totalVariationAmount    +=   item.VariationAmount;

                    dt.Rows.Add(row);
                }


                totalVariationPorc = ((totalCurrentAmount / totalPreviousExecAmount) - 1)*100;

                Functions.BudgetResumeXLS(dt, fullPath, currentPeriod
                     ,totalPreviousExecAmount2
                     ,totalPreviousExecAmount1
                     ,totalPreviousExecAmount
                     ,totalCurrentExecAmount
                     ,totalPreviousAmount
                     ,totalCurrentAmount
                     ,totalVariationPorc
                     ,totalVariationAmount
                    );



                Byte[] bytes = System.IO.File.ReadAllBytes(fullPath);
                String filestring = Convert.ToBase64String(bytes);

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = filestring
                };
            }
        }
    }

}
