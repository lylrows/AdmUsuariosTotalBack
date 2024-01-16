using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using HumanManagement.Domain.Security.QueryFilter;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HumanManagement.Domain.Common;

namespace HumanManagement.MsSql.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public UserRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection, 
                              DbContextMsSql context)
            : base(context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<UserLogged> Authenticate(LoginDto loginDto)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@susername", loginDto.Username);
            queryParameters.Add("@spassword", loginDto.PasswordEncrypted);

            var user = await humanManagementReadDbConnection.QueryAsync<UserLogged>(
                 "sps_login_user",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return user.SingleOrDefault();
        }

        public async Task<UserDto> GetById(int id)
        {

            var result = await (from n in context.User
                                join pu in context.ProfileUser
                                on n.Id equals pu.IdUser
                                where n.Id == id
                                select new UserDto
                                {
                                    Id = n.Id,
                                    UserName = n.UserName,
                                    PasswordResetCode = n.PasswordResetCode,
                                    PasswordResetStart = n.PasswordResetStart,
                                    IdPerson = n.IdPerson,
                                    IdProfile=pu.IdProfile
                                }).SingleOrDefaultAsync();


            return result;
        }
        public async Task<UserDto> GetByEmail(string email)
        {
            var result = await (from pers in context.Person
                                join usr in context.User
                                on pers.Id equals usr.IdPerson
                                where pers.Email == email
                                select new UserDto
                                {
                                    Id = usr.Id,
                                    UserName = usr.UserName

                                }).FirstOrDefaultAsync();

            return result;
        }
        public async Task<ResultPaginationListDto<UserGridView>> GetListUsersPagination(UserQueryFilter userQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidcompany", userQueryFilter.IdCompany);
            queryParameters.Add("@nidarea", userQueryFilter.IdArea);
            queryParameters.Add("@schargename", userQueryFilter.chargeName);
            queryParameters.Add("@fullname", userQueryFilter.UserName);
            queryParameters.Add("@nsituation", userQueryFilter.nsituation);
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

        public async Task<int> GetIdByUserName(string userName)
        {
            int idUser = await context.User.Where(x => x.UserName == userName)
                                .Select(d => d.Id).SingleOrDefaultAsync();

            return idUser;
        }

        public async Task<UserDto> GetUserByEmployeeId(int nEmployeeId)
        {
            var result = await (from emp in context.Employee
                                join usr in context.User 
                                on emp.IdPerson equals usr.IdPerson
                                join pers in context.Person
                                on emp.IdPerson equals pers.Id
                                join charge  in context.tb_charge 
                                on emp.IdPosition equals  charge.Id
                                where emp.Id == nEmployeeId
                                select new UserDto
                                {
                                    Id = usr.Id,
                                    UserName = usr.UserName,
                                    IdPerson = usr.IdPerson,
                                    FirstName = pers.FirstName,
                                    SecondName = pers.SecondName,
                                    LastName = pers.LastName,
                                    MotherLastName = pers.MotherLastName,
                                    IdArea = charge.IdArea,
                                    Email = pers.Email

                                }).SingleOrDefaultAsync();

            return result;
        }


    }
}
