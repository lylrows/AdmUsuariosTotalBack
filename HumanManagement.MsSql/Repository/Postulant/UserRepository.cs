using Dapper;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Postulant.Models;
using HumanManagement.Domain.Postulant.Security.Contracts;
using HumanManagement.Domain.Postulant.Security.Dto;
using HumanManagement.Domain.Security.QueryFilter;
using HumanManagement.MsSql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.Postulant
{
    public class UserRepository : BaseRepository<UserPostulant>, IUserRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        private readonly IHumanManagementDbContext connetion;
        public UserRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection, IHumanManagementDbContext connetion,
                              DbContextMsSql context)
            : base(context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
            this.connetion = connetion;
        }

        public async Task<int> ActiveAccount(int id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_user", id);
            var result = await connetion.Connection.ExecuteAsync(
                 "recruitment.spu_active_user",
                 queryParameters,null,null, CommandType.StoredProcedure);

            return result;
        }

        public async Task<UserLogged> Authenticate(LoginDto loginDto)
        {
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@susername", loginDto.Username);
                queryParameters.Add("@spassword", loginDto.PasswordEncrypted);

                var user = await humanManagementReadDbConnection.QueryAsync<UserLogged>(
                     "recruitment.sps_login_user",
                     queryParameters, commandType: CommandType.StoredProcedure);

                return user.SingleOrDefault();
            }
        }

        public async Task<int> ChangePassword(ChangePasswordDto dto)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_user", dto.IdUser);
            queryParameters.Add("@password", dto.PasswordEncrypted);
            var result = await connetion.Connection.ExecuteAsync(
                 "recruitment.spu_password_user",
                 queryParameters, null, null, CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> DeleteUser(DeleteUserDto dto)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_user", dto.IdUser);
            queryParameters.Add("@nid_person", dto.IdPerson);
            var result = await connetion.Connection.ExecuteAsync(
                 "recruitment.spd_account_user",
                 queryParameters, null, null, CommandType.StoredProcedure);

            return result;
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var result = await(from pers in context.PersonPostulant
                               join usr in context.UserPostulant
                               on pers.Id equals usr.IdPerson
                               where pers.Email == email
                               select new UserDto
                               {
                                   Id = usr.Id,
                                   UserName = usr.UserName

                               }).SingleOrDefaultAsync();

            return result;
        }

        public async Task<UserDto> GetById(int id)
        {
            var result = await(from n in context.UserPostulant
                               where n.Id == id
                               select new UserDto
                               {
                                   Id = n.Id,
                                   UserName = n.UserName,
                                   PasswordResetCode = n.PasswordResetCode,
                                   PasswordResetStart = n.PasswordResetStart
                               }).SingleOrDefaultAsync();

            return result;
        }

        public async Task<int> GetIdByUserName(string userName)
        {
            int idUser = await context.UserPostulant.Where(x => x.UserName == userName)
                               .Select(d => d.Id).SingleOrDefaultAsync();

            return idUser;
        }

        public async Task<ResultPaginationListDto<UserGridView>> GetListUsersPagination(UserQueryFilter userQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidcompany", userQueryFilter.IdCompany);
            queryParameters.Add("@nidarea", userQueryFilter.IdArea);
            queryParameters.Add("@schargename", userQueryFilter.chargeName);
            queryParameters.Add("@fullname", userQueryFilter.UserName);
            queryParameters.Add("@ncurrentpage", userQueryFilter.pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", userQueryFilter.pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listUSer = await humanManagementReadDbConnection.QueryAsync<UserGridView>(
                 "sps_get_user_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);

            int totalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));

            return new ResultPaginationListDto<UserGridView>
            {
                list = listUSer.ToList(),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / userQueryFilter.pagination.ItemsPerPage)
            };
        }
    }
}
