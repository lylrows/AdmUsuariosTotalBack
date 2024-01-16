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
    public class GetSalaryStructureExportXLSQuery : IRequest<Result>
    {
        public SalaryStructureFilter filter { get; set; }
        public class GetSalaryStructureExportXLSQueryHandler : IRequestHandler<GetSalaryStructureExportXLSQuery, Result>
        {
            private readonly IEconomicConditionRepository economicConditionRepository;
            public GetSalaryStructureExportXLSQueryHandler(IEconomicConditionRepository economicConditionRepository)
            {
                this.economicConditionRepository = economicConditionRepository;
            }
            public async Task<Result> Handle(GetSalaryStructureExportXLSQuery query, CancellationToken cancellationToken)
            {
                var resultPagination = await economicConditionRepository.GetSalaryStructure(query.filter);

                List<SalaryStructureExporXLSList> result = new List<SalaryStructureExporXLSList>();
                
                foreach (var item in resultPagination)
                {
                    SalaryStructureExporXLSList objExport = new SalaryStructureExporXLSList();
                    objExport.CodEmployee = item.CodEmployee;
                    objExport.Colaborator = item.Colaborator;
                    objExport.Position = item.Position;
                    objExport.AreaName = item.AreaName;
                    objExport.CategoryName = item.CategoryName;
                    objExport.AdmissionDate = item.AdmissionDate;
                    objExport.YearsService = item.YearsService;
                    objExport.BasicMonth = item.BasicMonth;
                    objExport.Passive = item.Passive;
                    objExport.AverageEarnableIncome = item.AverageEarnableIncome;

                    objExport.OtherUnpaid = item.OtherUnpaid;
                    objExport.TotalSalary= item.TotalSalary;
                    objExport.Increase= item.Increase;
                    objExport.IncreasePassive = item.IncreasePassive;
                    objExport.IncreaseUnpaid = item.IncreaseUnpaid;
                    objExport.SalaryBandAmount = item.SalaryBandAmount;
                    objExport.TotalNewIncome = item.TotalNewIncome;
                    objExport.Lights = item.Lights;
                    objExport.StatusBandText = item.StatusBandText==null?"": item.StatusBandText;
                    objExport.MinimunPoint  = item.MinimunPoint;

                    objExport.MiddlePoint = item.MiddlePoint;
                    objExport.MaximunPoint = item.MaximunPoint;
                    objExport.PerBand = item.PerBand;
                    objExport.Banda1 = item.PerBand < -51 ? "o" : "";
                    objExport.Banda2 = item.PerBand > 51 && item.PerBand < -41 ? "o" : "";
                    objExport.Banda3 = item.PerBand > -41 && item.PerBand < -31 ? "o" : "";
                    objExport.Banda4 = item.PerBand > -31 && item.PerBand < -21 ? "o" : "";
                    objExport.Banda5 = item.PerBand > -21 && item.PerBand < -11 ? "o" : "";
                    objExport.Banda6 = item.PerBand > -11 && item.PerBand < 0 ? "o" : "";
                    objExport.Banda7 = item.PerBand > 0 && item.PerBand < 11 ? "o" : "";

                    objExport.Banda8 = item.PerBand > 11 && item.PerBand < 21 ? "o" : "";
                    objExport.Banda9 = item.PerBand > 21 && item.PerBand < 31 ? "o" : "";
                    objExport.Banda10 = item.PerBand > 31 && item.PerBand < 41 ? "o" : "";
                    objExport.Banda11 = item.PerBand > 41 && item.PerBand < 51 ? "o" : "";
                    objExport.Banda12 = item.PerBand > 51 && item.PerBand < 61 ? "o" : "";
                    objExport.Banda13 = item.PerBand > 61 && item.PerBand < 71 ? "o" : "";
                    objExport.Banda14 = item.PerBand > 71 && item.PerBand < 81 ? "o" : "";
                    objExport.Banda15 = item.PerBand > 81 && item.PerBand < 91 ? "o" : "";
                    objExport.Banda16 = item.PerBand > 91 && item.PerBand < 101 ? "o" : "";
                    objExport.Banda17 = item.PerBand > 101 && item.PerBand < 111 ? "o" : "";

                    objExport.Banda18 = item.PerBand > 111 && item.PerBand < 121 ? "o" : "";
                    objExport.Banda19 = item.PerBand > 121 && item.PerBand < 131 ? "o" : "";
                    objExport.Banda20 = item.PerBand > 131 && item.PerBand < 141 ? "o" : "";
                    objExport.Banda21 = item.PerBand > 141 && item.PerBand < 151 ? "o" : "";
                    objExport.Banda22 = item.PerBand > 151 ? "o" : "";

                    result.Add(objExport);
                }


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
