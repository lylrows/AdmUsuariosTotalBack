using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Job.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.JobsInternal.Command
{
    public class ValidatePostulantJobCommand: IRequest<Result>
    {
        public int IdUser { get; set; }
        public int IdJob { get; set; }
    }

    public class ValidatePostulantJobCommandHandle : IRequestHandler<ValidatePostulantJobCommand, Result>
    {
        private readonly IBaseRepository<JobOffersInternalPostulant> baseRepository;

        public ValidatePostulantJobCommandHandle(IBaseRepository<JobOffersInternalPostulant> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public async Task<Result> Handle(ValidatePostulantJobCommand request, CancellationToken cancellationToken)
        {
            var exist = await baseRepository.Exist(x => x.IdJob == request.IdJob && x.IdPostulant == request.IdUser);

            return new Result
            {
                Data = exist,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
