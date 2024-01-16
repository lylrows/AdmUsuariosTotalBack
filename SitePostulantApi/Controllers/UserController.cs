using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Postulant.Security.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SitePostulant.Application.Security.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly AppSettings appSettings;
        private readonly IUserService userService;

        public UserController(IOptions<AppSettings> appSettings, IUserService userService)
        {
            this.appSettings = appSettings.Value;
            this.userService = userService;
        }

        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<IActionResult> add(UserDto userDto)
        {
            var result = await userService.CreateUser(userDto);

            return Ok(result);
        }

        [HttpPatch("resetpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword(ResetPasswordDto resetPasswordDto)
        {
            if (!string.IsNullOrEmpty(resetPasswordDto.CodeBase64Url))
            {
                String codeBase64 = resetPasswordDto.CodeBase64Url.Replace('-', '+').Replace('_', '/');
                Byte[] providedCode = Convert.FromBase64String(codeBase64);
                if (providedCode.Length != 12) return this.BadRequest("Código Inválido.");
            }

            var result = await userService.ChangePassword(resetPasswordDto);

            return Ok(result);
        }

        [HttpGet("validressetpassword/{userId}/{codeBase64Url}")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword(int userId, string codeBase64Url)
        {
            String codeBase64 = codeBase64Url.Replace('-', '+').Replace('_', '/');
            Byte[] providedCode = Convert.FromBase64String(codeBase64);
            if (providedCode.Length != 12) return this.BadRequest("Código Inválido.");

            var result = await userService.ValidResetPasswordCode(userId, providedCode);

            return Ok(result);
        }

        [HttpGet("activeaccount/{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> ActiveAccount(int userId)
        {
            var result = await userService.ActiveAccount(userId);

            return Ok(result);
        }


        [HttpGet("sendmailactivation/{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> SendMailActivate(string email)
        {
            var result = await userService.SendMailActivation(email);

            return Ok(result);
        }

        [HttpGet("sendmailpostulantconfirmation/{email}/{job}")]
        [AllowAnonymous]
        public async Task<IActionResult> SendMailPostulantConfirmation(string email,string job)
        {
            var result = await userService.SendEmailPostulantConfirmation(email,job);

            return Ok(result);
        }

        [HttpPost("sendpasswordresetcode")]
        [AllowAnonymous]
        public async Task<IActionResult> SendCodeResetPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var result = await userService.ForgotPassword(forgotPasswordDto);

            return Ok(result);
        }

        [HttpPost("changepasswordconfig")]
        public async Task<IActionResult> ChangePasswordConfiguration(ChangePasswordDto dto)
        {
            var result = await userService.ChangePasswordConfiguration(dto);

            return Ok(result);
        }

        [HttpPost("deleteuser")]
        public async Task<IActionResult> DelteUser(DeleteUserDto dto)
        {
            var result = await userService.DeleteUser(dto);

            return Ok(result);
        }
    }
}
