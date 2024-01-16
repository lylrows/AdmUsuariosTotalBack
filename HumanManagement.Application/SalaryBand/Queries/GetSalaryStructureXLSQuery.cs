using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.SalaryBand.Contracts;
using HumanManagement.Domain.SalaryBand.Dto;
using MediatR;
using System;

using System.Data;
using System.IO;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.SalaryBand.Queries
{
    public class GetSalaryStructureXLSQuery : IRequest<Result>
    {
        public SalaryStructureFilter filter { get; set; }
        public class GetSalaryStructureXLSQueryHandler : IRequestHandler<GetSalaryStructureXLSQuery, Result>
        {
            private readonly IEconomicConditionRepository economicConditionRepository;
            public GetSalaryStructureXLSQueryHandler(IEconomicConditionRepository economicConditionRepository)
            {
                this.economicConditionRepository = economicConditionRepository;
            }
            public async Task<Result> Handle(GetSalaryStructureXLSQuery query, CancellationToken cancellationToken)
            {
                var resultPagination = await economicConditionRepository.GetSalaryStructure(query.filter);

                DataTable dt = new DataTable();
                dt.TableName = "Informe";

                dt.Columns.Add("Código");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Cargo");
                dt.Columns.Add("Área");
                dt.Columns.Add("Categoría");
                dt.Columns.Add("Fecha Ingreso");
                dt.Columns.Add("Años de Servicio");
                dt.Columns.Add("Sueldo Básico");
                dt.Columns.Add("PASI");
                dt.Columns.Add("PROMEDIO DE INGRESOS VARIABLES");
                dt.Columns.Add("OTROS INGRESOS NO REMUNERATIVOS");
                dt.Columns.Add("TOTAL SUELDO ");
                dt.Columns.Add("Incremento Básico");
                dt.Columns.Add("Incremento de PASI");
                dt.Columns.Add("Incremento de Ing. No Remun.");
                dt.Columns.Add("SUELDO PARA BANDA");
                dt.Columns.Add("Total Nuevos Ingresos ");
                dt.Columns.Add("SEMAFORO DE ALERTA");
                dt.Columns.Add("Estado en Banda");
                dt.Columns.Add("Mínimo S/");
                dt.Columns.Add("Medio S/");
                dt.Columns.Add("Máximo S/");
                dt.Columns.Add("PER BANDA %");
                dt.Columns.Add("Banda1");
                dt.Columns.Add("Banda2");
                dt.Columns.Add("Banda3");
                dt.Columns.Add("Banda4");
                dt.Columns.Add("Banda5");
                dt.Columns.Add("Banda6");
                dt.Columns.Add("Banda7");
                dt.Columns.Add("Banda8");
                dt.Columns.Add("Banda9");
                dt.Columns.Add("Banda10");
                dt.Columns.Add("Banda11");
                dt.Columns.Add("Banda12");
                dt.Columns.Add("Banda13");
                dt.Columns.Add("Banda14");
                dt.Columns.Add("Banda15");
                dt.Columns.Add("Banda16");
                dt.Columns.Add("Banda17");
                dt.Columns.Add("Banda18");
                dt.Columns.Add("Banda19");
                dt.Columns.Add("Banda20");
                dt.Columns.Add("Banda21");
                dt.Columns.Add("Banda22");

                string randmname = "Estructura Salarial " + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss") + ".xlsx";
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", randmname);

                foreach (var item in resultPagination)
                {
                    DataRow row = dt.NewRow();
                    row[0] = item.CodEmployee;
                    row[1] = item.Colaborator;
                    row[2] = item.Position;
                    row[3] = item.AreaName;
                    row[4] = item.CategoryName;
                    row[5] = item.AdmissionDate;
                    row[6] = item.YearsService;
                    row[7] = item.BasicMonth;
                    row[8] = item.Passive;
                    row[9] = item.AverageEarnableIncome;

                    row[10] = item.OtherUnpaid;
                    row[11] = item.TotalSalary;
                    row[12] = item.Increase;
                    row[13] = item.IncreasePassive;
                    row[14] = item.IncreaseUnpaid;
                    row[15] = item.SalaryBandAmount;
                    row[16] = item.TotalNewIncome;
                    row[17] = item.Lights;
                    row[18] = item.StatusBandText;
                    row[19] = item.MinimunPoint;

                    row[20] = item.MiddlePoint;
                    row[21] = item.MaximunPoint;
                    row[22] = item.PerBand;
                    row[23] = item.PerBand < -51 ? "o" : "";
                    row[24] = item.PerBand > 51 &&  item.PerBand < -41 ? "o" : "";
                    row[25] = item.PerBand > -41 && item.PerBand < -31 ? "o" : "";
                    row[26] = item.PerBand > -31 && item.PerBand < -21 ? "o" : "";
                    row[27] = item.PerBand > -21 && item.PerBand < -11 ? "o" : "";
                    row[28] = item.PerBand > -11 && item.PerBand < 0 ? "o" : "";
                    row[29] = item.PerBand > 0 &&   item.PerBand < 11 ? "o" : "";

                    row[30] = item.PerBand > 11 &&  item.PerBand < 21 ? "o" : "";
                    row[31] = item.PerBand > 21 &&  item.PerBand < 31 ? "o" : "";
                    row[32] = item.PerBand > 31 &&  item.PerBand < 41 ? "o" : "";
                    row[33] = item.PerBand > 41 &&  item.PerBand < 51 ? "o" : "";
                    row[34] = item.PerBand > 51 &&  item.PerBand < 61 ? "o" : "";
                    row[35] = item.PerBand > 61 &&  item.PerBand < 71 ? "o" : "";
                    row[36] = item.PerBand > 71 &&  item.PerBand < 81 ? "o" : "";
                    row[37] = item.PerBand > 81 &&  item.PerBand < 91 ? "o" : "";
                    row[38] = item.PerBand > 91 &&  item.PerBand < 101 ? "o" : "";
                    row[39] = item.PerBand > 101 && item.PerBand < 111 ? "o" : "";

                    row[40] = item.PerBand > 111 && item.PerBand < 121 ? "o" : "";
                    row[41] = item.PerBand > 121 && item.PerBand < 131 ? "o" : "";
                    row[42] = item.PerBand > 131 && item.PerBand < 141 ? "o" : "";
                    row[43] = item.PerBand > 141 && item.PerBand < 151 ? "o" : "";
                    row[44] = item.PerBand > 151 ? "o" : "";

                    dt.Rows.Add(row);
                }


                Functions.StructureSalaryXLS(dt, fullPath);


                Byte[] bytes = System.IO.File.ReadAllBytes(fullPath);
                String filestring = Convert.ToBase64String(bytes);

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
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
