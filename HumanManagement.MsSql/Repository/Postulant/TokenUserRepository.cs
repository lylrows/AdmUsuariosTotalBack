using Dapper;
using HumanManagement.MsSql.Context;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Postulant.Security.Contracts;
using HumanManagement.Domain.Postulant.Security.Dto;

namespace HumanManagement.MsSql.Repository.Postulant
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
            var idToken = await context.TokenUserPostulant.Where(x => x.IdUser == idUser && x.Active == true)
                                        .Select(d => d.Id).SingleOrDefaultAsync();

            return idToken;
        }

        public async Task<int> GetIdUserByToken(string token)
        {
            var idUser = await context.TokenUserPostulant.Where(x => x.Token == token)
                                        .Select(d => d.IdUser).SingleOrDefaultAsync();

            return idUser;
        }

        public async Task<UserSessionDto> GetUserByToken(string token)
        {
            var user = await (from n in context.TokenUserPostulant
                              join u in context.UserPostulant on n.IdUser equals u.Id
                              join p in context.PersonPostulant on u.IdPerson equals p.Id into up
                              from person in up.DefaultIfEmpty()
                              where n.Token == token
                              select new UserSessionDto
                              {
                                  IdUser = n.IdUser,
                                  IdPerson = u.IdPerson,
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
                 "recruitment.sps_get_token_user",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return isValid[0];
        }
    }
}
