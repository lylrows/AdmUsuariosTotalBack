using HumanManagement.Domain.WindowsService.Exactus.Dto;
using HumanManagement.Domain.WindowsService.Exactus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Contracts
{
    public interface IExactusEmpleadoRepository
    {
        Task<bool> InsertEmpleado(ExactusEmpleadoInsertDto dto);
        Task<string> InsertEmpleadoSP(ExactusEmpleadoInsSpDto dto);
        Task<string> InsertDireccionSP(ExactusEmpleadoInsSpDirDto dto);
        Task<ExactusFullEmployeeDto> GetAll(ExactusEmpleadoFilterDto filterDto);
        Task<List<ExactusEmpleadoTablaDto>> GetEmpleadoTabla(ExactusEmpleadoTablaFilterDto filterDto);
        Task<ExactusGlobalCCPDto> GetExactusGlobalCCP(string sschema);
    }
}
