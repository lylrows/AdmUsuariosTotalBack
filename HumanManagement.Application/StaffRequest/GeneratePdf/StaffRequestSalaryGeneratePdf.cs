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
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.GeneratePdf
{
    public class StaffRequestSalaryGeneratePdf : IRequest<Result>
    {
        public int Id { get; set; }
    }
    public class StaffRequestSalaryGeneratePdfHandler : IRequestHandler<StaffRequestSalaryGeneratePdf, Result>
    {
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IConvertWordToPdf convertWordToPdf;
        private readonly ITextReplacement textReplacement;
        private readonly StaffRequestDocument staffRequestDocument;
        public StaffRequestSalaryGeneratePdfHandler(IStaffRequestRepository staffRequestRepository,
                                                    IConvertWordToPdf convertWordToPdf,
                                                    ITextReplacement textReplacement,
                                                    IOptions<StaffRequestDocument> staffRequestDocument)
        {
            this.staffRequestRepository = staffRequestRepository;
            this.convertWordToPdf = convertWordToPdf;
            this.textReplacement = textReplacement;
            this.staffRequestDocument = staffRequestDocument.Value;
        }
        public async Task<Result> Handle(StaffRequestSalaryGeneratePdf request, CancellationToken cancellationToken)
        {
            var staffRequest = await staffRequestRepository.GetStaffSalaryById(request.Id);
            var replaceText = new ReplaceTextSalaryAccount(staffRequest);
            replaceText.Replace();
            var generatorPdf = new GeneratorPdf(staffRequest.nid_request,
                                                staffRequestDocument.FullPathFileWordSalaryAccount,
                                                staffRequestDocument.PathFileWordCopy,
                                                staffRequestDocument.PathFilePdf,
                                                replaceText.ListReplaceEntity);

            generatorPdf.Generate(textReplacement, convertWordToPdf, staffRequest.spathsignature);
            var file = new FileDto
            {
                FileName = $"Solicitud de Cambio de Cuenta Sueldo {DateTime.Now.ToString("ddMMyyyy hhmmss")}.pdf",
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
