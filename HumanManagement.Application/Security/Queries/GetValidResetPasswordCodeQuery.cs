using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Security.Contracts;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Queries
{

    public class GetValidResetPasswordCodeQuery : IRequest<Result>
    {
        public int IdUser { get; set; }
        public Byte[] providedCode { get; set; }
        public class GetValidResetPasswordCodeQueryHandler : IRequestHandler<GetValidResetPasswordCodeQuery, Result>
        {
            private readonly IUserRepository userRepository;
            private readonly AppSettings _appSettings;

            public GetValidResetPasswordCodeQueryHandler(IUserRepository userRepository, IOptions<AppSettings> appSettings)
            {
                this.userRepository = userRepository;
                _appSettings = appSettings.Value;
            }
            public async Task<Result> Handle(GetValidResetPasswordCodeQuery request, CancellationToken cancellationToken)
            {
                Result result = new Result();
                TimeSpan _passwordResetExpiry = TimeSpan.FromMinutes(_appSettings.PasswordResetExpiry);
                var userDto = await userRepository.GetById(request.IdUser);


                if (userDto == null)
                {
                    result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                    result.MessageError = new List<string>(){
                    "El usuario no existe"};
                    return result;
                }

                if (userDto.PasswordResetStart == null  || userDto.PasswordResetCode == null)
                {
                    result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                    result.MessageError = new List<string>(){
                    "No hay restablecimiento de contraseña pendiente."};
                    return result;
                }
                
                Byte[] expectedCode =  userDto.PasswordResetCode;
                DateTime? start =  userDto.PasswordResetStart;

                if (!Enumerable.SequenceEqual(request.providedCode, expectedCode))
                {
                    result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                    result.MessageError = new List<string>(){
                    "Código incorrecto."};
                    return result;
                }
                DateTime dDateExpiry = userDto.PasswordResetStart.Value.AddMinutes(_appSettings.PasswordResetExpiry);
                if (DateTime.Now > dDateExpiry)
                {
                    result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                    result.MessageError = new List<string>(){
                    "El enlace a vencido. Solicite nuevamente."};
                    return result;
                }


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = userDto
                };
            }
        }
    }
}
