using System;
using System.Threading.Tasks;
using HumanManagement.Application.ImportEmployeeService;
using HumanManagement.Application.Security.Commands.Create;
using HumanManagement.Application.Security.Commands.Update;
using HumanManagement.Application.Security.Queries;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Security.Dto;
using HumanManagement.Domain.Security.QueryFilter;
using HumanManagementApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HumanManagementApi.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IImportEmployeeService importEmployeeService;
        private readonly AppSettings appSettings;
        public UserController(IImportEmployeeService importEmployeeService, 
                              IOptions<AppSettings> appSettings)
        {
            this.importEmployeeService = importEmployeeService;
            this.appSettings = appSettings.Value;
        }
        [HttpPost("add")]
        public async Task<IActionResult> add()
        {
            var objJson = Request.Form["data"];
            UserDto userDto = JsonConvert.DeserializeObject<UserDto>(objJson);

            FormFileStream formFileStream = new FormFileStream(appSettings,
                                                               Constants.Images.FOLDER_USER,
                                                               Request.Form.Files);
            formFileStream.SavePhoto();
            if (!string.IsNullOrEmpty(formFileStream.FullPath))
            {
                
                userDto.PhotoUrl = appSettings.UrlFile + "Imagenes//Usuario//" + formFileStream.fileName;
            }

            var result = await mediator.Send(new CreateUserCommand() { User = userDto });

            return Ok(result);
        }

        [HttpPut("edit")]
        
        public async Task<IActionResult> edit()
        {
            var objJson = Request.Form["data"];
            UserDto userDto = JsonConvert.DeserializeObject<UserDto>(objJson);
            FormFileStream formFileStream = new FormFileStream(appSettings,
                                                               Constants.Images.FOLDER_USER,
                                                               Request.Form.Files);
            formFileStream.SavePhoto();
            if (!string.IsNullOrEmpty(formFileStream.FullPath))
            {
                
                userDto.PhotoUrl = appSettings.UrlFile + "Imagenes//Usuario//" + formFileStream.fileName;
                
            }
            var result = await mediator.Send(new UpdateUserCommand() { User = userDto });

            return Ok(result);
        }

        [HttpPatch("resetpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {

            if (!string.IsNullOrEmpty(resetPasswordDto.CodeBase64Url)) {
                String codeBase64 = resetPasswordDto.CodeBase64Url.Replace('-', '+').Replace('_', '/');
                Byte[] providedCode = Convert.FromBase64String(codeBase64);
                if (providedCode.Length != 12) return this.BadRequest("Código Inválido.");
            }

            var data = await mediator.Send(new ResetPasswordCommand() { ResetPassword = resetPasswordDto });

            return Ok(data);
        }

        [HttpPatch("changemypassword")]
        public async Task<IActionResult> ChangeMyPassword(ChangeMyPasswordDto resetPasswordDto)
        {


            var data = await mediator.Send(new ChangeMyPasswordCommand() { ResetPassword = resetPasswordDto });

            return Ok(data);
        }

        

        [HttpPatch("unblocked/{id}")]
        public async Task<IActionResult> UnBlocked(int id)
        {
            var result = await mediator.Send(new UnBlockedUserCommand() { Id = id });

            return Ok(result);
        }

        [HttpPost("getlistpagination")]
        public async Task<IActionResult> GetListPagination(UserQueryFilter userQueryFilter)
        {
            var listUser = await mediator.Send(new GetListUsersPaginationQuery() { UserQueryFilter = userQueryFilter });

            return Ok(listUser);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var userDto = await mediator.Send(new GetUserByIdQuery() { IdUser = id });

            return Ok(userDto);
        }

        [HttpPost("Import")]
        public async Task<IActionResult> Import(int id)
        {
            importEmployeeService.Import();

            return Ok();
        }

        [HttpPost("sendpasswordresetcode")]
        [AllowAnonymous]
        public async Task<IActionResult> SendPasswordResetCode(ForgotPasswordDto dto)
        {
            var data = await mediator.Send(new SendPasswordResetCodeCommand() { forgotPassword = dto });

            return Ok(data);
        }


        [HttpGet("validressetpassword/{userId}/{codeBase64Url}")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword( int userId,string codeBase64Url)
        {
  

            String codeBase64 = codeBase64Url.Replace('-', '+').Replace('_', '/');
            Byte[] providedCode = Convert.FromBase64String(codeBase64);
            if (providedCode.Length != 12) return this.BadRequest("Código Inválido.");

            var data = await mediator.Send(new GetValidResetPasswordCodeQuery() { IdUser = userId, providedCode = providedCode });
          
            return Ok(data);
        }


    }
}