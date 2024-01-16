using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Update
{

    public class RegisterRequestDocumentMasiveCommand : IRequest<Result>
    {
        public RegisterDocumentMedicalMasiveDto payload { get; set; }
        public IFormFileCollection fileslist { get; set; }
    }
    public class RegisterRequestDocumentMasiveCommandHandler : IRequestHandler<RegisterRequestDocumentMasiveCommand, Result>
    {
        private readonly IRequestMedicalRepository _requestMedicalRepository;
        public RegisterRequestDocumentMasiveCommandHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this._requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(RegisterRequestDocumentMasiveCommand request, CancellationToken cancellationToken)
        {


            int nIndexFile = 0;

            //
            foreach (var item in request.payload.lstdocument.Where(i=>i.bbreak_requiredfile))
            {
                if (request.fileslist.Any())
                {
                    item.sfile = request.fileslist[nIndexFile].FileName;

                    await _requestMedicalRepository.RegisterDocumentMedical(new RegisterDocumentMedicalDto() { 
                    
                    ndocument = item.ndocument,
                    nid_medical = request.payload.nid_medical,
                    ntype_doc = request.payload.ntype_doc
                    
                    }, request.fileslist[nIndexFile],false);

                }
                nIndexFile++;
            }

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
