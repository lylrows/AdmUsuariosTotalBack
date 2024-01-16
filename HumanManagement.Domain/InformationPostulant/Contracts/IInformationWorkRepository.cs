using HumanManagement.Domain.InformationPostulant.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.InformationPostulant.Contracts
{
    public interface IInformationWorkRepository
    {
        Task<List<InformationWorkDto>> GetInformationWork(int IdPostulant, int IdEvaluation);
    }
}
