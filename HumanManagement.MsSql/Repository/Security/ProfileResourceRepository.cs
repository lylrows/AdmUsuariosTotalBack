using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using HumanManagement.Domain.Security.Models;
using HumanManagement.MsSql.Context;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.Security
{
    public class ProfileResourceRepository : BaseRepository<ProfileResource>, IProfileResourceRepository
    {
        public ProfileResourceRepository(DbContextMsSql context)
            :base(context)
        {

        }

        public async Task<List<ProfileResourceDto>> GetListResource(int idProfile)
        {
            var profileResource = await (from n in context.ProfileResource
                                   join m in context.Resource on n.IdResource equals m.Id
                                   where n.IdProfile == idProfile && m.Active == true && n.Active==true
                                   select new ProfileResourceDto
                                   {
                                       IdResource = n.IdResource,
                                       IdFather = m.IdFhater,
                                       Name = m.Name,
                                       Type = m.TypeResource == 1 ? "Link" :
                                       m.TypeResource == 2 ? "dropDown" : "",
                                       SvgIcon = m.VgIcon,
                                       RouteLink = m.RouterLink,
                                       Order = m.Order
                                   }).OrderBy(m => m.Order).ToListAsync();
            return profileResource;
        }
    }
}
