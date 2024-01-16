using HumanManagement.Domain.Postulant.Security.Dto;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Security.IServices
{
    public interface IUserService
    {
        
        Task<Result> CreateUser(UserDto userDto);
        Task<Result> ChangePassword(ResetPasswordDto resetPasswordDto);
        Task<Result> ForgotPassword(ForgotPasswordDto forgotPasswordDto);
        Task<Result> ValidResetPasswordCode(int IdUser, Byte[] providedCode);
        Task<Result> ActiveAccount(int id);
        Task<Result> SendMailActivation(string email);
        Task<Result> ChangePasswordConfiguration(ChangePasswordDto dto);
        Task<Result> DeleteUser(DeleteUserDto dto);
        Task<Result> SendEmailPostulantConfirmation(string email,string job);
        

    }
}
