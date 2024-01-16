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
    public class StaffRequestAbsenceGeneratePdf : IRequest<Result>
    {
        public int Id { get; set; }
    }
    public class StaffRequestAbsenceGeneratePdfHandler : IRequestHandler<StaffRequestAbsenceGeneratePdf, Result>
    {
        private readonly IStaffRequestAbsenceRepository staffRequestAbsenceRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IConvertWordToPdf convertWordToPdf;
        private readonly ITextReplacement textReplacement;
        private readonly StaffRequestDocument staffRequestDocument;
        public StaffRequestAbsenceGeneratePdfHandler(IStaffRequestAbsenceRepository staffRequestAbsenceRepository,
                                                     IStaffRequestRepository staffRequestRepository,
                                                     IConvertWordToPdf convertWordToPdf,
                                                     ITextReplacement textReplacement,
                                                     IOptions<StaffRequestDocument> staffRequestDocument)
        {
            this.staffRequestAbsenceRepository = staffRequestAbsenceRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.convertWordToPdf = convertWordToPdf;
            this.textReplacement = textReplacement;
            this.staffRequestDocument = staffRequestDocument.Value;
        }
        public async Task<Result> Handle(StaffRequestAbsenceGeneratePdf request, CancellationToken cancellationToken)
        {
            var staffRequestAbsence = await staffRequestAbsenceRepository.GetById(request.Id);
            var staffRequest = await staffRequestRepository.GetById(request.Id);
            staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
            staffRequestAbsence.StaffRequest = staffRequest;
            var replaceTextAbsence = new ReplaceTextAbsence(staffRequestAbsence);
            replaceTextAbsence.Replace();
            var generatorVacationPdf = new GeneratorPdf(staffRequestAbsence.IdStaffRequest,
                                                                staffRequestDocument.FullPathFileWordAbsence,
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
