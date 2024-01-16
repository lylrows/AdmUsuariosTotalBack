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
    public class StaffRequestAccountChangeCtsGeneratePdf : IRequest<Result>
    {
        public int Id { get; set; }
    }
    public class StaffRequestAccountChangeCtsGeneratePdfHandler : IRequestHandler<StaffRequestAccountChangeCtsGeneratePdf, Result>
    {
        private readonly IStaffRequestAccountChangeCtsRepository staffRequestAccountChangeCtsRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IConvertWordToPdf convertWordToPdf;
        private readonly ITextReplacement textReplacement;
        private readonly StaffRequestDocument staffRequestDocument;
        public StaffRequestAccountChangeCtsGeneratePdfHandler(IStaffRequestAccountChangeCtsRepository staffRequestAccountChangeCtsRepository,
                                                                IStaffRequestRepository staffRequestRepository,
                                                                IConvertWordToPdf convertWordToPdf,
                                                                ITextReplacement textReplacement,
                                                                IOptions<StaffRequestDocument> staffRequestDocument)
        {
            this.staffRequestAccountChangeCtsRepository = staffRequestAccountChangeCtsRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.convertWordToPdf = convertWordToPdf;
            this.textReplacement = textReplacement;
            this.staffRequestDocument = staffRequestDocument.Value;
        }
        public async Task<Result> Handle(StaffRequestAccountChangeCtsGeneratePdf request, CancellationToken cancellationToken)
        {
            var staffRequestAccountChange = await staffRequestAccountChangeCtsRepository.GetById(request.Id);
            var staffRequest = await staffRequestRepository.GetById(request.Id);
            staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
            staffRequestAccountChange.StaffRequest = staffRequest;
            var replaceText = new ReplaceTextAccountChangeCts(staffRequestAccountChange);
            replaceText.Replace();
            var generatorPdf = new GeneratorPdf(staffRequestAccountChange.IdStaffRequest,
                                                staffRequestDocument.FullPathFileWordAccountChangeCts,
                                                staffRequestDocument.PathFileWordCopy,
                                                staffRequestDocument.PathFilePdf,
                                                replaceText.ListReplaceEntity);

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
