using HumanManagement.Application.Response;
using HumanManagement.Domain.Utils.Dto;
using System.Threading.Tasks;

namespace HumanManagement.Application.Utils.IService
{
    public interface IFileDownloadService
    {
        Task<Result> Download(FileDto fileDto);
        Task<Result> DownloadInternal(FileDto fileDto);
    }
}
