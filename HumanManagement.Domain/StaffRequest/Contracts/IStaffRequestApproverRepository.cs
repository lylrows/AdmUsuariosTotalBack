using HumanManagement.Domain.StaffRequest.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface IStaffRequestApproverRepository
    {
        Task<List<StaffRequestApproverListDto>> GetListById(int idStaffRequest);
        Task<DateTime?> GetDateEvaluation(int idStaffRequest);
    }
}
