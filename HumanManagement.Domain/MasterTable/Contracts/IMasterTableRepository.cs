using HumanManagement.Domain.MasterTable.Dto;
using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.MasterTable.Contracts
{
    public interface IMasterTableRepository
    {
        Task<IEnumerable<MasterTableDto>> GetByIdFather(int id, int nid_type = 0);
    }
}
