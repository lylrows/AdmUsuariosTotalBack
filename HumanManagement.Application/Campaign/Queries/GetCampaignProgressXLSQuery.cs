using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Campaign.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Campaign.Queries
{


    public class GetCampaignProgressXLSQuery : IRequest<Result>
    {
        public CampaignProgressFilterDto filter { get; set; }
        public class GetCampaignProgressXLSQueryHandler : IRequestHandler<GetCampaignProgressXLSQuery, Result>
        {
            private readonly ICampaignRepository campaignRepository;
            public GetCampaignProgressXLSQueryHandler(ICampaignRepository campaignRepository)
            {
                this.campaignRepository = campaignRepository;
            }
            public async Task<Result> Handle(GetCampaignProgressXLSQuery query, CancellationToken cancellationToken)
            {
                var resultPagination = await campaignRepository.GetCampaignProgress(query.filter);

                DataTable dt = new DataTable();
                dt.TableName = "Informe";

                dt.Columns.Add("Evaluación");
                dt.Columns.Add("Campaña");
                dt.Columns.Add("Etapa");
                dt.Columns.Add("Sub - Etapa");

                dt.Columns.Add("Evaluador");
                dt.Columns.Add("Cargo Evaluador");
                dt.Columns.Add("Gerencia Evaluador");
                dt.Columns.Add("Área Evaluador");
                dt.Columns.Add("Sub-Area Evaluador");


                dt.Columns.Add("Evaluado");
                dt.Columns.Add("Cargo Evaluado");
                dt.Columns.Add("Gerencia Evaluado");
                dt.Columns.Add("Área Evaluado");
                dt.Columns.Add("Sub-Area Evaluado");

                string randmname = "Reporte de Avance " + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss") + ".xlsx";
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", randmname);

                foreach (var item in resultPagination)
                {
                    DataRow row = dt.NewRow();

                     
                    row[0] = item.IdEvaluation;       
                    row[1] = item.CampaignName;       
                    row[2] = item.TimePartDescription;
                    row[3] = item.numberActionName;   

                    row[4] = item.EvaluatorName;      
                    row[5] = item.ChargeEvaluator;    
                    row[6] = item.GERENCIA_BOSS;      
                    row[7] = item.AREA_BOSS;          
                    row[8] = item.SUBAREA_BOSS;       

                    row[9] = item.EvaluatedName;      
                    row[10] = item.ChargeEvaluated;    
                    row[11] = item.GERENCIA;           
                    row[12] = item.AREA;              
                    row[13] = item.SUBAREA;           

                                            
                    dt.Rows.Add(row);
                }

                Functions.DataTableToExcelWithStyle(dt, fullPath);


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
