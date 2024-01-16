using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Models;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
using HumanManagement.Domain.Contracts;
using System.Data;

namespace HumanManagement.MsSql.Repository.Security
{
    public class ProfileUserRepository : BaseRepository<ProfileUser>, IProfileUserRepository
    {
        private readonly IHumanManagementDbContext connetion;
        public ProfileUserRepository(DbContextMsSql context, IHumanManagementDbContext connetion)
            :base(context)
        {
            this.connetion = connetion;
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

        public async Task<List<int>> UpdateProfile(int profile, int user)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@idprofile", profile);
            queryParameters.Add("@iduser", user);
            var result = await connetion.Connection.QueryAsync<int>(
                 "spu_update_profile",
                 queryParameters, commandType: CommandType.StoredProcedure);

            /*var result = await connetion.Connection.ExecuteAsync(
                 "spu_update_profile",
                 queryParameters, commandType: CommandType.StoredProcedure);*/

            return result.ToList();
        }
    }
}
