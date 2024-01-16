using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.InformationPostulant.Contracts;
using HumanManagement.Domain.Utils.Constracts;
using HumanManagement.Domain.Utils.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.InformationPostulant.Queries
{

    public class GetInformationWorkPostulantQuery : IRequest<Result>
    {
        public int IdPerson { get; set; }
        public int IdEvaluation { get; set; }
        public class GetInformationWorkPostulantQueryHandle : IRequestHandler<GetInformationWorkPostulantQuery, Result>
        {
            private readonly IInformationWorkRepository informationWorkRepository;
            private readonly IMapper mapper;
            private readonly IUtilRepository _utilRepository;
            public GetInformationWorkPostulantQueryHandle(IInformationWorkRepository informationWorkRepository,
                                                               IMapper mapper, IUtilRepository utilRepository)
            {
                this.informationWorkRepository = informationWorkRepository;
                this.mapper = mapper;
                _utilRepository = utilRepository;
            }
            public async Task<Result> Handle(GetInformationWorkPostulantQuery request, CancellationToken cancellationToken)
            {
                var dto = await informationWorkRepository.GetInformationWork(request.IdPerson, request.IdEvaluation);
                foreach (var item in dto)
                {
                    var param = new InformationFilesDto();
                    param.nidinformationextra = item.IdPostulant;
                    param.nidreferences = item.Id;
                    param.stypeFile = "DOCUMENTO_SUSTENTO_WORK";
                    param.ntypefile = 5;
                    item.InformationFile = await _utilRepository.GetInformationFilesByReference(param);
                }
                var result = dto.OrderByDescending(x => x.DateStart).ToList();
                return new Result
                {
                    Data = result,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
