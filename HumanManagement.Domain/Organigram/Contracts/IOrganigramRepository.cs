using HumanManagement.Domain.Organigram.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Organigram.Contracts
{
    public interface IOrganigramRepository
    {
        Task<List<AreaCargoDto>> GetOrganigram(int idEmpresa);
        Task<List<AreaCargoDto>> GetOrganigramDetail(int idEmpresa, int idArea, int idCargo);
        Task<List<AreaCargoDto>> GetOrganigramByCargo(int idEmpresa, int idArea, int idCargo);
        Task<List<OrganigramV2Dto>> GetOrganigramV2(int nidcompany);
    }
}
