using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Job.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using HumanManagement.Domain.WebServices.Dto;
using Microsoft.Extensions.Options;

namespace HumanManagement.Application.PostJobOffer.Commands.Create
{
    public class CreateJobOfferCommand : IRequest<Result>
    {
        public JobOfferDto Job { get; set; }
    }

    public class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand, Result>
    {
        private readonly IBaseRepository<Job> baseJobRepository;
        private readonly IBaseRepository<JobIdiom> baseJobIdiomRepository;
        private readonly IBaseRepository<JobKeyWords> baseJobKeyWordRepository;
        private readonly IMapper mapper;
        private readonly AppSettings _appSettings;
        public CreateJobOfferCommandHandler(IBaseRepository<Job> baseJobRepository,
                                            IBaseRepository<JobIdiom> baseJobIdiomRepository,
                                            IBaseRepository<JobKeyWords> baseJobKeyWordRepository,
                                            IMapper mapper,
                                            IOptions<AppSettings> appSettings)
        {
            this.baseJobRepository = baseJobRepository;
            this.baseJobIdiomRepository = baseJobIdiomRepository;
            this.baseJobKeyWordRepository = baseJobKeyWordRepository;
            this.mapper = mapper;
            this._appSettings = appSettings.Value;
        }
        public async Task<Result> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
        {
            var jobModel = mapper.Map<Job>(request.Job);
            jobModel.SetStatePending();
            await baseJobRepository.Add(jobModel);

            if (request.Job.JobIdiomList.Count > 0)
            {
                var jobIdiomList = mapper.Map<List<JobIdiom>>(request.Job.JobIdiomList);
                jobIdiomList.ForEach(x =>
                {
                    x.IdJob = jobModel.Id_Job;
                    
                });
                await baseJobIdiomRepository.AddRange(jobIdiomList);
            }

            if (request.Job.JobKeyWordList.Count > 0)
            {
                var jobKeyWordList = mapper.Map<List<JobKeyWords>>(request.Job.JobKeyWordList);
                jobKeyWordList.ForEach(x =>
                {
                    x.IdJob = jobModel.Id_Job;

                });
                await baseJobKeyWordRepository.AddRange(jobKeyWordList);
            }


            if (jobModel.IsPostedBumeran)
            {
                
                string body = @"<?xml version='1.0' encoding='UTF-8'?>
                            <Avisos>
                                <aviso>
                                    <DatosAdicionales emp_idempresa='[EMPRESA]' emp_token='[EMPTOKEN]' />
                                    <txAccion>CREAR</txAccion>
                                    <idPlanPublicacion>[IDPLANPUBLICACION]</idPlanPublicacion>
                                    <txAviso2Url>[URLJOB]</txAviso2Url>
                                    <txCodigoReferencia>[CODIGOREFERENCIA]</txCodigoReferencia>
                                    <idPais>[IDPAIS]</idPais>
                                    <idArea>[IDAREA]</idArea>
                                    <idTipoTrabajo>[IDTIPOTRABAJO]</idTipoTrabajo>
                                    <minSalario>[SALARIOMINIMO]</minSalario> 
                                    <maxSalario>[SALARIOMAXIMO]</maxSalario>
                                    <netoBruto>[NETOBRUTO]</netoBruto>
                                    <idFrecuenciaDePago>[IDFRECUENCIA]</idFrecuenciaDePago>
                                    <txPuesto>[PUESTO]</txPuesto>
                                    <idIndustria>[INDUSTRIA]</idIndustria>
                                    <txDescripcion>[DESCRIPCION]</txDescripcion>
                                    <numCantidadVacantes>[VACANTES]</numCantidadVacantes>
                                    <txAgradecimiento />
                                    <idSexo />
                                    <numApareceEmpresa>[APARECEEMPRESA]</numApareceEmpresa>
                                    <txNombreAlternativoEmpresa />
                                    <txCiudad>[CIUDAD]</txCiudad>
                                    <idZona>[IDZONA]</idZona>
                                  </aviso>

                            </Avisos>";

                body = body.Replace("[EMPRESA]", "");
                body = body.Replace("[EMPTOKEN]", "");
                body = body.Replace("[IDPLANPUBLICACION]", "");
                body = body.Replace("[URLJOB]", _appSettings.UrlJobOfferDetail + "/" + jobModel.Id_Job);
                body = body.Replace("[CODIGOREFERENCIA]", "");
                body = body.Replace("[IDPAIS]", "11");
                body = body.Replace("[IDAREA]", "");
                body = body.Replace("[IDTIPOTRABAJO]", ""); 
                body = body.Replace("[SALARIOMINIMO]", jobModel.MinimumSalary.ToString());
                body = body.Replace("[SALARIOMAXIMO]", jobModel.MaximumSalary.ToString());
                body = body.Replace("[NETOBRUTO]", "B");
                body = body.Replace("[IDFRECUENCIA]", "4");
                body = body.Replace("[PUESTO]", jobModel.Title);
                body = body.Replace("[INDUSTRIA]", "");
                body = body.Replace("[DESCRIPCION]", jobModel.NoticeDetails);
                body = body.Replace("[VACANTES]", "1");
                body = body.Replace("[APARECEEMPRESA]", "1");
                body = body.Replace("[CIUDAD]", "1");
                body = body.Replace("[IDZONA]", "428");
                



                string requestApi = string.Format("xml={0}", body);


                var NewBumeran = ExecApiFormHelper<RequestDto, ReponseDto>.ExecuteForm(requestApi, _appSettings.UrlBumeran);


            }

            var output = new Result();
            output.StateCode = Constants.StateCodeResult.STATE_CODE_OK;
            output.LastId = jobModel.Id_Job;
            return output;
        }
    }
}
