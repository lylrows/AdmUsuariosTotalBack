using HumanManagement.Domain.WindowsService.Exactus.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Contracts
{
    public interface IExactusMedicalRequestRepository
    {
        Task<ExactusMedicalRequestInsSpDto> InsertMedicalRequestSP(ExactusMedicalRequestInsSpDto dto);
        Task<ExactusDiasVacacionesDto> GetVacationsDays(string scode_employee, string scode_esquema);
    }
}
