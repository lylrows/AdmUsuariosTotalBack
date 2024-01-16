using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Campaign.Dto;
using HumanManagement.Domain.Proficiency.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;

namespace HumanManagement.Application.Evaluation.Queries
{
    public class GetMyTeamResumeV2Query : IRequest<Result>
    {
        public MyTeamResumeFilterDto filter { get; set; }
        public class GetMyTeamResumeQueryHandler : IRequestHandler<GetMyTeamResumeV2Query, Result>
        {
            private readonly ICampaignRepository campaignRepository;
            private readonly IProficiencyRepository proficiencyRepository;
            public GetMyTeamResumeQueryHandler(IProficiencyRepository proficiencyRepository, ICampaignRepository campaignRepository)
            {
                this.proficiencyRepository = proficiencyRepository;
                this.campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetMyTeamResumeV2Query request, CancellationToken cancellationToken)
            {
                // Lista todas las competencias
                var proficienciesList = await proficiencyRepository.getListProficiencies();

                // Listas las competencias de acuerdo al filtro
                var myteamresumelist = await campaignRepository.GetMyTeamResume(request.filter);
                
                // Seteamos todos las competencias de acuerdo a la 
                //var listpro = myteamresumelist.Select(i => new { name = i.nameproficiency, max = 5 }).Distinct();
                var listpro = myteamresumelist;

                // Listado de competencias
                var resultadoslist = await campaignRepository.GetMyTeamResumeComp(request.filter);

                // Listado de objetivos
                var resultadosObj = await campaignRepository.GetMyTeamResumeObj(request.filter);

                List<MyTeamResumeCompDto> lista = new List<MyTeamResumeCompDto>();
                var listaEmpleado = resultadoslist.Select(i => new { i.nid_employee, i.semployeename, i.IdCampaign, i.Campaign }).Distinct();
                int contador0 = 0;
                var listaEmpleadoOrdenado = listaEmpleado.OrderBy(c => c.Campaign).ToList().OrderBy(x => x.semployeename).ToList();
                foreach (var item in listaEmpleadoOrdenado)
                {
                    contador0++;
                    MyTeamResumeCompDto objMyTeam = new MyTeamResumeCompDto();
                    objMyTeam.rowNum = contador0;
                    var maximo = resultadoslist.Where(c => c.nid_employee == item.nid_employee && c.IdCampaign == item.IdCampaign)
                                .Max(d => d.nnumberaction);
                    var cargo = resultadoslist.Where(c => c.nid_employee == item.nid_employee && c.IdCampaign == item.IdCampaign).FirstOrDefault();
                    objMyTeam.nid_employee = item.nid_employee;
                    objMyTeam.semployeename = item.semployeename;
                    objMyTeam.IdCampaign = item.IdCampaign;
                    objMyTeam.Campaign = item.Campaign;
                    objMyTeam.nnumberaction = maximo;

                    objMyTeam.isExpanded = false;
                    objMyTeam.nid_charge = cargo == null ? 0 : cargo.nid_position;
                    objMyTeam.snamecharge = cargo == null ? "" : cargo.snamecharge;

                    lista.Add(objMyTeam);
                }

                if (request.filter.etapas != "")
                {
                    var aAR_ETAPA = request.filter.etapas.Split(',');
                    resultadoslist = resultadoslist.Where(i => aAR_ETAPA.Contains(i.nnumberaction.ToString())).ToList();
                    resultadosObj = resultadosObj.Where(i => aAR_ETAPA.Contains(i.nnumberaction.ToString())).ToList();
                }

                #region Grafico Competencias - OLD
                var cargos = myteamresumelist.Select(i => new { i.nid_charge, i.snamecharge }).Distinct();
                List<MyTeamDataLineDto> data = new List<MyTeamDataLineDto>();
                List<MyTeamDataLineDto> compdata_initial = new List<MyTeamDataLineDto>();
                List<MyTeamDataLineDto> compdata_verification = new List<MyTeamDataLineDto>();
                List<MyTeamDataLineDto> compdata_evaluation = new List<MyTeamDataLineDto>();

                var empleados = resultadoslist.Select(i => new { i.nid_employee, i.semployeename }).Distinct();
                var list_employee_campaign = resultadoslist.Select(i => new { i.nid_employee, i.semployeename,i.IdCampaign,i.Campaign }).Distinct();
                var list_charges_campaign = resultadoslist.Select(i => new { i.nid_charge, i.snamecharge, i.IdCampaign, i.Campaign }).Distinct();
                foreach (var e in empleados)
               {
                   var newData = new MyTeamDataLineDto();
                   newData.name = e.semployeename;
                   newData.value = new List<decimal>();

                   foreach (var p in proficienciesList)
                   {
                       var searchinfo = resultadoslist.Where(i => i.nid_employee == e.nid_employee && i.nid_proficiency == p.nid_proficiency).FirstOrDefault();

                       if (searchinfo != null)
                       {
                           newData.value.Add(searchinfo.nqualification ?? 0);
                       }
                       else
                       {
                           newData.value.Add(0);
                       }
                   }
                   data.Add(newData);
               }
               data = data.OrderBy(i => i.name).ToList();
                
                #endregion
                var empleadosobj = resultadosObj.Select(i => i.semployeename).Distinct();
                var campaniasobj = resultadosObj.Select(i => i.snamecampaign).Distinct();
                List<MyTeamDataObjDto> dataobj = new List<MyTeamDataObjDto>();
                #region NINEBOX
                // Listado ninebox
                MyTeamResultadoFilterDto nineBoxFilterDto = new MyTeamResultadoFilterDto();
                nineBoxFilterDto.nidcompany = request.filter.companyid;
                nineBoxFilterDto.nidgerencia = request.filter.gerenciaid;
                nineBoxFilterDto.nidarea =  request.filter.areaid;
                nineBoxFilterDto.nidsubarea = request.filter.subareaid;
                nineBoxFilterDto.nidcargo =  request.filter.nidcargo;
                nineBoxFilterDto.nidcampana = request.filter.nidCampana;
                nineBoxFilterDto.nid_employee = request.filter.nid_employee;

                var objNineBox = await campaignRepository.GetNineBoxCopy(nineBoxFilterDto);

                var evaluaciones = objNineBox.Select(i => i.IdEvaluation).Distinct();

                var empleados_resultados = objNineBox.Select(i => i.NombreCompleto ).Distinct();
                var campaniasobj_resultados = objNineBox.Select(i => i.Campaign).Distinct();

                List<EvaluationDto> listresult = new List<EvaluationDto>();
                foreach (var idevaluation in evaluaciones)
                {
                    var details = objNineBox.Where(i => i.IdEvaluation == idevaluation).ToList();
                    var gr1 = details.Where(i => i.IdGroup == 1 && i.Expectativa != 0);
                    var gr2 = details.Where(i => i.IdGroup == 2);
                    var pond_meta_1 = gr1.Sum(i => i.Expectativa * i.Peso);
                    var pond_real_1 = gr1.Sum(i => i.Realidad * i.Peso);
                    var pond_meta_2 = gr2.Sum(i => i.Expectativa * i.Peso);
                    var pond_real_2 = gr2.Sum(i => i.Realidad * i.Peso);
                    var pond_1 = pond_real_1 / pond_meta_1;
                    var pond_2 = pond_real_2 / pond_meta_2;

                    EvaluationDto newninebox = new EvaluationDto();
                    newninebox.IdEvaluation = idevaluation;
                    newninebox.ObjetivoPorc = pond_1 * 100;
                    newninebox.CompetenciaPorc = pond_2 * 100;
                    newninebox.DNI = details[0].DNI;
                    newninebox.NombreCompleto = details[0].NombreCompleto;
                    newninebox.Cargo = details[0].Cargo;
                    newninebox.Area = details[0].Area;
                    newninebox.Compania = details[0].Compania;
                    newninebox.FotoUrl = details[0].FotoUrl;
                    //newninebox.IdCampania = details[0].IdCampaign;
                    newninebox.Campania = details[0].Campaign;
                    newninebox.FotoUrl = details[0].FotoUrl;
                    listresult.Add(newninebox);
                }

                #endregion
                //var empleados_barra = listresult.Select(i => i.NombreCompleto).Distinct();
                var empleados_barra = listresult.Select(i => new { i.NombreCompleto,i.Campania }).Distinct();
                //var campanias_barra = listresult.Select(i => i.Campania).Distinct();
                var campanias_barra = listresult.Select(i => new { i.NombreCompleto, i.Campania }).Distinct();

                //===========================================================================================
                //                      RESULTADOS - GRAFICO DE BARRAS - OBJETIVOS Y COMPETENCIAS
                //===========================================================================================
                #region GRAFICO - Objetivos y Competencias
                List<MyTeamDataObjDto> data_obj_comp = new List<MyTeamDataObjDto>();
                // Objetivo
                foreach (var emp in empleados_barra)
                {
                    MyTeamDataObjDto newData = new MyTeamDataObjDto();
                    newData.name = emp.NombreCompleto;
                    newData.title = "Objetivo";
                    newData.type = "bar";
                    newData.data = new List<decimal>();
                    newData.emphasis = new EmphasisDto()
                    {
                        focus = "series"
                    };
                    newData.label = new SeriesLabelDto()
                    {
                        show = true,
                        formatter = "Objetivo: {c} "+"% ",
                        position = "outside",
                        //fontSize: 8
                    };
                    foreach (var camp in campanias_barra)
                    {
                        var campobj = listresult.Where(i => i.NombreCompleto == emp.NombreCompleto && i.Campania == camp.Campania);
                        if (campobj.Any())
                        {
                            //foreach (var item in campobj)
                            //{
                            //    newData.data.Add(decimal.Round(Convert.ToDecimal(campobj.FirstOrDefault().ObjetivoPorc), 2, MidpointRounding.AwayFromZero));
                            //}
                            //newData.data.Add(decimal.Round(campobj, 2, MidpointRounding.AwayFromZero));
                            newData.data.Add(decimal.Round(Convert.ToDecimal(campobj.FirstOrDefault().ObjetivoPorc), 2, MidpointRounding.AwayFromZero));
                        }
                        else
                        {
                            newData.data.Add(0);
                        }
                    }
                    newData.nnumberaction = 11;
                    data_obj_comp.Add(newData);
                }

                //Competencia
                foreach (var emp in empleados_barra)
                {
                    MyTeamDataObjDto newData = new MyTeamDataObjDto();
                    newData.name = emp.NombreCompleto;
                    newData.title = "Competencia";
                    newData.type = "bar";


                    newData.data = new List<decimal>();

                    newData.emphasis = new EmphasisDto()
                    {
                        focus = "series"
                    };
                    newData.label = new SeriesLabelDto()
                    {
                        show = true,
                        formatter = "Competencia: {c}"+" % ",
                        position = "outside"
                    };
                    foreach (var camp in campanias_barra)
                    {
                        var campobj = listresult.Where(i => i.NombreCompleto == emp.NombreCompleto && i.Campania == camp.Campania);
                        if (campobj.Any())
                        {
                            newData.data.Add(decimal.Round(Convert.ToDecimal(campobj.FirstOrDefault().CompetenciaPorc), 2, MidpointRounding.AwayFromZero));

                        }
                        else
                        {
                            newData.data.Add(0);
                        }
                    }
                    newData.nnumberaction = 11;
                    data_obj_comp.Add(newData);

                }

                #endregion
                //=============================================================================================================
                //                           AVANCES - TABLA LISTADO 
                //=============================================================================================================
                // Listado 15/05/2023
                //var listMyTeamResume = await campaignRepository.GetMyTeamResumeList(request.filter);
                //var listaEmpleado_avances = listMyTeamResume.Select(i => new { i.IdEvaluated, i.EvaluatedName, i.IdCampaign, i.Campaign }).Distinct();
                //var listaCargos_avances = listMyTeamResume.Select(i => new { i.IdChargeEvaluated, i.ChargeEvaluated }).Distinct();
                //var listaCargos_Campanas_avances = listMyTeamResume.Select(i => new { i.IdChargeEvaluated, i.ChargeEvaluated, i.IdCampaign, i.Campaign }).Distinct();

                //// Para la tabla 
                //List<MyTeamResumeCompDto> listaEmpleadosTABLA = new List<MyTeamResumeCompDto>();
                //int contador = 0;
                //foreach (var item in listaEmpleado_avances)
                //{
                //    contador++;
                //    MyTeamResumeCompDto objMyTeam = new MyTeamResumeCompDto();
                //    objMyTeam.rowNum = contador;
                //    var maximo = listMyTeamResume.Where(c => c.IdEvaluated == item.IdEvaluated && c.IdCampaign == item.IdCampaign)
                //                .Max(d => d.NumberAction);
                //    var cargo = listMyTeamResume.Where(c => c.IdEvaluated == item.IdEvaluated && c.IdCampaign == item.IdCampaign).FirstOrDefault();
                //    objMyTeam.nid_employee = item.IdEvaluated;
                //    objMyTeam.semployeename = item.EvaluatedName;
                //    objMyTeam.IdCampaign = item.IdCampaign;
                //    objMyTeam.Campaign = item.Campaign;
                //    objMyTeam.nnumberaction = maximo;
                //    objMyTeam.isExpanded = false;
                //    objMyTeam.nid_charge = cargo == null ? 0 : cargo.IdChargeEvaluated;
                //    objMyTeam.snamecharge = cargo == null ? "" : cargo.ChargeEvaluated;
                //    listaEmpleadosTABLA.Add(objMyTeam);
                //}

                // Config Adicional - GRAFICO DE BARRAS - OBJETIVOS Y COMPETENCIAS
                data_obj_comp = data_obj_comp.OrderBy(i => i.name).ToList();
                if (data_obj_comp.Any())
                {
                    data_obj_comp[data_obj_comp.Count - 1].markLine = new MarkLineObj();
                    data_obj_comp[data_obj_comp.Count - 1].markLine.data = new List<MarkLineDataObj>();
                    data_obj_comp[data_obj_comp.Count - 1].markLine.data.Add(new MarkLineDataObj()
                    {

                        name = "Meta",
                        xAxis = 100,
                        label = new MarkLineLabelObj()
                        {
                            formatter = "{b}",
                            position = "start"
                        }
                    });
                    data_obj_comp[data_obj_comp.Count - 1].markLine.lineStyle = new LineStyleObj()
                    {
                        color = "#000000"
                    };

                }

                #region Grafico ARAÑA EVALUACION - V2
                List<MyTeamDataLineDto> lista_grafico_spider = new List<MyTeamDataLineDto>();
               
                #region CARGOS Y COMPETENCIAS
                foreach (var c in list_charges_campaign)
                {
                    var newData = new MyTeamDataLineDto();
                    newData.name = c.snamecharge + " Meta";
                    newData.value = new List<decimal>();
                    newData.nid_charge = c.nid_charge;
                    newData.nid_campaign = c.IdCampaign;
                    newData.snamecampaign = c.Campaign;
                    foreach (var p in proficienciesList)
                    {
                        var searchinfo = myteamresumelist.Where(i => i.nid_charge == c.nid_charge && i.nid_campaign == c.IdCampaign && i.nid_proficiency == p.nid_proficiency).FirstOrDefault();
                        if (searchinfo != null)
                        {
                            newData.value.Add(searchinfo.levelrequired);
                        }
                        else
                        {
                            newData.value.Add(0);
                        }
                    }
                    data.Add(newData);
                    compdata_initial.Add(newData);
                    compdata_verification.Add(newData);
                    lista_grafico_spider.Add(newData);
                }

                foreach (var e in list_employee_campaign)
                {
                    var newData = new MyTeamDataLineDto();
                    newData.name = e.semployeename;
                    newData.value = new List<decimal>();
                    newData.nnumberaction = 11;
                    newData.nid_charge = 0;
                    newData.nid_campaign = e.IdCampaign;
                    newData.snamecampaign = e.Campaign;
                    var searchCargo = resultadoslist.Where(i => i.nid_employee == e.nid_employee).FirstOrDefault();
                    if (searchCargo != null)
                    {
                        newData.nid_charge = searchCargo.nid_position;
                    }
                    foreach (var p in proficienciesList)
                    {
                        //var searchinfo = resultadoslist.Where(i => i.nid_employee == e.nid_employee && i.nid_proficiency == p.nid_proficiency && i.nnumberaction == 11).FirstOrDefault();
                        var searchinfo = resultadoslist.Where(i => i.nid_employee == e.nid_employee && i.IdCampaign==e.IdCampaign && i.nid_proficiency == p.nid_proficiency && i.nnumberaction == 11).FirstOrDefault();
                        if (searchinfo != null)
                        {
                            newData.value.Add(searchinfo.nqualification ?? 0);
                        }
                        else
                        {
                            newData.value.Add(0);
                        }
                    }
                    lista_grafico_spider.Add(newData);
                }

                #endregion


                #endregion


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = new
                    {
                        indicator = listpro,
                        data = data,
                        legends = data.Select(i => i.name).ToList(),
                        objdata = dataobj,

                        // Segunda Pestaña - Grafico de Barra
                        //objcategories = campaniasobj,
                        objcategories = campaniasobj_resultados,
                        //objlegend = empleadosobj.OrderBy(i => i).ToList(),
                        objlegend = empleados_resultados.OrderBy(i => i).ToList(),
                        data_obj_comp = data_obj_comp,

                        compdata_initial = compdata_initial,
                        compdata_verification = compdata_verification,
                        compdata_evaluation = compdata_evaluation

                        //Primera Pestaña
                        //,my_team_resume_list = listMyTeamResume
                        ,my_team_resume_listOLD = lista
                        ,my_team_resume_list = lista.OrderBy(c => c.Campaign).ToList().OrderBy(x => x.semployeename).ToList()// listaEmpleadosTABLA.OrderBy(c => c.Campaign).ToList().OrderBy(x => x.semployeename).ToList()
                        //,legends_tabla = lista_grafico_spider.Select(i => i.name).ToList().OrderBy(o => o).ToList()
                        ,legends_tabla = data.Select(i => i.name).ToList()
                        ,compdata_evaluation_individual = lista_grafico_spider
                    }
                };
            }
        }
    }
}