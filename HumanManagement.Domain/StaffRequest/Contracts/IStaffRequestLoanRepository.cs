using HumanManagement.Domain.StaffRequest.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface IStaffRequestLoanRepository
    {
        Task<StaffRequestLoanDto> GetById(int id);
        Task<List<RequestDetailtLoanDto>> GetDetailtById(int id);
        Task<List<RequestDetailtLoanDto>> CalculateTimeLine(StaffRequestLoanDto payload);
    }
}
