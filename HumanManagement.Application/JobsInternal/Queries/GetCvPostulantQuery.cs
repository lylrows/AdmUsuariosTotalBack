using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.Job.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.JobsInternal.Queries
{
    public class GetCvPostulantQuery: IRequest<Result>
    {
        public class GetCvPostulantQueryHandle : IRequestHandler<GetCvPostulantQuery, Result>
        {
            private readonly IBaseRepository<JobOffersInternalCurriculum> baseRepository;
            protected readonly SessionManager sessionManager;
            public GetCvPostulantQueryHandle(IBaseRepository<JobOffersInternalCurriculum> baseRepository, SessionManager sessionManager)
            {
                this.baseRepository = baseRepository;
                this.sessionManager = sessionManager;
            }
            public async Task<Result> Handle(GetCvPostulantQuery request, CancellationToken cancellationToken)
            {
                var entity = await baseRepository.FindPredicate(x => x.IdPostulant == sessionManager.User.IdUser);

                var dto = new FileDto();
                if (entity != null)
                {
                    if (entity.SFolderCv != null)
                    {
                        var file = entity.SFolderCv;
                        if (File.Exists(file))
                        {
                            var buffer = File.ReadAllBytes(file);
                            dto.File = buffer;
                            dto.ContentType = Path.GetExtension(entity.SFolderCv);
                            dto.NameFile = Path.GetFileName(entity.SFolderCv);
                        }
                    }
                }

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
