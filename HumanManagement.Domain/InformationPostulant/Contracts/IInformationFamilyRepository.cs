using HumanManagement.Domain.InformationPostulant.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.InformationPostulant.Contracts
{
    public interface IInformationFamilyRepository
    {
        Task<List<InformationFamilyDto>> GetInformationFamily(int IdPostulant, int IdEvaluation);
        Task<List<InformationFamilyDto>> GetInformationFamilyByPerson(int IdPostulant);
    }
}
