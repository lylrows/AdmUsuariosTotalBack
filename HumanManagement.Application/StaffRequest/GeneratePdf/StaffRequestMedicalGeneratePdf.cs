using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Options;
using HumanManagement.Domain.StaffRequest.Pdf;
using HumanManagement.Domain.StaffRequest.ReplaceText;
using HumanManagement.Domain.Utils.Dto;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.GeneratePdf
{
    public class StaffRequestMedicalGeneratePdf : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class StaffRequestMedicalGeneratePdfHandler : IRequestHandler<StaffRequestMedicalGeneratePdf, Result>
    {
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IConvertWordToPdf convertWordToPdf;
        private readonly ITextReplacement textReplacement;
        private readonly StaffRequestDocument staffRequestDocument;
        public StaffRequestMedicalGeneratePdfHandler(IStaffRequestRepository staffRequestRepository,
                                                     IConvertWordToPdf convertWordToPdf,
                                                     ITextReplacement textReplacement,
                                                     IOptions<StaffRequestDocument> staffRequestDocument)
        {
            this.staffRequestRepository = staffRequestRepository;
            this.convertWordToPdf = convertWordToPdf;
            this.textReplacement = textReplacement;
            this.staffRequestDocument = staffRequestDocument.Value;
        }

        public async Task<Result> Handle(StaffRequestMedicalGeneratePdf request, CancellationToken cancellationToken)
        {
            var staffRequest = await staffRequestRepository.GetRequestMedicalById(request.Id);
            var replaceTextMedical = new ReplaceTextMedical(staffRequest);
            replaceTextMedical.Replace();
            var generatorPdf = new GeneratorPdf(staffRequest.nid_request,
                                                                staffRequestDocument.FullPathFileWordMedicalRest,
                                                                staffRequestDocument.PathFileWordCopy,
                                                                staffRequestDocument.PathFilePdf,
                                                                replaceTextMedical.ListReplaceEntity);

            generatorPdf.Generate(textReplacement, convertWordToPdf, staffRequest.PathSignature);
            var file = new FileDto
            {
                FileName = $"Solicitud de Descanso Médico {DateTime.Now.ToString("ddMMyyyy hhmmss")}.pdf",
                File = File.ReadAllBytes(generatorPdf.GetFileNamePdf()),
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
