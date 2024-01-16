using HumanManagement.Application.Response;
using HumanManagement.Application.Utils.IService;
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
    public class StaffRequestVacationGeneratePdf : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class StaffRequestVacationGeneratePdfHandler : IRequestHandler<StaffRequestVacationGeneratePdf, Result>
    {
        private readonly IStaffRequestVacationRepository staffRequestVacationRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IConvertWordToPdf convertWordToPdf;
        private readonly ITextReplacement textReplacement;
        private readonly StaffRequestDocument staffRequestDocument;
        public StaffRequestVacationGeneratePdfHandler(IStaffRequestVacationRepository staffRequestVacationRepository,
                                                      IStaffRequestRepository staffRequestRepository,
                                                      IConvertWordToPdf convertWordToPdf,
                                                      ITextReplacement textReplacement,
                                                      IOptions<StaffRequestDocument> staffRequestDocument,
                                                      IFileDownloadService fileDownloadService)
        {
            this.staffRequestVacationRepository = staffRequestVacationRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.convertWordToPdf = convertWordToPdf;
            this.textReplacement = textReplacement;
            this.staffRequestDocument = staffRequestDocument.Value;
        }

        public async Task<Result> Handle(StaffRequestVacationGeneratePdf request, CancellationToken cancellationToken)
        {
            var staffRequestVacation = await staffRequestVacationRepository.GetById(request.Id);
            var staffRequest = await staffRequestRepository.GetById(request.Id);
            staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
            staffRequestVacation.StaffRequest = staffRequest;
            var replaceTexTVacation = new ReplaceTextVacation(staffRequestVacation);
            replaceTexTVacation.Replace();
            var generatorPdf = new GeneratorPdf(staffRequestVacation.IdStaffRequest,
                                                                staffRequestDocument.FullPathFileWordVacation,
                                                                staffRequestDocument.PathFileWordCopy,
                                                                staffRequestDocument.PathFilePdf,
                                                                replaceTexTVacation.ListReplaceEntity);

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
