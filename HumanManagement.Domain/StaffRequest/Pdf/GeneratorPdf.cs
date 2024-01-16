using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.Pdf
{
    public class GeneratorPdf
    {
        private string nameFileRandom;
        private string fullPathTemplateFileWord;
        private string pathWordCopy;
        private string fullPathWordCopy;
        private int IdStaffRequest;
        private string pathFilePdf;
        private string fullPathPdf;
        private List<ReplaceEntity> listReplaceEntity;
        public GeneratorPdf(int IdStaffRequest,
                            string fullPathTemplateFileWord,
                            string pathWordCopy,
                            string pathFilePdf,
                            List<ReplaceEntity> listReplaceEntity)
        {
            this.IdStaffRequest = IdStaffRequest;
            this.fullPathTemplateFileWord = fullPathTemplateFileWord;
            this.pathWordCopy = pathWordCopy;
            this.pathFilePdf = pathFilePdf;
            this.listReplaceEntity = listReplaceEntity;
        }

        private void SetInitListReplace()
        {
            listReplaceEntity.ForEach(x =>
            {
                if (string.IsNullOrEmpty(x.sreplacetext))
                {
                    x.sreplacetext = string.Empty;
                }
            });
        }
        public void Generate(ITextReplacement textReplacement,
                             IConvertWordToPdf convertWordToPdf,
                             string pathEmployeeSignature)
        {
            SetInitListReplace();
            SetNameRandom();
            SetNameWordCopy();
            SetFileNamePdf();
            File.Copy(fullPathTemplateFileWord, fullPathWordCopy);
            textReplacement.ReplaceText(listReplaceEntity, pathEmployeeSignature, fullPathWordCopy);
            convertWordToPdf.ExportToPdf(fullPathWordCopy, fullPathPdf);
        }

        public void Generate(ITextReplacement textReplacement,
                             IConvertWordToPdf convertWordToPdf,
                             string pathEmployeeSignature, GetStaffBurialByIdDto sepelioDto)
        {
            SetInitListReplace();
            SetNameRandom();
            SetNameWordCopy();
            SetFileNamePdf();
            File.Copy(fullPathTemplateFileWord, fullPathWordCopy);
            textReplacement.ReplaceText(listReplaceEntity, pathEmployeeSignature, fullPathWordCopy,sepelioDto);
            convertWordToPdf.ExportToPdf(fullPathWordCopy, fullPathPdf);
        }
        
        private void SetNameWordCopy()
        {
            fullPathWordCopy = $"{this.pathWordCopy}{nameFileRandom}.docx";
        }
        private void SetNameRandom()
        {
            nameFileRandom = $"{IdStaffRequest}_{DateTime.Now.ToString("ddMMyyyy hhmmss")}";
        }

        private void SetFileNamePdf()
        {
            fullPathPdf = $"{pathFilePdf}{nameFileRandom}.pdf";
        }

        public string GetFileNamePdf()
        {
            return fullPathPdf;
        }
    }
}
