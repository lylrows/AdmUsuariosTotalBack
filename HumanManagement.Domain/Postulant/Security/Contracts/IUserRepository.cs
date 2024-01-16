using HumanManagement.Domain.Common;
using HumanManagement.Domain.Postulant.Security.Dto;
using HumanManagement.Domain.Security.QueryFilter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Security.Contracts
{
    public interface IUserRepository
    {
        Task<UserLogged> Authenticate(LoginDto loginDto);
        Task<UserDto> GetById(int id);
        Task<UserDto> GetByEmail(string email);
        Task<ResultPaginationListDto<UserGridView>> GetListUsersPagination(UserQueryFilter userQueryFilter);
        Task<int> GetIdByUserName(string userName);

        Task<int> ActiveAccount(int id);
        Task<int> ChangePassword(ChangePasswordDto dto);
        Task<int> DeleteUser(DeleteUserDto dto);
    }
}
