using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.Job.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.JobsInternal.Command
{
    public class LoadCurriculumCommand: IRequest<Result>
    {
        public IFormFile FileCv { get; set; }
    }

    public class LoadCurriculumCommandHandle : IRequestHandler<LoadCurriculumCommand, Result>
    {
        private readonly IBaseRepository<JobOffersInternalCurriculum> baseRepository;
        private readonly AppSettings _appSettings;
        protected readonly SessionManager sessionManager;
        public LoadCurriculumCommandHandle(IBaseRepository<JobOffersInternalCurriculum> baseRepository,
                                           IOptions<AppSettings> appSettings, SessionManager sessionManager)
        {
            this.baseRepository = baseRepository;
            this.sessionManager = sessionManager;
            this._appSettings = appSettings.Value;
        }
        public async Task<Result> Handle(LoadCurriculumCommand request, CancellationToken cancellationToken)
        {
            var path = _appSettings.PathSaveFile + "\\VacantsInternal\\Curriculum\\";
            var entity = new JobOffersInternalCurriculum();

            var filename = request.FileCv.FileName;
            var pathfile = path + filename;

            entity.IdPostulant = sessionManager.User.IdUser;
            entity.SFolderCv = pathfile;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (var stream = new FileStream(pathfile, FileMode.Create))
            {
                request.FileCv.CopyTo(stream);
            }

            await baseRepository.Add(entity);
            var dto = new FileDto();
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

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
