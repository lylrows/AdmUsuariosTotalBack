using HumanManagement.Domain.Postulant.Languages.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Languages.Contracts
{
    public interface ILanguagesPostulantRepository
    {
        Task<List<LanguagePostulantDto>> GetLanguagePostulant(int IdPerson);
    }
}
