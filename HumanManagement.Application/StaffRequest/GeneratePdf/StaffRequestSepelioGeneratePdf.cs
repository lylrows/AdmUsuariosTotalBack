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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.GeneratePdf
{
    public class StaffRequestSepelioGeneratePdf : IRequest<Result>
    {
        public int Id { get; set; }
    }
    public class StaffRequestSepelioGeneratePdfHandler : IRequestHandler<StaffRequestSepelioGeneratePdf, Result>
    {
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IConvertWordToPdf convertWordToPdf;
        private readonly ITextReplacement textReplacement;
        private readonly StaffRequestDocument staffRequestDocument;
        public StaffRequestSepelioGeneratePdfHandler(IStaffRequestRepository staffRequestRepository,
                                                    IConvertWordToPdf convertWordToPdf,
                                                    ITextReplacement textReplacement,
                                                    IOptions<StaffRequestDocument> staffRequestDocument)
        {
            this.staffRequestRepository = staffRequestRepository;
            this.convertWordToPdf = convertWordToPdf;
            this.textReplacement = textReplacement;
            this.staffRequestDocument = staffRequestDocument.Value;
        }
        public async Task<Result> Handle(StaffRequestSepelioGeneratePdf request, CancellationToken cancellationToken)
        {
            var staffRequest = await staffRequestRepository.GetStaffBurialById(request.Id);
            var replaceTextBurial = new ReplaceTextSepelio(staffRequest);
            replaceTextBurial.Replace();
            var generatorPdf = new GeneratorPdf(staffRequest.nid_request,
                                                staffRequestDocument.FullPathFileWordSepelio,
                                                staffRequestDocument.PathFileWordCopy,
                                                staffRequestDocument.PathFilePdf,
                                                replaceTextBurial.ListReplaceEntity);

            generatorPdf.Generate(textReplacement, convertWordToPdf, staffRequest.spathsignature,staffRequest);
            var file = new FileDto
            {
                FileName = $"Solicitud de Servicio de Sepeleio {DateTime.Now.ToString("ddMMyyyy hhmmss")}.pdf",
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
