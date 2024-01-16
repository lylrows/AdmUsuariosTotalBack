using HumanManagement.Domain.Empresa.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Empresa.Contracts
{
    public interface IEmpresaRepository
    {
        Task<List<EmpresaDto>> GetAll();
        Task<int> GetIdByName(string nameCompany);
        Task<List<EmpresaDto>> GetEmpresaByUser(int IdUser);
    }
}
