using HumanManagement.Domain.BaseDto;
using HumanManagement.Domain.Campaign.Models;
using HumanManagement.Domain.Proficiency.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Proficiency.Contracts
{
    public interface IProficiencyRepository
    {
        Task<List<ProficiencyDto>> getListProficiencies();

    }
}
