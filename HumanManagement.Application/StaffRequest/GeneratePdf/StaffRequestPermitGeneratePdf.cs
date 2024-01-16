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
    public class StaffRequestPermitGeneratePdf : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class StaffRequestPermitGeneratePdfHandler : IRequestHandler<StaffRequestPermitGeneratePdf, Result>
    {
        private readonly IStaffRequestPermitRepository staffRequestPermitRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IConvertWordToPdf convertWordToPdf;
        private readonly ITextReplacement textReplacement;
        private readonly StaffRequestDocument staffRequestDocument;
        public StaffRequestPermitGeneratePdfHandler(IStaffRequestPermitRepository staffRequestPermitRepository,
                                                    IStaffRequestRepository staffRequestRepository,
                                                    IConvertWordToPdf convertWordToPdf,
                                                    ITextReplacement textReplacement,
                                                    IOptions<StaffRequestDocument> staffRequestDocument)
        {
            this.staffRequestPermitRepository = staffRequestPermitRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.convertWordToPdf = convertWordToPdf;
            this.textReplacement = textReplacement;
            this.staffRequestDocument = staffRequestDocument.Value;
        }
        public async Task<Result> Handle(StaffRequestPermitGeneratePdf request, CancellationToken cancellationToken)
        {
            var staffRequestPermit = await staffRequestPermitRepository.GetById(request.Id);
            var staffRequest = await staffRequestRepository.GetById(request.Id);
            staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
            staffRequestPermit.StaffRequest = staffRequest;
            var replaceTextPermit = new ReplaceTextPermit(staffRequestPermit);
            replaceTextPermit.Replace();
            var generatorPdf = new GeneratorPdf(staffRequestPermit.IdStaffRequest,
                                                staffRequestDocument.FullPathFileWordPermit,
                                                staffRequestDocument.PathFileWordCopy,
                                                staffRequestDocument.PathFilePdf,
                                                replaceTextPermit.ListReplaceEntity);

            generatorPdf.Generate(textReplacement, 
                                  convertWordToPdf,
                                  staffRequest.StaffRequestEmployee.PathSignature);
            var file = new FileDto
            {
                FileName = $"Solicitud de {staffRequest.TypeStaffRequest} {DateTime.Now.ToString("ddMMyyyy hhmmss")}.pdf",
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
