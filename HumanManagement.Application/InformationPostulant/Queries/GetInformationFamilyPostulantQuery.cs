using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.InformationPostulant.Contracts;
using HumanManagement.Domain.Utils.Constracts;
using HumanManagement.Domain.Utils.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.InformationPostulant.Queries
{
    public class GetInformationFamilyPostulantQuery: IRequest<Result>
    {
        public int IdPerson { get; set; }
        public int IdEvaluation { get; set; }
        public class GetInformationFamilyPostulantQueryHandle : IRequestHandler<GetInformationFamilyPostulantQuery, Result>
        {
            private readonly IInformationFamilyRepository informationFamilyRepository;
            private readonly IUtilRepository _utilRepository;
            private readonly IMapper mapper;
            public GetInformationFamilyPostulantQueryHandle(IInformationFamilyRepository informationFamilyRepository, 
                IMapper mapper, IUtilRepository utilRepository)
            {
                this.informationFamilyRepository = informationFamilyRepository;
                this.mapper = mapper;
                _utilRepository = utilRepository;
            }
            public async Task<Result> Handle(GetInformationFamilyPostulantQuery request, CancellationToken cancellationToken)
            {
                var dto = await informationFamilyRepository.GetInformationFamily(request.IdPerson, request.IdEvaluation);

                
                foreach (var item in dto)
                {
                    var param = new InformationFilesDto();
                    param.nidinformationextra = item.IdPostulant;
                    param.nidreferences = item.Id;
                    param.stypeFile = "DOCUMENTO_COPIA_DNI";
                    param.ntypefile = 1;
                    item.InformationFile = await _utilRepository.GetInformationFilesByReference(param);
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
