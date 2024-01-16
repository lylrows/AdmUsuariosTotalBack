using HumanManagement.Application.Response;
using HumanManagement.Application.Utils.IService;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Utils.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Application.Utils.Service
{
    public class FileDownloadService : IFileDownloadService
    {
        private readonly IBaseRepository<JobOffersInternalPostulant> baseRepository;

        public FileDownloadService(IBaseRepository<JobOffersInternalPostulant> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public async Task<Result> Download(FileDto file)
        {
            Result result = new Result();
            if (File.Exists(file.FileUrl))
            {
                file.FileName = Path.GetFileName(file.FileUrl);
                file.ContentType = Path.GetExtension(file.FileName);
                file.File = await File.ReadAllBytesAsync(file.FileUrl);
                result.Data = file;
                result.StateCode = Constants.StateCodeResult.STATE_CODE_OK;
            }
            else
            {
                result.StateCode = Constants.StateCodeResult.FILE_NOT_FOUND;
            }

            return result;
        }

        public async Task<Result> DownloadInternal(FileDto fileDto)
        {
            var entity = await baseRepository.FindPredicate(x => x.Id == fileDto.Id);
            entity.IdState = 757;
            await baseRepository.Update(entity);

            Result result = new Result();
            if (File.Exists(fileDto.FileUrl))
            {
                fileDto.FileName = Path.GetFileName(fileDto.FileUrl);
                fileDto.ContentType = Path.GetExtension(fileDto.FileName);
                fileDto.File = await File.ReadAllBytesAsync(fileDto.FileUrl);
                result.Data = fileDto;
                result.StateCode = Constants.StateCodeResult.STATE_CODE_OK;
            }
            else
            {
                result.StateCode = Constants.StateCodeResult.FILE_NOT_FOUND;
            }

            return result;
        }
    }
}
