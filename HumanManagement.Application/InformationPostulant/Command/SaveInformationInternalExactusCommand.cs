using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.InformationPostulant.Contracts;
using HumanManagement.Domain.InformationPostulant.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.InformationPostulant.Command
{
    public class SaveInformationInternalExactusCommand : IRequest<Result>
    {
        public InformationExactusInternalDto dto { get; set; }
        public class SaveInformationInternalExactusCommandHandle : IRequestHandler<SaveInformationInternalExactusCommand, Result>
        {
            private readonly IInformationPostulantRepository postulantRepository;
            public SaveInformationInternalExactusCommandHandle(IInformationPostulantRepository postulantRepository)
            {
                this.postulantRepository = postulantRepository;
            }

            public async Task<Result> Handle(SaveInformationInternalExactusCommand request, CancellationToken cancellationToken)
            {
                var _result = await postulantRepository.SaveInformationInternalExactus(request.dto);
                return new Result
                {
                    Data = _result,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }

    }
}
