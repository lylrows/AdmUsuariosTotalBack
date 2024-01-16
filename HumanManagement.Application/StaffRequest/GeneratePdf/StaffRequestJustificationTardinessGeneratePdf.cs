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
    public class StaffRequestJustificationTardinessGeneratePdf : IRequest<Result>
    {
        public int Id { get; set; }
    }
    public class StaffRequestJustificationTardinessGeneratePdfHandler : IRequestHandler<StaffRequestJustificationTardinessGeneratePdf, Result>
    {
        private readonly IStaffRequestJustificationTardinessRepository staffRequestJustificationTardinessRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IConvertWordToPdf convertWordToPdf;
        private readonly ITextReplacement textReplacement;
        private readonly StaffRequestDocument staffRequestDocument;
        public StaffRequestJustificationTardinessGeneratePdfHandler(IStaffRequestJustificationTardinessRepository staffRequestJustificationTardinessRepository,
                                                                    IStaffRequestRepository staffRequestRepository,
                                                                    IConvertWordToPdf convertWordToPdf,
                                                                    ITextReplacement textReplacement,
                                                                    IOptions<StaffRequestDocument> staffRequestDocument)
        {
            this.staffRequestJustificationTardinessRepository = staffRequestJustificationTardinessRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.convertWordToPdf = convertWordToPdf;
            this.textReplacement = textReplacement;
            this.staffRequestDocument = staffRequestDocument.Value;
        }
        public async Task<Result> Handle(StaffRequestJustificationTardinessGeneratePdf request, CancellationToken cancellationToken)
        {
            var staffRequestJustificationTardiness = await staffRequestJustificationTardinessRepository.GetById(request.Id);
            var staffRequest = await staffRequestRepository.GetById(request.Id);
            staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
            staffRequestJustificationTardiness.StaffRequest = staffRequest;
            var replaceText = new ReplaceTextJustificationTardiness(staffRequestJustificationTardiness);
            replaceText.Replace();
            var generatorPdf = new GeneratorPdf(staffRequestJustificationTardiness.IdStaffRequest,
                                                staffRequestDocument.FullPathFileWordJustificationTardiness,
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
