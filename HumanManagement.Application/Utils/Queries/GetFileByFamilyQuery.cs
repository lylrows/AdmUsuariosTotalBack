using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Utils.Constracts;
using HumanManagement.Domain.Utils.Dto;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Utils.Queries
{
    public class GetFileByFamilyQuery : IRequest<Result>
    {

        public InformationFilesDto param { get; set; }
        public class GetFileByFamilyQueryHandler : IRequestHandler<GetFileByFamilyQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            private readonly AppSettings _appSettings;
            public GetFileByFamilyQueryHandler(IUtilRepository utilRepository, IOptions<AppSettings> appSettings)
            {
                this._utilRepository = utilRepository;
                _appSettings = appSettings.Value;
            }

            public async Task<Result> Handle(GetFileByFamilyQuery query, CancellationToken cancellationToken)
            {
                var result = new InformationFilesDto();
                try
                {
                    result = await _utilRepository.GetInformationFilesByReference(query.param);
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
