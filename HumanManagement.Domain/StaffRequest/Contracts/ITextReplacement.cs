using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface ITextReplacement
    {
        void ReplaceText(List<ReplaceEntity> listReplaceEntity, string pathSignature, string fullPathWordCopy);
        string ReplaceTextEmployeeCV(EmployeeCVDto employeeCVDto, string pathDirectory, string pathTemplate);
        Task<string> ReplaceTextEvuationDetailPDF(object res);
        void ReplaceText(List<ReplaceEntity> listReplaceEntity, string pathSignature, string fullPath, GetStaffBurialByIdDto sepelioDto);
    }
}
