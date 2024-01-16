using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Job.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.JobsInternal.Command
{
    public class DeleteCvPostulantCommand: IRequest<Result>
    {
    }

    public class DeleteCvPostulantCommandHandle : IRequestHandler<DeleteCvPostulantCommand, Result>
    {
        private readonly IBaseRepository<JobOffersInternalCurriculum> baseRepository;
        protected readonly SessionManager sessionManager;
        public DeleteCvPostulantCommandHandle(IBaseRepository<JobOffersInternalCurriculum> baseRepository, SessionManager sessionManager)
        {
            this.baseRepository = baseRepository;
            this.sessionManager = sessionManager;
        }
        public async Task<Result> Handle(DeleteCvPostulantCommand request, CancellationToken cancellationToken)
        {
            var entity = await baseRepository.FindPredicate(x => x.IdPostulant == sessionManager.User.IdUser);
            if (File.Exists(entity.SFolderCv))
            {
                File.Delete(entity.SFolderCv);
            }
            await baseRepository.Delete(entity);


            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };

        }
    }
}
