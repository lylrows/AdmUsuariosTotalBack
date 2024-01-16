using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class UpdateFileMedicalQuery : IRequest<Result>
    {
        public UpdateFilesDto payload { get; set; }
        public IFormFile file { get; set; }
    }
    public class UpdateFileMedicalQueryHandler : IRequestHandler<UpdateFileMedicalQuery, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public UpdateFileMedicalQueryHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(UpdateFileMedicalQuery request, CancellationToken cancellationToken)
        {

            
            try
            {
                await _requestMedicalRepository.UpdateFile(request.payload, request.file);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
            catch (Exception ex)
            {
                return new Result
                {
                    StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                    MessageError = new List<string>() { ex.Message }
                };
            }
        }
    }
}
