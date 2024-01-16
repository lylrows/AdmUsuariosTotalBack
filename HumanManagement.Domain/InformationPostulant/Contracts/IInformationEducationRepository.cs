using HumanManagement.Domain.InformationPostulant.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.InformationPostulant.Contracts
{
    public interface IInformationEducationRepository
    {
        Task<List<InformationEducationDto>> GetInformationEducation(int IdPostulant, int idEvaluation);
        Task<List<InformationEducationDto>> GetInformationEducationByPerson(int IdPostulant);
    }
}
