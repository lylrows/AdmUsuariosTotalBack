using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.SalaryBand.Contracts;
using HumanManagement.Domain.SalaryBand.Dto;
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
  
    public class GetEcoConditionXLSQuery : IRequest<Result>
    {
        public EcoConditionFilter ecoQueryFilter { get; set; }
        public class GetEcoConditionXLSQueryHandler : IRequestHandler<GetEcoConditionXLSQuery, Result>
        {
            private readonly ISalaryBandRepository _salarybandRepository;
            public GetEcoConditionXLSQueryHandler(ISalaryBandRepository salarybandRepository)
            {
                this._salarybandRepository = salarybandRepository;
            }
            public async Task<Result> Handle(GetEcoConditionXLSQuery query, CancellationToken cancellationToken)
            {
                var resultPagination = await _salarybandRepository.GetEcoConditionList(query.ecoQueryFilter);

                foreach (var item in resultPagination)
                {
                    item.Increase_ant = item.Increase;
                    item.IncreasePassive_ant = item.IncreasePassive;
                }

                DataTable dt = new DataTable();
                dt.TableName = "Informe";
                dt.Columns.Add($"CÓDIGO");
                dt.Columns.Add($"COLABORADOR");
                dt.Columns.Add($"CARGO");
                dt.Columns.Add($"AREA");
                dt.Columns.Add($"CONDICIÓN");
                dt.Columns.Add($"FECHA DE INGRESO");
                dt.Columns.Add($"ESPACIO1");
                dt.Columns.Add($"BÁSICO MES");
                dt.Columns.Add($"OTROS FIJOS MES");
                dt.Columns.Add($"VARIABLE MES");
                dt.Columns.Add($"PASI");
                dt.Columns.Add($"OTROS NO REMUNER.");
                dt.Columns.Add($"INGRESO MES");
                dt.Columns.Add($"BONO ANUAL");
                dt.Columns.Add($"COSTO ANUAL");
                dt.Columns.Add($"ESPACIO2");
                dt.Columns.Add($"VARIAC. INGRESO MES");
                dt.Columns.Add($"ESPACIO3");
                dt.Columns.Add($"BÁSICO MES 2");
                dt.Columns.Add($"INCREMENTO");
                dt.Columns.Add($"OTROS FIJOS MES 2");
                dt.Columns.Add($"VARIABLE MES 2");
                dt.Columns.Add($"PASI 2");
                dt.Columns.Add($"INCREMENTO PASI");
                dt.Columns.Add($"OTROS NO REMUNER. 2");
                dt.Columns.Add($"INGRESO MES 2");
                dt.Columns.Add($"BONO ANUAL 2");
                dt.Columns.Add($"COSTO ANUAL 2");
                dt.Columns.Add($"ESPACIO4");
                dt.Columns.Add($"VARIAC. COSTO ANUAL");





                string randmname = "Resumen de Presupuesto " + query.ecoQueryFilter.Period + " " + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss") + ".xlsx";
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", randmname);



                foreach (var item in resultPagination)
                {
                    DataRow row = dt.NewRow();

                    row[0] = item.CodEmployee;
                    row[1] = item.Colaborator;
                    row[2] = item.Position;
                    row[3] = item.AreaName;
                    row[4] = item.Condition;
                    row[5] = item.AdmissionDate;
                    row[6] = "";
                    row[7] = item.PrevBasicMonth;
                    row[8] = item.PrevOtherFixedMonth;
                    row[9] = item.PrevVariableMonth;
                    row[10] = item.PrevPassive;
                    row[11] = item.PrevOtherUnpaid;
                    row[12] = item.PrevMonthlyIncome;
                    row[13] = item.PrevAnnualBonus;
                    row[14] = item.PrevAnnualCost;
                    row[15] = "";
                    row[16] = item.VariationMontlyIncome == null ? "0.0" : string.Format("{0:0,0.0}", item.VariationMontlyIncome);
                    row[17] = "";
                    row[18] = item.BasicMonth;
                    row[19] = item.Increase;
                    row[20] = item.OtherFixedMonth;
                    row[21] = item.VariableMonth;
                    row[22] = item.Passive;
                    row[23] = item.IncreasePassive;
                    row[24] = item.OtherUnpaid;
                    row[25] = item.MonthlyIncome;
                    row[26] = item.AnnualBonus;
                    row[27] = item.AnnualCost;
                    row[28] = "";
                    row[29] = item.VariationAnnualCost == null ? "0.00" : string.Format("{0:0,0.0}", item.VariationAnnualCost);


                    dt.Rows.Add(row);
                }

                Functions.EconomicConditionXLS(dt, fullPath);



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
