using HumanManagement.Domain.Mof.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Mof.Contracts
{
    public interface IMofRepository
    {

        Task<List<MofDetailProfListDto>> GetMofDetailProfListsByCharge(int IdCharge);
        Task<List<MofDetailProfListDto>> GetMofDetailProfList(MofFilter filter);
    }
}
