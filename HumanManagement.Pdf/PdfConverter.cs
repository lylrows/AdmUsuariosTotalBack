using System;
using HumanManagement.Domain.StaffRequest.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.Office.Interop.Word;

namespace HumanManagement.Pdf
{
    public class PdfConverter : IConvertWordToPdf
    {
        private readonly ILogger<PdfConverter> _logger;
        private Microsoft.Office.Interop.Word.Application application;
        private Document document;

        public PdfConverter(ILogger<PdfConverter> logger)
        {
            this._logger = logger;
        }

        public void ExportToPdf(string fullPath, string fullPathPdf)
        {
            _logger.LogInformation(String.Format("Inicio ExportToPdf"));
            _logger.LogInformation(String.Format("Inicio Referencia Application"));
            application = new Microsoft.Office.Interop.Word.Application();
            _logger.LogInformation(String.Format("Fin Referencia Application"));
            _logger.LogInformation(String.Format("Inicio Referencia Document"));
            document = new Microsoft.Office.Interop.Word.Document();
            _logger.LogInformation(String.Format("Fin Referencia Document"));
            try
            {
                _logger.LogInformation(String.Format("Inicio Referencia application.Documents.Open => {0}", fullPath));
                document = application.Documents.Open(fullPath);
                _logger.LogInformation(String.Format("Fin Referencia application.Documents.Open => {0}", fullPath));
                _logger.LogInformation(String.Format("Inicio ExportAsFixedFormat"));
                document.ExportAsFixedFormat(fullPathPdf, WdExportFormat.wdExportFormatPDF);
                _logger.LogInformation(String.Format("Fin ExportAsFixedFormat"));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(String.Format("Exception ExportToPdf ex => {0}", ex.Message));
                _logger.LogInformation(String.Format("Exception ExportToPdf StackTrace => {0}", ex.StackTrace));
            }
            finally
            {
                document.Close();
                application.Quit();
                _logger.LogInformation(String.Format("Fin ExportToPdf"));
            }
        }
    }
}
