using HumanManagement.Domain.WindowsService.ServerUs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.ServerUs.Contracts
{
    public interface ISUMovAsistenciaCabRepository
    {
        Task<int> GetNewId(SUGetNewIdFilterDto filterDto);
        Task<int> GetIdEmployee(int identidad, string codemployee);
        Task<int> Insert(SUInsertMovCabDto insertDto);
        Task<bool> InsertPermSP(ServerUsInsPermSPDto dto);

    }
}
