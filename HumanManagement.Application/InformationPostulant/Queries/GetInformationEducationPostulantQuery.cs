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
    public class GetInformationEducationPostulantQuery: IRequest<Result>
    {
        public int IdPerson { get; set; }
        public int IdEvaluation { get; set; }
        public class GetInformationEducationPostulantQueryHandle : IRequestHandler<GetInformationEducationPostulantQuery, Result>
        {
            private readonly IInformationEducationRepository informationEducationRepository;
            private readonly IMapper mapper;
            private readonly IUtilRepository _utilRepository;
            public GetInformationEducationPostulantQueryHandle(IInformationEducationRepository informationEducationRepository,
                                                               IMapper mapper, IUtilRepository utilRepository)
            {
                this.informationEducationRepository = informationEducationRepository;
                this.mapper = mapper;
                _utilRepository = utilRepository;
            }
            public async Task<Result> Handle(GetInformationEducationPostulantQuery request, CancellationToken cancellationToken)
            {
                var dto = await informationEducationRepository.GetInformationEducation(request.IdPerson, request.IdEvaluation);

                foreach (var item in dto)
                {
                    var param = new InformationFilesDto();
                    param.nidinformationextra = item.IdPostulant;
                    param.nidreferences = item.Id;
                    param.stypeFile = "DOCUMENTO_SUSTENTO";
                    param.ntypefile = 2;
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
