using HumanManagement.Domain.Common;
using HumanManagement.Domain.Security.Dto;
using HumanManagement.Domain.Security.QueryFilter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Security.Contracts
{
    public interface IUserRepository
    {
        Task<UserLogged> Authenticate(LoginDto loginDto);
        Task<UserDto> GetById(int id);
        Task<UserDto> GetByEmail(string email);
        Task<ResultPaginationListDto<UserGridView>> GetListUsersPagination(UserQueryFilter userQueryFilter);
        Task<int> GetIdByUserName(string userName);
        Task<UserDto> GetUserByEmployeeId(int nEmployeeId);
    }
}
