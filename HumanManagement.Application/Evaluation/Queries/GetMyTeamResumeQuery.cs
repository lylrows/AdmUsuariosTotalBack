using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Campaign.Dto;
using HumanManagement.Domain.Proficiency.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Evaluation.Queries
{
 
    public class GetMyTeamResumeQuery : IRequest<Result>
    {
        public MyTeamResumeFilterDto filter { get; set; }
        public class GetMyTeamResumeQueryHandler : IRequestHandler<GetMyTeamResumeQuery, Result>
        {
            private readonly ICampaignRepository campaignRepository;
            private readonly IProficiencyRepository proficiencyRepository;
            public GetMyTeamResumeQueryHandler(IProficiencyRepository proficiencyRepository, ICampaignRepository campaignRepository)
            {
                this.proficiencyRepository = proficiencyRepository;
                this.campaignRepository = campaignRepository;
            }


            public async Task<Result> Handle(GetMyTeamResumeQuery request, CancellationToken cancellationToken)
            {
                var proficienciesList = await proficiencyRepository.getListProficiencies();

        
                
                var myteamresumelist = await campaignRepository.GetMyTeamResume(request.filter);


                var listpro = myteamresumelist.Select(i => new { name= i.nameproficiency , max=5}).Distinct();


                var resultadoslist = await campaignRepository.GetMyTeamResumeComp(request.filter);

                var resultadosObj = await campaignRepository.GetMyTeamResumeObj(request.filter);



                if (request.filter.etapas != "")
                {

                    var aAR_ETAPA = request.filter.etapas.Split(',');

                    resultadoslist = resultadoslist.Where(i => aAR_ETAPA.Contains(i.nnumberaction.ToString())).ToList();
                    resultadosObj = resultadosObj.Where(i => aAR_ETAPA.Contains(i.nnumberaction.ToString())).ToList();

                }



                #region Grafico Competencias

                var cargos = myteamresumelist.Select(i => new { i.nid_charge, i.snamecharge }).Distinct();

                List<MyTeamDataLineDto> data = new List<MyTeamDataLineDto>();

                List<MyTeamDataLineDto> compdata_initial = new List<MyTeamDataLineDto>();
                List<MyTeamDataLineDto> compdata_verification = new List<MyTeamDataLineDto>();
                List<MyTeamDataLineDto> compdata_evaluation = new List<MyTeamDataLineDto>();


                var empleados = resultadoslist.Select(i => new { i.nid_employee, i.semployeename }).Distinct();

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
                #region CompDataInicial

                foreach (var e in empleados)
                {
                    var newData = new MyTeamDataLineDto();
                    newData.name = e.semployeename;
                    newData.value = new List<decimal>();
                    newData.nnumberaction = 3;

                    foreach (var p in proficienciesList)
                    {
                        var searchinfo = resultadoslist.Where(i => i.nid_employee == e.nid_employee && i.nid_proficiency == p.nid_proficiency && i.nnumberaction==3).FirstOrDefault();

                        if (searchinfo != null)
                        {
                            newData.value.Add(searchinfo.nqualification ?? 0);
                        }
                        else
                        {
                            newData.value.Add(0);
                        }
                    }
                    compdata_initial.Add(newData);
                }
                #endregion

                #region CompDataVerificacion

                foreach (var e in empleados)
                {
                    var newData = new MyTeamDataLineDto();
                    newData.name = e.semployeename;
                    newData.value = new List<decimal>();
                    newData.nnumberaction = 7;

                    foreach (var p in proficienciesList)
                    {
                        var searchinfo = resultadoslist.Where(i => i.nid_employee == e.nid_employee && i.nid_proficiency == p.nid_proficiency && i.nnumberaction == 7).FirstOrDefault();

                        if (searchinfo != null)
                        {
                            newData.value.Add(searchinfo.nqualification ?? 0);
                        }
                        else
                        {
                            newData.value.Add(0);
                        }
                    }
                    compdata_verification.Add(newData);
                }
                #endregion

                #region CompDataEvaluacion

                foreach (var e in empleados)
                {
                    var newData = new MyTeamDataLineDto();
                    newData.name = e.semployeename;
                    newData.value = new List<decimal>();
                    newData.nnumberaction = 11;

                    foreach (var p in proficienciesList)
                    {
                        var searchinfo = resultadoslist.Where(i => i.nid_employee == e.nid_employee && i.nid_proficiency == p.nid_proficiency && i.nnumberaction == 11).FirstOrDefault();

                        if (searchinfo != null)
                        {
                            newData.value.Add(searchinfo.nqualification ?? 0);
                        }
                        else
                        {
                            newData.value.Add(0);
                        }
                    }
                    compdata_evaluation.Add(newData);
                }
                #endregion





                foreach (var c in cargos)
                {
                    var newData = new MyTeamDataLineDto();
                    newData.name =  c.snamecharge+ " Meta";
                    newData.value = new List<decimal>();

                    foreach (var p in proficienciesList)
                    {
                        var searchinfo = myteamresumelist.Where(i => i.nid_charge == c.nid_charge && i.nid_proficiency == p.nid_proficiency).FirstOrDefault();

                        if (searchinfo != null)
                        {
                            newData.value.Add(searchinfo.levelrequired);
                        }
                        else {
                            newData.value.Add(0);
                        }
                    }
                    data.Add(newData);

                    compdata_initial.Add(newData);
                    compdata_verification.Add(newData);
                    compdata_evaluation.Add(newData);

                }


                #endregion


                var empleadosobj = resultadosObj.Select(i => i.semployeename).Distinct();

                var campaniasobj = resultadosObj.Select(i => i.snamecampaign).Distinct();

                List<MyTeamDataObjDto> dataobj = new List<MyTeamDataObjDto>();

                foreach (var emp in empleadosobj)
                {
                    MyTeamDataObjDto newData = new MyTeamDataObjDto();
                    newData.name = emp ;
                    newData.title = "Verificación";
                    newData.type = "bar";
                   

                    newData.data = new List<decimal>();
                    
                    newData.emphasis = new EmphasisDto()
                    {
                        focus = "series"
                    };
                    newData.label = new SeriesLabelDto() { 
                        show = true,
                         formatter= "Verificación: {c}",
                         position= "outside"

                    };
                    foreach (var camp in campaniasobj)
                    {

                        var campobj = resultadosObj.Where(i => i.semployeename == emp && i.snamecampaign == camp && i.nnumberaction== 7); 

                        if (campobj.Any())
                        {
                            decimal pond_meta_1 = campobj.Sum(i => i.ngoal * i.nweight);
                            decimal pond_real_1 = campobj.Sum(i => i.nprogress * i.nweight);

                            decimal pond_1 = 0;
                            if (pond_meta_1 > 0) {
                                pond_1 = pond_real_1 / pond_meta_1;
                            }

                            pond_1 = pond_1 * 100;

                            newData.data.Add(decimal.Round(pond_1, 2, MidpointRounding.AwayFromZero));
                        }
                        else {
                            newData.data.Add(0);
                        }
                        

                    }
                    newData.nnumberaction = 7;
                    dataobj.Add(newData);
                }
                foreach (var emp in empleadosobj)
                {
                    MyTeamDataObjDto newData = new MyTeamDataObjDto();
                    newData.name = emp;
                    newData.title = "Evaluación";
                    newData.type = "bar";


                    newData.data = new List<decimal>();
                    
                    newData.emphasis = new EmphasisDto()
                    {
                        focus = "series"
                    };
                    newData.label = new SeriesLabelDto() { show = true,
                    formatter = "Evaluación: {c}",
                        position = "outside"
                    };
                    foreach (var camp in campaniasobj)
                    {

                        var campobj = resultadosObj.Where(i => i.semployeename == emp && i.snamecampaign == camp && i.nnumberaction == 11); 

                        if (campobj.Any())
                        {
                            decimal pond_meta_1 = campobj.Sum(i => i.ngoal * i.nweight);
                            decimal pond_real_1 = campobj.Sum(i => i.nprogress * i.nweight);

                            decimal pond_1 = 0;
                            if (pond_meta_1 > 0)
                            {
                                pond_1 = pond_real_1 / pond_meta_1;
                            }

                            pond_1 = pond_1 * 100;
                            
                            newData.data.Add(decimal.Round(pond_1, 2, MidpointRounding.AwayFromZero));
                        }
                        else
                        {
                            newData.data.Add(0);
                        }


                    }
                    newData.nnumberaction = 11;
                    dataobj.Add(newData);

                }


                if (request.filter.etapas != "")
                {

                    var aAR_ETAPA = request.filter.etapas.Split(',');

                    dataobj = dataobj.Where(i => aAR_ETAPA.Contains(i.nnumberaction.ToString())).ToList();

                    compdata_initial = compdata_initial.Where(i => aAR_ETAPA.Contains(i.nnumberaction.ToString()) || i.nnumberaction==0).ToList();
                    compdata_verification = compdata_verification.Where(i => aAR_ETAPA.Contains(i.nnumberaction.ToString()) || i.nnumberaction == 0).ToList();
                    compdata_evaluation = compdata_evaluation.Where(i => aAR_ETAPA.Contains(i.nnumberaction.ToString()) || i.nnumberaction == 0).ToList();


                }

                dataobj=dataobj.OrderBy(i => i.name).ToList();
                if (dataobj.Any()) {
                    dataobj[dataobj.Count-1].markLine = new MarkLineObj();
                    dataobj[dataobj.Count-1].markLine.data = new List<MarkLineDataObj>();
                    dataobj[dataobj.Count - 1].markLine.data.Add(new MarkLineDataObj()
                    {

                        name = "Meta",
                        xAxis = 100,
                        label = new MarkLineLabelObj()
                        {
                            formatter = "{b}",
                            position = "start"
                        }
                    });
                    dataobj[dataobj.Count - 1].markLine.lineStyle = new LineStyleObj()
                    {
                        color = "#000000"
                    };

                }



                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = new {
                        indicator = listpro,
                        data = data,
                        legends= data.Select(i=>i.name).ToList(),

                        objcategories = campaniasobj,
                        objlegend = empleadosobj.OrderBy(i=>i).ToList(), 
                        objdata = dataobj,

                        compdata_initial= compdata_initial,
                        compdata_verification = compdata_verification,
                        compdata_evaluation = compdata_evaluation
                    }
                };
            }
        }
    }
}
