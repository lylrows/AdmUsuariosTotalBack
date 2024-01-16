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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.GeneratePdf
{
    public class StaffRequestLoanGeneratePdf : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class StaffRequestLoanGeneratePdfHandler : IRequestHandler<StaffRequestLoanGeneratePdf, Result>
    {
        private readonly IStaffRequestLoanRepository staffRequestLoanRepository;
        private readonly IStaffRequestRepository staffRequestRepository;
        private readonly IConvertWordToPdf convertWordToPdf;
        private readonly ITextReplacement textReplacement;
        private readonly StaffRequestDocument staffRequestDocument;
        private readonly IStaffRequestApproverRepository staffRequestApproverRepository;
        public StaffRequestLoanGeneratePdfHandler(IStaffRequestLoanRepository staffRequestLoanRepository,
                                                  IStaffRequestRepository staffRequestRepository,
                                                  IStaffRequestApproverRepository staffRequestApproverRepository,
                                                  IConvertWordToPdf convertWordToPdf,
                                                  ITextReplacement textReplacement,
                                                  IOptions<StaffRequestDocument> staffRequestDocument)
        {
            this.staffRequestLoanRepository = staffRequestLoanRepository;
            this.staffRequestRepository = staffRequestRepository;
            this.staffRequestApproverRepository = staffRequestApproverRepository;
            this.convertWordToPdf = convertWordToPdf;
            this.textReplacement = textReplacement;
            this.staffRequestDocument = staffRequestDocument.Value;
        }
        public async Task<Result> Handle(StaffRequestLoanGeneratePdf request, CancellationToken cancellationToken)
        {
            var staffRequestLoan = await staffRequestLoanRepository.GetById(request.Id);
            var staffRequest = await staffRequestRepository.GetById(request.Id);
            staffRequest.DateEvaluation = await staffRequestApproverRepository.GetDateEvaluation(request.Id);
            staffRequest.SetDateEvaluation();
            staffRequest.StaffRequestEmployee.SetDateAdmissionToString();
            staffRequestLoan.StaffRequest = staffRequest;
            
            var listApproved = await staffRequestApproverRepository.GetListById(request.Id);
                listApproved.ForEach(x =>
                {
                    x.SetStateName();
                    x.ConvertReviewDateToString();
                });
            if (listApproved.Count>0)
            {
                staffRequestLoan.StaffRequestApproverDto = listApproved.Last();
            }
            var replaceTextLoan = new ReplaceTextLoan(staffRequestLoan);
            replaceTextLoan.Replace();
            var generatorPdf = new GeneratorPdf(staffRequestLoan.IdStaffRequest,
                                                                staffRequestDocument.FullPathFileWordLoan,
                                                                staffRequestDocument.PathFileWordCopy,
                                                                staffRequestDocument.PathFilePdf,
                                                                replaceTextLoan.ListReplaceEntity);

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
