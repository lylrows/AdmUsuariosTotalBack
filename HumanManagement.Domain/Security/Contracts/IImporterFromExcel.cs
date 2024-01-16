using HumanManagement.Domain.Employee.Dto;
using System.Collections.Generic;

namespace HumanManagement.Domain.Security.Contracts
{
    public interface IImporterFromExcel
    {
        List<ImportEmployeeDto> GetListEmployee();
    }
}
