using HumanManagement.Domain.Postulant.Education.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Education.Contracts
{
    public interface IEducationPostulantRepository
    {
        Task<List<EducationPostulantDto>> GetEducationByPostulant(int IdPerson);
    }
}
