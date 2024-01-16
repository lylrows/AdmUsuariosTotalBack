using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using HumanManagement.MsSql.Context;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.Security
{
    public class TokenUserRepository : ITokenUserRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        private readonly DbContextMsSql context;
        public TokenUserRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection,
                                    DbContextMsSql context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
            this.context = context;
        }

        public async Task<int> GetIdTokenActiveByUser(int idUser)
        {
            var idToken = await context.TokenUser.Where(x => x.IdUser == idUser && x.Active == true)
                                        .Select(d => d.Id).SingleOrDefaultAsync();

            return idToken;
        }

        public async Task<UserSessionDto> GetUserByToken(string token)
        {
            var user = await (from n in context.TokenUser
                              join u in context.User on n.IdUser equals u.Id
                              join pu in context.ProfileUser on u.Id equals pu.IdUser
                              join p in context.Person on u.IdPerson equals p.Id into up
                              from person in up.DefaultIfEmpty()
                              join e in context.Employee on person.Id equals e.IdPerson into pe
                              from employee in pe.DefaultIfEmpty()
                              where n.Token == token
                              select new UserSessionDto
                              {
                                  IdUser = n.IdUser,
                                  IdPerson = u.IdPerson,
                                  IdProfile = pu.IdProfile,
                                  IdEmployee = employee != null ? employee.Id : 0,
                                  Email = person != null ? person.Email : string.Empty
                              }).SingleOrDefaultAsync();

            return user;
        }

        public async Task<bool> IsValidToken(TokenUserQueryDto tokenUserQueryDto)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@stoken", tokenUserQueryDto.Token);
            queryParameters.Add("@sapiroute", tokenUserQueryDto.ApiRoute);

            var isValid = await humanManagementReadDbConnection.QueryAsync<bool>(
                 "sps_get_token_user",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return isValid[0];
        }
    }
}
