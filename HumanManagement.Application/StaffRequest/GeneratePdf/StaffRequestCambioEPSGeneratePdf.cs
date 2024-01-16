﻿using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Options;
using HumanManagement.Domain.StaffRequest.Pdf;
using HumanManagement.Domain.StaffRequest.ReplaceText;
using HumanManagement.Domain.Utils.Dto;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.GeneratePdf
{
    public  class StaffRequestCambioEPSGeneratePdf : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class StaffRequestCambioEPSGeneratePdfHandler : IRequestHandler<StaffRequestCambioEPSGeneratePdf, Result>
    {
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IConvertWordToPdf convertWordToPdf;
        private readonly ITextReplacement textReplacement;
        private readonly StaffRequestDocument staffRequestDocument;
        public StaffRequestCambioEPSGeneratePdfHandler(
                                                     IStaffRequestRepository staffRequestRepository,
                                                     IConvertWordToPdf convertWordToPdf,
                                                     ITextReplacement textReplacement,
                                                     IOptions<StaffRequestDocument> staffRequestDocument)
        {
            this.staffRequestRepository = staffRequestRepository;
            this.convertWordToPdf = convertWordToPdf;
            this.textReplacement = textReplacement;
            this.staffRequestDocument = staffRequestDocument.Value;
        }

        public async Task<Result> Handle(StaffRequestCambioEPSGeneratePdf request, CancellationToken cancellationToken)
        {
            var staffRequestAbsence = await staffRequestRepository.GetRequestTypeSureById(request.Id);
            var staffRequest = await staffRequestRepository.GetById(request.Id);
            staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
            var replaceTextAbsence = new ReplaceTextCambioEPS(staffRequestAbsence);
            replaceTextAbsence.Replace();
            var generatorVacationPdf = new GeneratorPdf(staffRequestAbsence.nid_request,
                                                                staffRequestDocument.SolcitudCambioEPS,
                                                                staffRequestDocument.PathFileWordCopy,
                                                                staffRequestDocument.PathFilePdf,
                                                                replaceTextAbsence.ListReplaceEntity);

            generatorVacationPdf.Generate(textReplacement,
                                          convertWordToPdf,
                                          staffRequest.StaffRequestEmployee.PathSignature);
            var file = new FileDto
            {
                FileName = $"Solicitud de {staffRequest.TypeStaffRequest} {DateTime.Now.ToString("ddMMyyyy hhmmss")}.pdf",
                File = await File.ReadAllBytesAsync(generatorVacationPdf.GetFileNamePdf()),
                ContentType = "pdf"
            };
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = file
            };
        }
    }
}
