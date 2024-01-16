using HumanManagement.Domain.WindowsService.Exactus.Dto;
using HumanManagement.Domain.WindowsService.Exactus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Contracts
{
    public interface IExactusNominaRepository
    {
        Task<List<ExactusNomina>> GetAll(ExactusNominaFilterDto filterDto);
    }
}
