using HumanManagement.Domain.WindowsService.ServerUs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.ServerUs.Contracts
{
    public interface ISUMovAsistenciaDetRepository
    {
        Task<int> Insert(SUInsertMovDetDto insertDto);
    }
}
