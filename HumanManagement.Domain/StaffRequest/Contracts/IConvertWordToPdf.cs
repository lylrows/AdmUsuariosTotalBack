using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface IConvertWordToPdf
    {
        void ExportToPdf(string fullPathWordCopy, string fullPathPdf);
    }
}
