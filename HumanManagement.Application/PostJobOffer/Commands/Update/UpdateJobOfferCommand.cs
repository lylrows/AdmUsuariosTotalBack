using AutoMapper;
using Dapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;

using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Job.Models;

using HumanManagement.Domain.WebServices.Dto;
using MediatR;
using System.Collections.Generic;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.PostJobOffer.Commands.Update
{
    public class UpdateJobOfferCommand : IRequest<Result>
    {
        public JobOfferDto Job { get; set; }

    }
    public class UpdateJobOfferCommandHandler : IRequestHandler<UpdateJobOfferCommand, Result>
    {

        private readonly IBaseRepository<Job> baseJobRepository;
        private readonly IBaseRepository<JobIdiom> baseJobIdiomRepository;
        private readonly IJobIdiomRepository jobIdiomRepository;
        private readonly IBaseRepository<JobKeyWords> baseJobKeyWordRepository;
        private readonly IJobKeyWordRepository jobKeyWordRepository;
        private readonly IMapper mapper;
        public UpdateJobOfferCommandHandler(IBaseRepository<Job> baseJobRepository,
                                            IBaseRepository<JobIdiom> baseJobIdiomRepository,
                                            IJobIdiomRepository jobIdiomRepository,
                                            IBaseRepository<JobKeyWords> baseJobKeyWordRepository,
                                            IJobKeyWordRepository jobKeyWordRepository,
                                            IMapper mapper)
        {
            this.baseJobRepository = baseJobRepository;
            this.baseJobIdiomRepository = baseJobIdiomRepository;
            this.jobIdiomRepository = jobIdiomRepository;
            this.baseJobKeyWordRepository = baseJobKeyWordRepository;
            this.jobKeyWordRepository = jobKeyWordRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(UpdateJobOfferCommand request, CancellationToken cancellationToken)
        {
            
            var queryParameters1 = new DynamicParameters();
            var queryParametersDeletePregrados = new DynamicParameters();
            var queryParametersDeletePostGrados = new DynamicParameters();

            var jobModel = mapper.Map<Job>(request.Job);
            jobModel.SetStatePending();
            await baseJobRepository.UpdatePartialNotIncluding(jobModel, x => x.DateRegister,
                                                                        x => x.IdUserRegister);
            await jobIdiomRepository.DeleteByJob(jobModel.Id_Job);

            if (request.Job.JobIdiomList.Count > 0)
            {
                var jobIdiomList = mapper.Map<List<JobIdiom>>(request.Job.JobIdiomList);
                jobIdiomList.ForEach(x =>
                {
                    x.Id = 0;
                    x.IdJob = jobModel.Id_Job;

                });
                await baseJobIdiomRepository.AddRange(jobIdiomList);
            }

            await jobKeyWordRepository.DeleteByJob(jobModel.Id_Job);
            if (request.Job.JobKeyWordList.Count > 0)
            {
                var jobKeyWordList = mapper.Map<List<JobKeyWords>>(request.Job.JobKeyWordList);
                jobKeyWordList.ForEach(x =>
                {
                    x.Id = 0;
                    x.IdJob = jobModel.Id_Job;

                });
                await baseJobKeyWordRepository.AddRange(jobKeyWordList);
            }

            if (!request.Job.IsPostedBumeran)
            {
                string body = @"<?xml version='1.0' encoding='UTF-8'?>
                            <Avisos>
                                  <aviso>
                                    <DatosAdicionales emp_idempresa='[EMPRESA]' emp_token='[EMPTOKEN]' />
                                    <txAccion>BORRAR</txAccion>
                                    <idAviso>[IDAVISO]</idAviso>
                                    <idPlanPublicacion>[IDPLANPUBLICACION]</idPlanPublicacion>
                                  </ aviso >

                            </Avisos>";

                body = body.Replace("[EMPRESA]", "");
                body = body.Replace("[EMPTOKEN]", "");
                body = body.Replace("[IDPLANPUBLICACION]", "");
                body = body.Replace("[IDAVISO]", "");

                string requestApi = string.Format("xml={0}", body);


                var NewBumeran = ExecApiFormHelper< Domain.WebServices.Dto.RequestDto, ReponseDto>.ExecuteForm(requestApi, "https://www.bumeran.com.pe/api/publicador/index.bum");

            }


            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
