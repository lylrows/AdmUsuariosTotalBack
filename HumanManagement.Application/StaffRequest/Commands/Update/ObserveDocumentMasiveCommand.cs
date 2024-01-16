using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Update
{
    
    public class ObserveDocumentMasiveCommand : IRequest<Result>
    {
        public ObserveMasiveDocumentDto dto { get; set; }
    }
    public class ObserveDocumentMasiveCommandHandler : IRequestHandler<ObserveDocumentMasiveCommand, Result>
    {

        private readonly IRequestMedicalRepository requestMedicalRepository;
        public ObserveDocumentMasiveCommandHandler(IRequestMedicalRepository requestMedicalRepository)
        {
            this.requestMedicalRepository = requestMedicalRepository;
        }
        public async Task<Result> Handle(ObserveDocumentMasiveCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.dto.listdocument)
            {
                await requestMedicalRepository.RequestDocumentObserve(item.nid_document_medical,item.scomment);
            }
            /*NOTIFICAR DE LA OBSERVACIÓN*/


            //  var list = await _baseStaffRequestRepository.MedicalById(query.id);



            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
