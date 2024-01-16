using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanManagement.Domain.Postulant.Security.Contracts;
using HumanManagement.Domain.Postulant.Security.Models;
using HumanManagement.MsSql.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.Postulant
{
    public class ProfileUserRepository : BaseRepository<ProfileUserPostulant>, IProfileUserRepository
    {

        public ProfileUserRepository(DbContextMsSql context)
            :base(context)
        {

        }
        public async Task<int> GetProfileByUser(int idUser)
        {
            var profile = await dbSetEntity.Where(x => x.IdUser == idUser).SingleOrDefaultAsync();
            int idProfile = 0;
            if (profile!= null)
            {
                idProfile = profile.IdProfile;
            }
            return idProfile;
        }
    }
}
