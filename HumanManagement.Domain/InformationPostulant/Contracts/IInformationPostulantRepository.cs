using HumanManagement.Domain.InformationPostulant.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.InformationPostulant.Contracts
{
    public interface IInformationPostulantRepository
    {
        Task<int> SaveInformationPostulantRequest(InformationPostulantRequest request);
        Task<InformationPostulantRequest> GetInformationPostulantRequest(FilterInformationPostulantRequest filter);
        Task<int> SaveInformationInternalExactus(InformationExactusInternalDto request);
        Task<InformationExactusInternalDto> GetInformationInternalExactus(FilterInformationExactusInternalDto filter);

    }
}
