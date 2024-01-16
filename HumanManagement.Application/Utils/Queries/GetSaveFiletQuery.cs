using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Utils.Constracts;
using HumanManagement.Domain.Utils.Dto;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Utils.Queries
{
    public class GetSaveFiletQuery : IRequest<Result>
    {
        public InformationFilesDto param { get; set; }
        public class GetSaveFileQueryHandler : IRequestHandler<GetSaveFiletQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            private readonly AppSettings _appSettings;
            public GetSaveFileQueryHandler(IUtilRepository utilRepository, IOptions<AppSettings> appSettings)
            {
                this._utilRepository = utilRepository;
                _appSettings = appSettings.Value;
            }

            public async Task<Result> Handle(GetSaveFiletQuery query, CancellationToken cancellationToken)
            {
                var result = new InformationFilesDto();
                try
                {
                    if (!String.IsNullOrEmpty(query.param.base64))
                    {
                        string _base64 = Functions.CleanBase64File(query.param.base64);
                        var _file = Convert.FromBase64String(_base64);
                        var _nombreFileAleatorio = Guid.NewGuid();
                        var ext = Path.GetExtension(query.param.snamefile);
                        query.param.skeyfile = string.Format("{0}{1}", _nombreFileAleatorio, ext);
                        query.param.path_complete = string.Format("{0}{1}{2}", _appSettings.PathDocumentosPostulant, _nombreFileAleatorio, ext);
                        File.WriteAllBytes(string.Format("{0}{1}{2}", _appSettings.PathDocumentosPostulant, _nombreFileAleatorio, ext), _file);
                    }
                     result = await _utilRepository.SaveInformationFiles(query.param);
                }
                catch (Exception ex)
                {
                    return new Result
                    {
                        StateCode = 500,
                        Data = new { data = result }
                    };
                }
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = result }
                };
            }

        }
    }
}
